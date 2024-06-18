using TesteAudaz.Models;
namespace TesteAudaz.Services
{
    public class OperatorService
    {
        private readonly Repository _repository = new Repository();

        public OperatorService(Repository repository)
        {
            _repository = repository;
        }

        public Operator GetOperatorByCode(string code)
        {
            var operators = _repository.GetAll<Operator>();
            return operators.FirstOrDefault(o => o.Code == code);
        }

        public Operator GetOperatorById(Guid id)
        {
            return _repository.GetById<Operator>(id);
        }

        public List<Operator> GetOperators()
        {
            return _repository.GetAll<Operator>();
        }

        public void Create(Operator insertingOperator)
        {
            var existingOperator = GetOperatorByCode(insertingOperator.Code);
            if (existingOperator != null)
            {
                throw new Exception($"Já existe um operador com o código '{insertingOperator.Code}'");
            }

            insertingOperator.Id = Guid.NewGuid(); // Certifique-se de definir o Id
            _repository.Insert(insertingOperator);
        }

        public void Update(Operator updatingOperator)
        {
            _repository.Update(updatingOperator);
        }
    }
}
