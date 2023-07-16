namespace myfinance_web_dotnet.Domain
{
    public class Transacao : EntityBase
    {
        public DateTime Data {get; set;}
        public decimal Valor {get; set;}
        public string Historico {get; set;}
        public int PlanoContaId {get; set;}
        public PlanoConta PlanoConta{get; set;}
    }
}