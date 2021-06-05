using System.ComponentModel.DataAnnotations;

namespace Api2
{
    public class ParametrosConsulta
    {
        public double ValorInicial { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Valor deve ser maior ou igual a 0")]
        public int Tempo { get; set; }
    }
}