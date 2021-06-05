using Api2.Aplicacao.Servico;
using Moq.AutoMock;
using Xunit;

namespace Api2.TestesUnitarios.Fixtures
{
    [CollectionDefinition(nameof(CalculaJurosServicoCollection))]
    public class CalculaJurosServicoCollection : ICollectionFixture<CalculaJurosServicoFixture>
    {
    }

    public class CalculaJurosServicoFixture
    {
        public AutoMocker Mocker { get; private set; }
        public CalculaJurosServico CalculaJurosServico { get; set; }

        public CalculaJurosServico InstanciarServico()
        {
            Mocker = new AutoMocker();
            CalculaJurosServico = Mocker.CreateInstance<CalculaJurosServico>();

            return CalculaJurosServico;
        }
    }
}