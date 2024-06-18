using TesteAudaz.Models;
namespace TesteAudaz.Services
{
    public class FareService
    {
        private readonly Repository _repository;

        public FareService(Repository repository)
        {
            _repository = repository;
        }

        public void Create(Fare fare)
        {
            fare.CreatedAt = DateTime.Now;
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            return _repository.GetById<Fare>(fareId);
        }

        public List<Fare> GetFares()
        {
            return _repository.GetAll<Fare>();
        }

        public List<Fare> GetFaresByOperatorId(Guid operatorId)
        {
            var fares = _repository.GetAll<Fare>();
            return fares.Where(f => f.OperatorId == operatorId).ToList();
        }
    }
}
