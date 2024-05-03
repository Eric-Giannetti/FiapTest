using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityDtos.AlunoTurma;
using UniversityModels;

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
        var alunoTurmas = _turmaBusinessRules.GetAllTurmasWithAlunos().ValueOrDefault;

        if(alunoTurmas != null)
        {
            foreach(var item in alunoTurmas)
            {
                result.Add(new AlunoTurmaDto
                {
                    aluno = _alunoBusinessRules.GetById(item.AlunoId).ValueOrDefault,
                    turma = _turmaBusinessRules.GetById(item.TurmaId).ValueOrDefault
                });
            }
        }

        return View(result);
    }

    public IActionResult Create(AlunoTurmaDto alunoTurma)
    {
        var item = new AlunoTurma { AlunoId = alunoTurma.aluno.Id, TurmaId = alunoTurma.turma.Id };
        _turmaBusinessRules.AddAlunoTurma(item);
        return View();
    }
    public IActionResult Adicionar(AlunoTurma obj)
    {
        _turmaBusinessRules.AddAlunoTurma(obj);
        return RedirectToAction("Index", "AlunoTurmaDto");
    }

    public IActionResult Excluir(int Id)
    {
        _turmaBusinessRules.DeleteAlunoTurma(Id);
        return RedirectToAction("Index", "AlunoTurmaDto");
    }
}
