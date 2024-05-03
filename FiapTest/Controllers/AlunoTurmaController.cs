using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityDtos;
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
        var retorno = new RetornoDto<List<AlunoTurmaDto>> { Object = result };
        return View(retorno);
    }

    public IActionResult Create(RetornoDto<AlunoTurmaDto> alunoTurma)
    {
        var result = new CreateAlunoTurma
        {
            alunos = _alunoBusinessRules.GetAll().ValueOrDefault.Where(a => !a.IsDeleted).ToList(),
            turmas = _turmaBusinessRules.GetAll().ValueOrDefault.Where(t => !t.IsDeleted).ToList()
        };
        var retorno = new RetornoDto<CreateAlunoTurma> { Object = result, ErrorMessage = alunoTurma.ErrorMessage};
        return View(retorno);
    }
    public IActionResult Adicionar(RetornoDto<CreateAlunoTurma> obj)
    {
        var alunoTurma = new AlunoTurma { AlunoId = obj.Object.AlunoId, TurmaId = obj.Object.TurmaId };
        var result = _turmaBusinessRules.AddAlunoTurma(alunoTurma);
        if (result.IsFailed)
        {
            return RedirectToAction("Create", "AlunoTurma", new RetornoDto<AlunoTurmaDto> { ErrorMessage = result.Errors[0].Message, IsFailed = true });
        }
        return RedirectToAction("Index", "AlunoTurma");
    }

    public IActionResult Excluir(int TurmaId, int AlunoId)
    {
        var result = _turmaBusinessRules.DeleteAlunoTurma(TurmaId, AlunoId);
        if (result.IsFailed)
        {
            return RedirectToAction("Index", "AlunoTurma", new RetornoDto<AlunoTurmaDto> { ErrorMessage = result.Errors[0].Message, IsFailed = true });
        }
        return RedirectToAction("Index", "AlunoTurma");
    }
}
