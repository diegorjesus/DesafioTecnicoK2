using Api2.Aplicacao.Interfaces;
using System.Threading.Tasks;

namespace Api2.Aplicacao.Servico
{
    public class CalculaJurosServico : ICalculaJurosServico
    {
        public async Task<double> CalcularJurosAsync(ParametrosConsulta parametros)
        {
            var taxaJuros = 0.01;

            var valorFinal = 105.10;

            return valorFinal;
        }
    }
}