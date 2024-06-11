using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class ClienteInvestimentoDto
    {
        public int ProdutoFinanceiroId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public int Quantidade { get; set; }
    }
}
