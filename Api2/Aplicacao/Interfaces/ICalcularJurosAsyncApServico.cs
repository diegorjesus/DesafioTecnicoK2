using System.Threading.Tasks;

namespace Api2.Aplicacao.Interfaces
{
    public interface ICalcularJurosAsyncApServico
    {
        Task<double> CalcularJurosAsync(ParametrosConsulta parametros);
    }
}