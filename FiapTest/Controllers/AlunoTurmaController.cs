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

        if (alunoTurmas != null)
        {
            foreach (var item in alunoTurmas)
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
        var result = new CreateAlunoTurma
        {
            alunos = _alunoBusinessRules.GetAll().ValueOrDefault,
            turmas = _turmaBusinessRules.GetAll().ValueOrDefault
        };
        return View(result);
    }
    public IActionResult Adicionar(CreateAlunoTurma obj)
    {
        var alunoTurma = new AlunoTurma { AlunoId = obj.AlunoId, TurmaId = obj.TurmaId };
        _turmaBusinessRules.AddAlunoTurma(alunoTurma);
        return RedirectToAction("Index", "AlunoTurma");
    }

    public IActionResult Excluir(int Id)
    {
        _turmaBusinessRules.DeleteAlunoTurma(Id);
        return RedirectToAction("Index", "AlunoTurmaDto");
    }
}
