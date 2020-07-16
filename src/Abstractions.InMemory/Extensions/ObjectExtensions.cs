using System.Text.Json;

namespace NoteDotNet.Abstractions.InMemory
{
    public static class ObjectExtensions
    {
        public static T DeepClone<T>(this T obj)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(obj));
        }
    }
}
