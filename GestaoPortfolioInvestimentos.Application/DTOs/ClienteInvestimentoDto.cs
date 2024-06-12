using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class ClienteInvestimentoDto
    {
        [Required(ErrorMessage = "O campo ProdutoFinanceiroId é obrigatório.")]
        public int ProdutoFinanceiroId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public int Quantidade { get; set; }
    }
}
