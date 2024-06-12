using GestaoPortfolioInvestimentos.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GestaoPortfolioInvestimentos.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoPortfolioInvestimentos.Application.Services
{
    public class NotificacaoProdutoVencimentoService : INotificacaoProdutoVencimentoService
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;
        public NotificacaoProdutoVencimentoService(IProdutoFinanceiroService produtoFinanceiroService)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
        }

        public void EnviarEmailNotificacao(string destinatario, string assunto, string corpo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.seuservidor.com");

                mail.From = new MailAddress("seuemail@seuservidor.com");
                mail.To.Add(destinatario);
                mail.Subject = assunto;
                mail.Body = corpo;

                smtpServer.Port = 587; // ou a porta usada pelo seu servidor SMTP
                smtpServer.Credentials = new NetworkCredential("seuemail@seuservidor.com", "suasenha");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                // Lógica de tratamento de erro
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> ProdutosAVencer()
        {
                return await _produtoFinanceiroService.ProdutosAVencer();
        }
    }
}
