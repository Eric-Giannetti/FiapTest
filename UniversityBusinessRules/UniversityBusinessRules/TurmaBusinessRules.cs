﻿using InterfacesProject;
using UniversityModels;
using ConnectionDataBase.University;
using FluentResults;
using UniversityDtos.AlunoTurma;

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
        if (Id == 0) return Result.Fail("Id inválido");
        return _turmaProvider.Deletar(Id);
    }
    public Result Reativar(int Id)
    {
        if (Id == 0) return Result.Fail("Id inválido");
        return _turmaProvider.Reativar(Id);
    }

    public Result<List<Turma>> GetAll()
    {
        return _turmaProvider.GetAll();
    }

    public Result<Turma> GetById(int id)
    {
        if (id == 0) return Result.Fail<Turma>("Id inválido");
        return _turmaProvider.GetById(id);
    }

    public Result Inserir(Turma obj)
    {
        if (obj is null) return Result.Fail("Objeto inválido");
        if (obj.NomeTurma == null) return Result.Fail("Nome inválido");
        var ExistTurma = _turmaProvider.VerificarTurmaExistente(obj.NomeTurma);
        if (ExistTurma) return Result.Fail("Turma já existe");
        if (obj.Ano < DateTime.Now.Year) return Result.Fail("Data de início não pode ser maior que a data de fim");

        return _turmaProvider.Inserir(obj);
    }

    public Result<List<AlunoTurma>> GetAllTurmasWithAlunos()
    {
        var result = new List<AlunoTurma>();
        result = _turmaProvider.GetAllTurmasWithAlunos().ValueOrDefault;

        return Result.Ok(result);
    }
    public Result AddAlunoTurma(AlunoTurma alunoTurma)
    {
        if (alunoTurma.AlunoId == 0 || alunoTurma.TurmaId == 0) return Result.Fail("Id inválido");

        var exist = _turmaProvider.VerificarAlunoTurmaExistente(alunoTurma.AlunoId.Value, alunoTurma.TurmaId.Value);
        if (exist) return Result.Fail("Aluno já cadastrado na turma");
        return _turmaProvider.AddAlunoTurma(alunoTurma);
    }
    public Result DeleteAlunoTurma(int TurmaId, int AlunoId)
    {
        _turmaProvider.DeleteAlunoTurma(TurmaId, AlunoId);
        return Result.Ok();
    }
    public Result<List<AlunoTurma>> GetAlunoTurmaByAlunoId(int AlunoId)
    {
        if (AlunoId == 0) return Result.Fail("Id inválido");
        return _turmaProvider.GetAlunoTurmaByAlunoId(AlunoId);
    }
    public Result<List<AlunoTurma>> GetAlunoTurmaByTurmaId(int TurmaId)
    {
        if (TurmaId == 0) return Result.Fail("Id inválido");
        return _turmaProvider.GetAlunoTurmaByTurmaId(TurmaId);
    }
}