using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityModels;

namespace APIFiap.Controllers
{
    public class AlunoTurmaController : Controller
    {
        private AlunoBusinessRules _alunoBusinessRules;
        private TurmaBusinessRules _turmaBusinessRules;

        public AlunoTurmaController(AlunoBusinessRules alunoBusinessRules, TurmaBusinessRules turmaBusinessRules)
        {
            _alunoBusinessRules = alunoBusinessRules;
            _turmaBusinessRules = turmaBusinessRules;
        }

        [HttpPost("Create")]
        public IActionResult CreateAlunoTurma([FromBody] AlunoTurma alunoTurma)
        {
            var result = _turmaBusinessRules.AddAlunoTurma(alunoTurma);
            if (result.IsFailed) return BadRequest(result.Errors[0].Message);
            return Created();
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _turmaBusinessRules.DeleteAlunoTurma(id);
            return NoContent();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _turmaBusinessRules.GetAllTurmasWithAlunos();
            if (result.IsFailed) return BadRequest(result.Errors[0].Message);
            if (result.ValueOrDefault == null) return NotFound();
            return Ok(result.ValueOrDefault);
        }

        [HttpGet("GetByTurmaId/{id}")]
        public IActionResult GetByTurmaId(int id)
        {
            Result<List<AlunoTurma>> result = _turmaBusinessRules.GetAlunoTurmaByTurmaId(id);
            if (result.IsFailed) return BadRequest(result.Errors[0].Message);
            if (result.ValueOrDefault == null) return NotFound();
            return Ok(result.ValueOrDefault);
        }

        [HttpGet("GetByAlunoId/{id}")]
        public IActionResult GetByAlunoId(int id)
        {
            Result<List<AlunoTurma>> result = _turmaBusinessRules.GetAlunoTurmaByAlunoId(id);
            if (result.IsFailed) return BadRequest(result.Errors[0].Message);
            if (result.ValueOrDefault == null) return NotFound();
            return Ok(result.ValueOrDefault);
        }
    }
}
