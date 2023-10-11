

using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;

namespace DDD.Application.Service
{
    /// <summary>
    /// Classe responsável por orquestrar a geração de um boletim, chamando 
    /// os métodos da Domain Service e outros que não são 
    /// triviais para o domínio.
    /// 
    /// </summary>
    public class ApplicationServiceBoletim
    {
        readonly BoletimService _boletimService;

        public ApplicationServiceBoletim(BoletimService boletimService)
        {
            _boletimService = boletimService;
        }

        public void GerarBoletim(List<DisciplinaNota> disciplinaNotas, int idAluno)
        {

            var matriculaEfetuada = _boletimService.GerarBoletim(disciplinaNotas, idAluno);
            if (matriculaEfetuada)
            {
                //Enviar email
            }
        }
    }
}
