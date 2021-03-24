using System.Collections.Generic;
using Teste.Domain.Model;

namespace Teste.Domain.Interfaces
{
    public interface IBooksService
    {
        List<Book> RetornaLivroPorNome(string titulo, bool? ordenado);

        List<Book> RetornaLivroPorPreco(double valor, bool? ordenado);

        List<Book> RetornaLivroPorAutor(string autor, bool? ordenado);

        List<Book> RetornaLivroPorTotalPaginas(int paginas, bool? ordenado);

        List<Book> RetornaLivroPorIlustrador(string ilustrador, bool? ordenado);

        List<Book> RetornaLivroPorGenero(string genero, bool? ordenado);

        List<Book> RetornaLivroPorDataPublicao(string data, bool? ordenado);

        double CalculaFrete(string titulo);
    }
}
