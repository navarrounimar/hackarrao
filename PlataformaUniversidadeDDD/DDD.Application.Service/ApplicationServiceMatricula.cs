using DDD.Domain.Service;

namespace DDD.Application.Service
{
    /// <summary>
    /// Classe responsável por orquestrar uma matricula, chamando 
    /// os métodos da Domain Service e outros que não são 
    /// triviais para o domínio.
    /// 
    /// Nesse caso, além de realizar uma matrícula serviço deve
    /// enviar um email confirmando a matrícula, que é um serviço de 
    /// infra.
    /// </summary>
    public class ApplicationServiceMatricula
    {
        readonly MatriculaService _matriculaService;

        public ApplicationServiceMatricula(MatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        public void EfetuarMatriculaApplicationService(int idAluno, int idDisc)
        {
            var matriculaEfetuada = _matriculaService.EfetuarMatricula(idAluno, idDisc);
            if (matriculaEfetuada)
            {
                //Enviar email
            }
        }
    }
}