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

    [HttpPost("Create")]
    public IActionResult CreateAluno([FromBody]Aluno aluno)
    {
        var result = _alunoBusinessRules.Inserir(aluno);
        if(result.IsFailed) return BadRequest(result.Errors[0].Message);
        return Created();
    }

    [HttpPut("Edit")]
    public IActionResult Edit([FromBody] Aluno aluno)
    {
        var result = _alunoBusinessRules.Atualizar(aluno);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _alunoBusinessRules.Deletar(id);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return NoContent();
    }
    [HttpDelete("Reativar/{id}")]
    public IActionResult Reativar(int id)
    {
        var result = _alunoBusinessRules.Reativar(id);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = _alunoBusinessRules.GetAll();
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        if(result.ValueOrDefault == null) return NotFound();
        return Ok(result.ValueOrDefault);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var result = _alunoBusinessRules.GetById(id);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        if(result.ValueOrDefault == null) return NotFound();
        return Ok(result.ValueOrDefault);
    }
}
