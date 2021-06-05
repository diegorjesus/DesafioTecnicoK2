using System.Net.Http;
using System.Threading.Tasks;

namespace Api2.Aplicacao.Interfaces
{
    public interface ITaxaJuros
    {
        Task<double> BuscarTaxaJurosAsync(string url);
    }
}