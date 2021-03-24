using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Teste.Domain.Interfaces;
using Teste.Domain.Model;

namespace Teste.Application.Seriveces
{
    public class BooksService : IBooksService
    {
        private readonly ILeJson _leJson;
        public BooksService(ILeJson leJson)
        {
            _leJson = leJson;

        }


        private static List<Book> OrdenaLivroEncontrado(bool? ordenado, List<Book> livroEncontrado)
        {
            if (ordenado != null)
            {
                if (ordenado == false)
                {
                    return livroEncontrado.OrderBy(x => x.Price).ToList();
                }
                return livroEncontrado.OrderByDescending(x => x.Price).ToList();
            }

            return livroEncontrado;
        }
        public List<Book> RetornaLivroPorNome(string titulo, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var livroEncontrado = livros.Where(livro => livro.Name == titulo).ToList();
            return OrdenaLivroEncontrado(ordenado, livroEncontrado);
        }

        public List<Book> RetornaLivroPorPreco(double valor, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var valorCorrespondente = livros.Where(livro => livro.Price == valor).ToList();
            return OrdenaLivroEncontrado(ordenado, valorCorrespondente);
        }

        public List<Book> RetornaLivroPorAutor(string autor, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var autorCorrespondente = livros.Where(livro => livro.Specifications.Author == autor).ToList();
            return OrdenaLivroEncontrado(ordenado, autorCorrespondente);
        }
        public List<Book> RetornaLivroPorTotalPaginas(int paginas, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var paginasCorrespondente = livros.Where(livro => livro.Specifications.Pagecount == paginas).ToList();
            return OrdenaLivroEncontrado(ordenado, paginasCorrespondente);
        }

        public List<Book> RetornaLivroPorIlustrador(string ilustrador, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var livrosDoIlustrador = new List<Book>();
            foreach (var livro in livros)
            {
                if (livro.Specifications.Illustrator.GetType() == typeof(JArray))
                {
                    var item = (IList)livro.Specifications.Illustrator;
                    foreach (var x in item)
                    {
                        if (x.ToString() == ilustrador)
                        {
                            livrosDoIlustrador.Add(livro);
                        }
                    }

                }
                else
                {
                    if (livro.Specifications.Illustrator.ToString() == ilustrador)
                    {
                        livrosDoIlustrador.Add(livro);
                    }
                }
            }
            return OrdenaLivroEncontrado(ordenado, livrosDoIlustrador.ToList());

        }

        public List<Book> RetornaLivroPorGenero(string genero, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var livrosDoGenero = new List<Book>();
            foreach (var livro in livros)
            {
                if (livro.Specifications.Genres.GetType() == typeof(JArray))
                {
                    var item = (IList)livro.Specifications.Genres;
                    foreach (var x in item)
                    {
                        if (x.ToString() == genero)
                        {
                            livrosDoGenero.Add(livro);
                        }
                    }
                }

            }
            return OrdenaLivroEncontrado(ordenado, livrosDoGenero);
        }


        public double CalculaFrete(string titulo)
        {
            var livroEscolhido = RetornaLivroPorNome(titulo, null);
            double frete = 0.0;
            foreach (var item in livroEscolhido)
            {
                frete = item.Price;
                frete = frete * 0.2;
            }

            return Math.Round(frete, 2);

        }

        public List<Book> RetornaLivroPorDataPublicao(string data, bool? ordenado)
        {
            var livros = _leJson.LeLivros();
            var paginasCorrespondente = livros.Where(livro => livro.Specifications.Originallypublished == data).ToList();
            return OrdenaLivroEncontrado(ordenado, paginasCorrespondente);
        }
    }
}
