using Api2.Aplicacao.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Api2.Aplicacao.Servico
{
    public class CalculaJurosServico : ICalculaJurosServico
    {
        private readonly IConfiguration config;
        private readonly ITaxaJuros servicoExternoTaxaJuros;

        public CalculaJurosServico(IConfiguration config, ITaxaJuros servicoExternoTaxaJuros)
        {
            this.config = config;
            this.servicoExternoTaxaJuros = servicoExternoTaxaJuros;
        }

        public async Task<double> CalcularJurosAsync(ParametrosConsulta parametros)
        {
            var url = config["Urls:UrlApi1"];

            var taxaJuros = await servicoExternoTaxaJuros.BuscarTaxaJurosAsync(url);

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