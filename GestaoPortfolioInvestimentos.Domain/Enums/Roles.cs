using System.Runtime.Serialization;

namespace GestaoPortfolioInvestimentos.Domain.Enums
{
    public enum Roles
    {
        [EnumMember(Value = "admin")]
        admin,
        [EnumMember(Value = "client")]
        client
    }
}
