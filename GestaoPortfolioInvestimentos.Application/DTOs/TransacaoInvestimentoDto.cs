using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class TransacaoInvestimentoDto
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
    }
}
