using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "O campo ProdutoId é obrigatório.")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public decimal Quantidade { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
    }
}
