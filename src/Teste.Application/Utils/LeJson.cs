using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Teste.Domain.Interfaces;
using Teste.Domain.Model;

namespace Teste.Application.Utils
{
    public class LeJson : ILeJson
    {
        public List<Book> LeLivros()
        {
            var json2 = File.ReadAllText(@"C:\Teste Caio-20210322T011317Z-001\Teste Caio\BackendTest-1\src\Teste.Application\books.json");
            //string json = @"./books.json";

            // var jsonString = File.ReadAllLines(json);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json2);

            return books;
        }
    }
}
