using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityModels;

namespace UniversityDtos.AlunoTurma;

public class CreateAlunoTurma
{
    public int? AlunoId { get; set; }
    public int? TurmaId { get; set; }
    public List<Aluno>? alunos { get; set; }
    public List<UniversityModels.Turma>? turmas { get; set; }
}
