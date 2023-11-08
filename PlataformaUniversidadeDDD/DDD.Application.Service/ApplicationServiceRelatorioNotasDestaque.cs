

using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;

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

            var listaDeAlunos = _boletimService.GerarBoletim(disciplinaNotas, idAluno);
            if (listaDeAlunos is not null)
            {
                //Enviar email
            }
        }
    }
}
