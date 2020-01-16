using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Tests.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Tests
{
    [TestClass]
    public class ProductInStockUpdateStockEventHandlerTest
    {
        [TestMethod]
        public async Task ProductWithStock()
        {
            var context = new ApplicationDbContext(ApplicationDbContextInMemory.Get());

            // Add product
            context.Stocks.Add(new ProductInStock { 
                ProductInStockId = 1,
                ProductId = 1,
                Stock = 1
            });

            context.SaveChanges();

            var command = new ProductInStockUpdateStockEventHandler(context);

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
        public void ProductWithouStock()
        {
            var context = new ApplicationDbContext(ApplicationDbContextInMemory.Get());

            // Add product
            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = 1,
                ProductId = 1,
                Stock = 1
            });

            context.SaveChanges();

            var command = new ProductInStockUpdateStockEventHandler(context);

            Action action = async () =>
            {
                await command.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem> {
                    new ProductInStockUpdateItem {
                        ProductId = 1,
                        Stock = 2,
                        Action = Common.Enums.ProductInStockAction.Substract
                    }
                }
                }, new System.Threading.CancellationToken());
            };

            Assert.ThrowsException<ProductInStockUpdateStockCommandException>(action);
        }
    }
}
