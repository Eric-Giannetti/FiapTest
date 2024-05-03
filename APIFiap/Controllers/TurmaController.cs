using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityModels;

namespace APIFiap.Controllers;

public class TurmaController : Controller
{
    private TurmaBusinessRules _turmaBusinessRules;
    public TurmaController(TurmaBusinessRules turmaBusinessRules)
    {
        _turmaBusinessRules = turmaBusinessRules;
    }
    [HttpPost("Create")]
    public IActionResult CreateTurma([FromBody] Turma turma)
    {
        if (ModelState.IsValid == false) return BadRequest(ModelState);

        var result = _turmaBusinessRules.Inserir(turma);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return Created();
    }

    [HttpPut("Edit")]
    public IActionResult Edit([FromBody] Turma turma)
    {
        if (ModelState.IsValid == false) return BadRequest(ModelState);

        var result = _turmaBusinessRules.Atualizar(turma);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _turmaBusinessRules.Deletar(id);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return NoContent();
    }
    [HttpPatch("Reativar/{id}")]
    public IActionResult Reativar(int id)
    {
        var result = _turmaBusinessRules.Reativar(id);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = _turmaBusinessRules.GetAll();
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        if (result.ValueOrDefault == null) return NotFound();
        return Ok(result.ValueOrDefault);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var result = _turmaBusinessRules.GetById(id);
        if (result.IsFailed) return BadRequest(result.Errors[0].Message);
        if (result.ValueOrDefault == null) return NotFound();
        return Ok(result.ValueOrDefault);
    }
}
