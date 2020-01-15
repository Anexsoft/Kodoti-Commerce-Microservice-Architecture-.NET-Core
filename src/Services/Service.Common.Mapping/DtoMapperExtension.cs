using System.Text.Json;

namespace Service.Common.Mapping
{
    public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value) 
        {
            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value)
            );
        }
    }
}
