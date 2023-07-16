using System.ComponentModel.DataAnnotations;

namespace myfinance_web_dotnet.Domain
{
    public class EntityBase
    {
     [Key]
        public int? Id {get; set;}
    }
}