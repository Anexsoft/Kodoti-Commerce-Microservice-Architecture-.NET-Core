using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Tests
{
    [TestClass]
    public class ProductInStockUpdateStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> GetIlogger 
        {
            get 
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHandler>>().Object;
            }
        }

        [TestMethod]
        public async Task TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            // Add product
            context.Stocks.Add(new ProductInStock { 
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var command = new ProductInStockUpdateStockEventHandler(context, GetIlogger);

            await command.Handle(new ProductInStockUpdateStockCommand {
                Items = new List<ProductInStockUpdateItem> { 
                    new ProductInStockUpdateItem { 
                        ProductId = 1,
                        Stock = 1,
                        Action = Common.Enums.ProductInStockAction.Substract
                    }
                }
            }, new System.Threading.CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasntStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 2;
            var productId = 2;

            // Add product
            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var command = new ProductInStockUpdateStockEventHandler(context, GetIlogger);

            try
            {
                command.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = productId,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Substract
                    }
                }
                }, new System.Threading.CancellationToken()).Wait();
            }
            catch (AggregateException ae) 
            {
                if (ae.GetBaseException() is ProductInStockUpdateStockCommandException)
                {
                    throw new ProductInStockUpdateStockCommandException(ae.InnerException?.Message);
                }
            }
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 3;
            var productId = 3;

            // Add product
            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var command = new ProductInStockUpdateStockEventHandler(context, GetIlogger);
            command.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = productId,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Add
                    }
                }
            }, new System.Threading.CancellationToken()).Wait();

            Assert.AreEqual(context.Stocks.First(x => x.ProductInStockId == productInStockId).Stock, 3);
        }

        [TestMethod]
        public void TryToAddStockWhenProductNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();
            var command = new ProductInStockUpdateStockEventHandler(context, GetIlogger);

            var productId = 4;

            command.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = productId,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Add
                    }
                }
            }, new System.Threading.CancellationToken()).Wait();

            Assert.AreEqual(context.Stocks.First(x => x.ProductId == productId).Stock, 2);
        }
    }
}
