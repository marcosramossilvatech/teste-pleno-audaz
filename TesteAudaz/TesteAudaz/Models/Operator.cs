namespace TesteAudaz.Models
{
    public class Operator : IModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }

    }
}
