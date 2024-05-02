using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityModels.Enum;

namespace UniversityModels;

public class Turma
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public string NomeTurma { get; set; }
    public int Ano { get; set; }
}
