using Api2.Controllers;
using Moq.AutoMock;
using Xunit;

namespace Api2.TestesUnitarios.Fixtures
{
    [CollectionDefinition(nameof(CalculaJurosControllerCollection))]
    public class CalculaJurosControllerCollection : ICollectionFixture<CalculaJurosControllerFixture>
    {
    }

    public class CalculaJurosControllerFixture
    {
        public AutoMocker Mocker { get; private set; }
        public CalculaJurosController CalculaJurosController { get; set; }

        public CalculaJurosController InstanciarController()
        {
            Mocker = new AutoMocker();
            CalculaJurosController = Mocker.CreateInstance<CalculaJurosController>();

            return CalculaJurosController;
        }
    }
}