using DDD.Application.Service;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly IAlunoRepository _alunoRepository;
        readonly ApplicationServiceBoletim  _boletimService;

        public AlunoController(IAlunoRepository alunoRepository, ApplicationServiceBoletim applicationServiceBoletim)
        {
            _alunoRepository = alunoRepository;
            _boletimService= applicationServiceBoletim;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(_alunoRepository.GetAlunos());
        }



        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_alunoRepository.GetAlunoById(id));
        }

        [HttpPost]
        [Route("gerarBoletim")]
        public void EfetuarMatriculaApplicationService(List<DisciplinaNota> disciplinaNotas, int idAluno)
        {
            _boletimService.GerarBoletim(disciplinaNotas.ToList(), idAluno);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Aluno> CreateAluno(Aluno aluno)
        {
            if (aluno.Nome.Length < 3 || aluno.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _alunoRepository.InsertAluno(aluno);
            return CreatedAtAction(nameof(GetById), new { id = aluno.UserId }, aluno);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return NotFound();

                _alunoRepository.UpdateAluno(aluno);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return NotFound();

                _alunoRepository.DeleteAluno(aluno);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
