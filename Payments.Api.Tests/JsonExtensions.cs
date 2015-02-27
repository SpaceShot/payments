using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Payments.Api.Tests
{
    public static class JsonExtensions
    {
        public static Task<dynamic> ReadAsJsonAsync(this HttpContent content)
        {
            if (content == null)
                throw new ArgumentNullException("content");

            return content.ReadAsStringAsync().ContinueWith(t => JsonConvert.DeserializeObject(t.Result));
        }

        public static dynamic ToJObject<T>(this T obj)
        {
            dynamic serialized = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject(serialized);
        }
    }
}