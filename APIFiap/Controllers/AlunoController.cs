using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityModels;

namespace APIFiap.Controllers;

[Route("api/[controller]")]
public class AlunoController : Controller
{
    private AlunoBusinessRules _alunoBusinessRules;
    public AlunoController(AlunoBusinessRules alunoBusinessRules)
    {
        _alunoBusinessRules = alunoBusinessRules;
    }

    [HttpPost("CreateAluno")]
    public IActionResult CreateAluno([FromBody]Aluno aluno)
    {
        var result = _alunoBusinessRules.Inserir(aluno);
        if(result.IsFailed) return BadRequest(result.Errors[0].Message);
        return Ok();
    }
}
