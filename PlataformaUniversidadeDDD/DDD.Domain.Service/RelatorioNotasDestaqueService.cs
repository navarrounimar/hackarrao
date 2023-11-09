using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;

namespace DDD.Domain.Service
{
    /// <summary>
    /// Classe responsável por buscar os alunos com notas de destaque.
    /// </summary>
    public class RelatorioNotasDestaqueService
    {
        readonly IMatriculaRepository _matriculaRepository;
        readonly IAlunoRepository _alunoRepository;
        readonly IDisciplinaRepository _disciplinaRepository;

        public RelatorioNotasDestaqueService(IMatriculaRepository matriculaRepository,
            IAlunoRepository alunoRepository, IDisciplinaRepository disciplinaRepository)
        {
            _matriculaRepository = matriculaRepository;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        /// <summary>
        /// busca alunos com notas acima de 8 (inclusive)
        /// <returns></returns>
        public List<string> BuscarAlunosDestaque(bool EAD)
        {
            List<string> emailsAlunos = new List<string>();
            try
            {

                var disciplinasEAD = _disciplinaRepository.GetDisciplinas().Where(x => x.Ead == EAD).ToList();
                var boletins = _alunoRepository.GetBoletins();

                var boletinsDisciplinaEad = (from b in boletins where 
                                             disciplinasEAD.Any(x => x.DisciplinaId == b.DisciplinaId && b.Nota >= 8) select b)
                                             .ToList();

                //var teste = boletinsDisciplinaEad.Where(f1 => _alunoRepository.GetAlunos().ToList().Any(f2 => f2.UserId == f1.Aluno.UserId)).ToList();

                foreach (var item in boletinsDisciplinaEad)
                {
                    var aluno = _alunoRepository.GetAlunos().ToList().Find(x => x.UserId == item.AlunoId);
                    emailsAlunos.Add(aluno.Email);
                }


                return emailsAlunos;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }

        }

    }
}
