using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Interfaces
{
    public interface INotificacaoProdutoVencimentoService
    {
        void EnviarEmailNotificacao(string destinatario, string assunto, string corpo);
        Task<IEnumerable<ProdutoFinanceiro>> ProdutosAVencer();
    }
}
