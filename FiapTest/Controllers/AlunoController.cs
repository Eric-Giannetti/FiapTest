using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;
using UniversityDtos;
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

        var retorno = new RetornoDto<List<Aluno>> { Object = result };
        return View(retorno);
    }
    public IActionResult Create(RetornoDto<Aluno> aluno)
    {
        return View(aluno);
    }
    public IActionResult Adicionar(RetornoDto<Aluno> aluno)
    {

        var result = _alunoBusinessRules.Inserir(aluno.Object);
        if (result.IsFailed)
        {
            return RedirectToAction("Create", "Aluno", new RetornoDto<Aluno> { ErrorMessage = result.Errors[0].Message, IsFailed = true });
        }
        return RedirectToAction("Index", "Aluno");

    }

    public IActionResult Editar(int obj)
    {
        var result = _alunoBusinessRules.GetById(obj).ValueOrDefault;
        var retorno = new RetornoDto<Aluno> { Object = result };
        return View(retorno);
    }

    public IActionResult Edit(RetornoDto<Aluno> aluno)
    {

        var result = _alunoBusinessRules.Atualizar(aluno.Object);
        if (result.IsFailed)
        {
            return RedirectToAction("Editar", "Aluno", aluno.Object.Id);
        }
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
