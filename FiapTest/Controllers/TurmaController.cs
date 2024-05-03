using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityModels;

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
        var result = new List<Turma>();
        var lista = _turmaBusinessRules.GetAll().ValueOrDefault;
        if(lista != null)
            result = lista.ToList();

        return View(result);
    }

    public IActionResult Create(Turma turma)
    {
        if (turma != null && turma.NomeTurma != null)
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
