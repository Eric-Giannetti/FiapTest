using ConnectionDataBase.University;
using FluentResults;
using InterfacesProject;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UniversityModels;

namespace UniversityBusinessRules.UniversityBusinessRules;

public class AlunoBusinessRules : ICrud<Aluno>
{
    private AlunoProvider _alunoProvider;
    public AlunoBusinessRules(AlunoProvider alunoProvider)
    {
        _alunoProvider = alunoProvider;
    }

    public Result Inserir(Aluno obj)
    {
        if (obj is null) return Result.Fail("Objeto inválido");
        if (obj.Nome == null || obj.Nome.Length < 3) return Result.Fail("Nome inválido");
        if (obj.Senha != null)
        {
            if (!ValidarSenha(obj.Senha)) return Result.Fail("Senha inválida");
            obj.Senha = CalculateMD5Hash(obj.Senha);
        }
        else return Result.Fail("Senha inválida");


        return _alunoProvider.Inserir(obj);
    }

    public Result Atualizar(Aluno obj)
    {
        if (obj is null || obj.Id == 0) return Result.Fail("Id inválido");
        if (obj.Nome == null || obj.Nome.Length < 3) return Result.Fail("Nome inválido");
        if (obj.Senha != null)
        {
            if (!ValidarSenha(obj.Senha)) return Result.Fail("Senha inválida");
            obj.Senha = CalculateMD5Hash(obj.Senha);
        }


        return _alunoProvider.Atualizar(obj);
    }

    public Result Deletar(int Id)
    {
        if (Id == 0) return Result.Fail("Id inválido");
        return _alunoProvider.Deletar(Id);
    }
    public Result Reativar(int Id)
    {
        if (Id == 0) return Result.Fail("Id inválido");
        return _alunoProvider.Reativar(Id);
    }

    public Result<List<Aluno>> GetAll()
    {
        return _alunoProvider.GetAll();
    }

    public Result<Aluno> GetById(int Id)
    {
        if (Id == 0) return Result.Fail("Id inválido");
        return _alunoProvider.GetById(Id);
    }

    public static string CalculateMD5Hash(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            return BitConverter.ToString(hash).Replace("-", "").ToUpper();
        }
    }

    static bool ValidarSenha(string senha)
    {
        string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!?])(?=.*[a-zA-Z]).{8,}$";
        return Regex.IsMatch(senha, pattern);
    }

    public Result<List<Aluno>> GetAlunosByTurmaId(int TurmaId)
    {
        if (TurmaId == 0) return Result.Fail<List<Aluno>>("Turma Não Encontrada");
        return _alunoProvider.GetAlunosByTurmaId(TurmaId);
    }
}
