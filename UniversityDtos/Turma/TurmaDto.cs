using UniversityModels.Enum;

namespace UniversityDtos.Turma;

public class TurmaDto
{
    public int Id { get; set; }
    public CursoEnum Curso { get; set; }
    public string NomeTurma { get; set; }
    public int Ano { get; set; }
    public bool IsDeleted { get; set; }
}
