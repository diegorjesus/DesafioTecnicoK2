using Api2.Aplicacao.Interfaces;
using System;
using System.Threading.Tasks;

namespace Api2.Aplicacao.Servico
{
    public class CalculaJurosServico : ICalculaJurosServico
    {
        public async Task<double> CalcularJurosAsync(ParametrosConsulta parametros)
        {
            var taxaJuros = 0.01;

            var valorFinal = CalcularJurosCompostos(taxaJuros, parametros.ValorInicial, parametros.Tempo);

            return valorFinal;
        }

        private double CalcularJurosCompostos(double taxaJuros, double valorInicial, int tempo)
        {
            var valorFinal = Math.Pow((1 + taxaJuros), tempo) * valorInicial;

            return Math.Round(valorFinal, 2, MidpointRounding.ToZero);
        }
    }
}