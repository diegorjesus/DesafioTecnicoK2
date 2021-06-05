using Api2.Aplicacao.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api2.Aplicacao.ServicosExternos
{
    public class TaxaJuros : ITaxaJuros
    {
        private readonly IHttpClientFactory _fabricaCliente;

        public TaxaJuros(IHttpClientFactory fabricaCliente)
        {
            _fabricaCliente = fabricaCliente;
        }

        public async Task<double> BuscarTaxaJurosAsync(string url)
        {
            var cliente = _fabricaCliente.CreateClient();

            HttpResponseMessage resposta = await cliente.GetAsync(url);

            if (resposta.IsSuccessStatusCode)
            {
                var responseStream = await resposta.Content.ReadAsStreamAsync();
                var taxaJuros = await JsonSerializer.DeserializeAsync<double>(responseStream);

                return taxaJuros;
            }
            else
            {
                throw new Exception($"Um erro ocorreu ao comunicar com servico externo. StatusCode: {resposta.StatusCode}");
            }
        }
    }
}