using Microsoft.AspNetCore.Mvc;
using UniversityBusinessRules.UniversityBusinessRules;

namespace APIFiap.Controllers;

public class TurmaController : Controller
{
    private TurmaBusinessRules _turmaBusinessRules;
    public TurmaController(TurmaBusinessRules turmaBusinessRules)
    {
        _turmaBusinessRules = turmaBusinessRules;
    }
    public IActionResult Index()
    {
        return View();
    }
}
