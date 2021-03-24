using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teste.Domain.Interfaces;

namespace Teste.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        [Route("[controller]/GetPorNome")]

        public string GetPorNome(string titulo, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorNome(titulo, ordenado);

            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("[controller]/GetPorPreco")]
        public string GetPorPreco(double valor, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorPreco(valor, ordenado);
            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("[controller]/GetPorAutor")]
        public string GetPorAutor(string autor, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorAutor(autor, ordenado);
            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("[controller]/GetPorTotalPaginas")]
        public string GetPorTotalPaginas(int paginas, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorTotalPaginas(paginas, ordenado);
            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("[controller]/GetPorIlustrador")]
        public string GetPorIlustrador(string ilustrador, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorIlustrador(ilustrador, ordenado);
            return JsonConvert.SerializeObject(resultado);
        }
        [HttpGet]
        [Route("[controller]/GetPorGenero")]
        public string GetPorGenero(string genero, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorGenero(genero, ordenado);
            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("[controller]/GetPorData")]
        public string GetPorData(string data, bool? ordenado)
        {
            var resultado = _booksService.RetornaLivroPorDataPublicao(data, ordenado);
            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("[controller]/GetFrete")]
        public string GetFrete(string titulo)
        {
            var resultado = _booksService.CalculaFrete(titulo);
            return JsonConvert.SerializeObject(resultado);
        }


    }
}
