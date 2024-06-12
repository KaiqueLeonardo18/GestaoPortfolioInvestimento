using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Scheduler.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GestaoPortfolioInvestimentos.Application.DTOs;

namespace GestaoPortfolioInvestimentos.Scheduler.Service
{
    public class EnvioEmailService
    {
        private readonly HttpService _httpService;
        const string USER = "worker";
        const string USER_PASSWORD = "worker";
        const string EMAIL_DEFAULT = "worker@gmail.com";
        public EnvioEmailService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> EnvioEmail()
        {
            var token = GetToken(USER, USER_PASSWORD);
            var produtoList = await GetProdutosAVencerAsync();

            if(produtoList != null)
            {
                EnviarNotificacoesDiarias(produtoList);
            }
            return produtoList;
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> GetProdutosAVencerAsync()
        {
            return await _httpService.HttpGet<IEnumerable<ProdutoFinanceiro>>("api/ProdutoInvestimento/ProdutosAVencer");
        }

        private void EnviarEmailNotificacao(string destinatario, string assunto, string corpo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("kaiquesmtp@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = assunto;
                mail.Body = corpo;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("kaiquesmtp@gmail.com", "Gom3s2024@");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                Console.WriteLine("E-mail enviado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }

        public void EnviarNotificacoesDiarias(IEnumerable<ProdutoFinanceiro> produtos)
        {
            string destinatario = EMAIL_DEFAULT;
            string assunto = "Lista de produtos a vencer para os próximos 7 dias";
            string corpo = "Listagem dos produtos com vencimento nos próximos dias.";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(corpo);
            foreach(var produto in produtos) 
            {
                stringBuilder.AppendLine($"{produto.Nome} - {produto.DataVencimento}");
            }

            EnviarEmailNotificacao(destinatario, assunto, corpo);
        }
    }
}
