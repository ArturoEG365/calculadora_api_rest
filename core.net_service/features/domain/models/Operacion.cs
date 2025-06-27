namespace Domain.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public double Resultado { get; set; }
        public DateTime FechaOperacion { get; set; }
    }
}