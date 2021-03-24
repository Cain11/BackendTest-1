using Newtonsoft.Json;

namespace Teste.Domain.Model
{
    public class Specifications
    {
        [JsonProperty("Originally published")]
        public string Originallypublished;

        [JsonProperty("Author")]
        public string Author;

        [JsonProperty("Page count")]
        public int Pagecount;

        [JsonProperty("Illustrator")]
        public object Illustrator;

        [JsonProperty("Genres")]
        public object Genres;
    }
}
