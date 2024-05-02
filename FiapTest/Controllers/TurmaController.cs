using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;

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
        var result = _turmaBusinessRules.GetAll();
        return View(result);
    }
}
