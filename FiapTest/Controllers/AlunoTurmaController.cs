using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityDtos.AlunoTurma;

namespace FiapTest.Controllers;

public class AlunoTurmaController : Controller
{
    private AlunoBusinessRules _alunoBusinessRules;
    private TurmaBusinessRules _turmaBusinessRules;
    public AlunoTurmaController(AlunoBusinessRules alunoBusinessRules, TurmaBusinessRules turmaBusinessRules)
    {
        _alunoBusinessRules = alunoBusinessRules;
        _turmaBusinessRules = turmaBusinessRules;
    }


    public IActionResult Index()
    {
       List<AlunoTurmaDto> result = new List<AlunoTurmaDto>();
        var alunoTurmas = _turmaBusinessRules.GetAllTurmasWithAlunos();

        foreach(var item in alunoTurmas.ValueOrDefault)
        {
            result.Add(new AlunoTurmaDto
            {
                aluno = _alunoBusinessRules.GetById(item.AlunoId).ValueOrDefault,
                turma = _turmaBusinessRules.GetById(item.TurmaId).ValueOrDefault
            });
        }
        return View(result);
    }
}
