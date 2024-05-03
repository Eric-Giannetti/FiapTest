using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityModels.Enum;

namespace UniversityModels;

public class Turma
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O Curso é obrigatório.")]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string NomeTurma { get; set; }
    [Required(ErrorMessage = "O campo Ano é obrigatório.")]
    public int Ano { get; set; }
    public bool IsDeleted { get; set; }
}
