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
        var result = _alunoBusinessRules.GetAll();
        return View(result.ValueOrDefault);
    }
    public IActionResult Create(Aluno aluno)
    {
        if (aluno != null)
            _alunoBusinessRules.Inserir(aluno);

        return View();
    }
    public IActionResult Editar(int id)
    {
        var result = _alunoBusinessRules.GetById(id);
        return View(result.ValueOrDefault);
    }

    public IActionResult Desativar(int id)
    {
        var result = _alunoBusinessRules.Deletar(id);
        return View();
    }
    
    public IActionResult Reativar(int id)
    {
        var result = _alunoBusinessRules.Reativar(id);
        return View();
    }
}
