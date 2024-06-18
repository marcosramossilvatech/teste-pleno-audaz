using TesteAudaz.Models;
using TesteAudaz.Services;

namespace TesteAudaz.Controller
{
    public class FareController
    {
        private readonly OperatorService _operatorService;
        private readonly FareService _fareService;

        public FareController(OperatorService operatorService, FareService fareService)
        {
            _operatorService = operatorService;
            _fareService = fareService;
        }

        public void CreateOperator(Operator operatorEntity)
        {
            _operatorService.Create(operatorEntity);
        }
        public List<Operator> GetOperatoras()
        {
           return _operatorService.GetOperators();
        }
        public bool CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if (selectedOperator == null)
                throw new Exception("Operadora não encontrada");

            fare.OperatorId = selectedOperator.Id;

            if (!CanCreateFare(fare))
                return false;
              

            _fareService.Create(fare);

            return true;
        }
        public List<Fare> GetFares()
        {
            var fares = _fareService.GetFares();
            var operators = _operatorService.GetOperators();

            var operatorDictionary = operators.ToDictionary(op => op.Id, op => op);

            fares.ForEach(fare => fare.CodeOperador = operatorDictionary.TryGetValue(fare.OperatorId, out var operatorInfo) ? operatorInfo.Code : fare.CodeOperador);

            return fares;
        }
        private bool CanCreateFare(Fare newFare)
        {
            var fares = _fareService.GetFaresByOperatorId(newFare.OperatorId);
            var sixMonthsAgo = DateTime.Now.AddMonths(-6);

            return !fares.Any(f => f.Value == newFare.Value && f.Status == 1 && f.CreatedAt >= sixMonthsAgo);
        }      
    }
}
