using System.Threading.Tasks;

namespace Api2.Application.Interfaces
{
    public interface ICalcularJurosAsyncAppService
    {
        Task<decimal> CalcularJurosAsync(ParametrosConsulta parametros);
    }
}