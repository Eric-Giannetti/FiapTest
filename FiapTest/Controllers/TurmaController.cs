using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityDtos.AlunoTurma;
using UniversityDtos;
using UniversityDtos.Turma;
using UniversityModels;
using UniversityModels.Enum;

namespace FiapTest.Controllers;

public class TurmaController : Controller
{
    private TurmaBusinessRules _turmaBusinessRules;
    public TurmaController(TurmaBusinessRules turmaBusinessRules)
    {
        _turmaBusinessRules = turmaBusinessRules;
    }

    public IActionResult Index()
    {
        var result = new List<TurmaDto>();
        var lista = _turmaBusinessRules.GetAll().ValueOrDefault;
        if (lista != null)
        {
            foreach (var item in lista)
            {
                result.Add(new TurmaDto
                {
                    Id = item.Id,
                    Curso = (CursoEnum)item.CursoId,
                    NomeTurma = item.NomeTurma,
                    Ano = item.Ano,
                    IsDeleted = item.IsDeleted
                });
            }
        }
        var retorno = new RetornoDto<List<TurmaDto>> { Object = result };
        return View(retorno);
    }

    public IActionResult Create(RetornoDto<Turma> turma)
    {
        return View(turma);
    }
    public IActionResult Adicionar(RetornoDto<Turma> turma)
    {
            var result = _turmaBusinessRules.Inserir(turma.Object);
        if (result.IsFailed)
        {
            return RedirectToAction("Create", "Turma", new RetornoDto<Turma> { ErrorMessage = result.Errors[0].Message, IsFailed = true });
        }
        return RedirectToAction("Index", "Turma");
    }
    public IActionResult Editar(int obj)
    {
        var result = _turmaBusinessRules.GetById(obj).ValueOrDefault;
        var retorno = new RetornoDto<Turma> { Object = result };
        return View(retorno);
    }

    public IActionResult Edit(RetornoDto<Turma> turma)
    {
        var result = _turmaBusinessRules.Atualizar(turma.Object);
        if (result.IsFailed)
        {
            return RedirectToAction("Editar", "Turma", new RetornoDto<Turma> { Object = turma.Object,  ErrorMessage = result.Errors[0].Message, IsFailed = true });
        }
        return RedirectToAction("Index", "Turma");
    }

    public IActionResult Desativar(int id)
    {
        var result = _turmaBusinessRules.Deletar(id);
        return RedirectToAction("Index", "Turma");
    }

    public IActionResult Reativar(int id)
    {
        var result = _turmaBusinessRules.Reativar(id);
        return RedirectToAction("Index", "Turma");
    }

}
