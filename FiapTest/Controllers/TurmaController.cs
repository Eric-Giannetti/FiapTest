using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
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
        return View(result);
    }

    public IActionResult Create(Turma turma)
    {
        return View(turma);
    }
    public IActionResult Adicionar(Turma turma)
    {
        if (ModelState.IsValid)
        {
            _turmaBusinessRules.Inserir(turma);
            return RedirectToAction("Index", "Turma");
        }
        return View(turma);
    }
    public IActionResult Editar(int id)
    {
        var result = _turmaBusinessRules.GetById(id);
        return View(result.ValueOrDefault);
    }

    public IActionResult Edit(Turma turma)
    {
        var result = _turmaBusinessRules.Atualizar(turma);
        if (result.IsFailed) return View("Editar", turma);
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
