using Newtonsoft.Json;

namespace Teste.Domain.Model
{
    public class Book
    {
        [JsonProperty("Id")]
        public int Id;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Price")]
        public double Price;

        [JsonProperty("Specifications")]
        public Specifications Specifications;
    }
}
