

using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DDD.Application.Service
{
    /// <summary>
    /// Classe responsável por orquestrar o envio de um relatório
    /// por email para uma lista de pessoas (passados por parâmetro) 
    /// e também definindo o tipo de disciplina (se EAD ou não)
    /// contendo os emails dos alunos com as melhores notas (acima de 8,0).
    /// </summary>
    public class ApplicationServiceRelatorioNotasDestaque
    {
        readonly RelatorioNotasDestaqueService _relatorioService;

        public ApplicationServiceRelatorioNotasDestaque(RelatorioNotasDestaqueService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public void EnviarRelatorio(List<string> emails, bool EAD)
        {
            //_relatorioService.BuscarAlunosDestaque(EAD);

            var listaDeAlunos = _relatorioService.BuscarAlunosDestaque(EAD);

            //https://mailtrap.io/inboxes/2481633/messages/3836509484
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("e231395539e28b", "d5a54a8c286cdb"),
                EnableSsl = true
            };

            StringBuilder listaDeEmails = new StringBuilder();
            if (listaDeAlunos is not null)
            {
                foreach (var item in listaDeAlunos)
                {
                    listaDeEmails.Append(item);
                }
            }
            client.Send("navarro.fabio@gmail.com", "navarro.fabio@gmail.com", "Emails", listaDeEmails.ToString());
        }
        
    }
}
