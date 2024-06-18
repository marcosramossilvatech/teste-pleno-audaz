namespace TesteAudaz.Models
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public string CodeOperador { get; set; } = string.Empty;
        public int Status { get; set; } = 1;
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
