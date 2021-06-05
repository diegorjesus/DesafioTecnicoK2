using System.Threading.Tasks;

namespace Api2.Aplicacao.Interfaces
{
    public interface ICalculaJurosServico
    {
        Task<double> CalcularJurosAsync(ParametrosConsulta parametros);
    }
}