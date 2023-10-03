using DDD.Infra.SQLServer.Interfaces;

namespace DDD.Domain.Service
{
    /// <summary>
    /// Classe responsável por fazer 
    /// </summary>
    public class MatriculaService
    {
        readonly IMatriculaRepository _matriculaRepository;


        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public bool EfetuarMatricula(int idAluno, int idDisc)
        {
            try
            {
                _matriculaRepository.InsertMatricula(idAluno, idDisc);
                return true;
            }
            catch (Exception ex) 
            {
                var erro = ex.Message;
                throw;
            }

        }

    }
}