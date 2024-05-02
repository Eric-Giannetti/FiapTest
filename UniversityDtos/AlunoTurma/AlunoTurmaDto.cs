using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityModels;

namespace UniversityDtos.AlunoTurma;

public class AlunoTurmaDto
{
    public int Id { get; set; }
    public Aluno aluno { get; set; }
    public Turma turma { get; set; }
    public bool IsDeleted { get; set; } = false;
}
