using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityModels;

namespace FiapTest.Controllers;

public class AlunoController : Controller
{
    private AlunoBusinessRules _alunoBusinessRules;
    public AlunoController(AlunoBusinessRules alunoBusinessRules)
    {
        _alunoBusinessRules = alunoBusinessRules;
    }

    public IActionResult Index()
    {
        var result = new List<Aluno>();
        var list = _alunoBusinessRules.GetAll().ValueOrDefault;
        if (list != null)
            result = list.ToList();

        return View(result);
    }
    public IActionResult Create(Aluno aluno)
    {
        return View(aluno);
    }
    public IActionResult Adicionar(Aluno aluno)
    {
        if (ModelState.IsValid)
        {
            _alunoBusinessRules.Inserir(aluno);
            return RedirectToAction("Index", "Aluno");
        }
        return View(aluno);
    }

    public IActionResult Editar(int id)
    {
        var result = _alunoBusinessRules.GetById(id);
        return View(result.ValueOrDefault);
    }

    public IActionResult Edit(Aluno aluno)
    {
        var result = _alunoBusinessRules.Atualizar(aluno);
        return RedirectToAction("Index", "Aluno");
    }

    public IActionResult Desativar(int id)
    {
        var result = _alunoBusinessRules.Deletar(id);
        return RedirectToAction("Index", "Aluno");
    }
    
    public IActionResult Reativar(int id)
    {
        var result = _alunoBusinessRules.Reativar(id);
        return RedirectToAction("Index", "Aluno");
    }
}
