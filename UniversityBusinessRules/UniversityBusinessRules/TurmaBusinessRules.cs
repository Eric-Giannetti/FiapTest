using InterfacesProject;
using UniversityModels;
using ConnectionDataBase.University;
using FluentResults;

namespace UniversityBusinessRules.UniversityBusinessRules;

public class TurmaBusinessRules : ICrud<Turma>
{
    private TurmaProvider _turmaProvider;
    public TurmaBusinessRules(TurmaProvider turmaProvider)
    {
        _turmaProvider = turmaProvider;
    }


    public Result Atualizar(Turma obj)
    {
        if (obj is null || obj.Id == 0) return Result.Fail("Id inválido");
        if (obj.Ano < DateTime.Now.Year) return Result.Fail("Data de início não pode ser maior que a data de fim");
        return _turmaProvider.Atualizar(obj);
    }

    public Result Deletar(int Id)
    {
        return _turmaProvider.Deletar(Id);
    }
    public Result Reativar(int Id)
    {
        return _turmaProvider.Reativar(Id);
    }

    public Result<List<Turma>> GetAll()
    {
        return _turmaProvider.GetAll();
    }

    public Result<Turma> GetById(int id)
    {
        return _turmaProvider.GetById(id);
    }

    public Result Inserir(Turma obj)
    {
        var ExistTurma = _turmaProvider.VerificarTurmaExistente(obj.NomeTurma);
        if (ExistTurma) return Result.Fail("Turma já existe");
        if (obj.Ano < DateTime.Now.Year) return Result.Fail("Data de início não pode ser maior que a data de fim");

        return _turmaProvider.Inserir(obj);
    }
}
