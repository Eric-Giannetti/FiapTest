using Dapper;
using FluentResults;
using InterfacesProject;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityModels;

namespace ConnectionDataBase.University;

public class AlunoProvider : ICrud<Aluno>
{
    private readonly string _connectionString;
    public AlunoProvider(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("MySqlConnectionString");
    }

    public Result Atualizar(Aluno obj)
    {
        try
        {
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    public Result Deletar(int Id)
    {
        try
        {
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    public Result<List<Aluno>> GetAll()
    {
        try
        {
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    public Result<Aluno> GetById(int id)
    {
        try
        {
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    public Result Inserir(Aluno obj)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO Aluno(Nome, Usuario, Senha) VALUES (@Nome, @Usuario, @Senha)";
                connection.Execute(query, obj);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public Result Reativar(int id)
    {
        try
        {
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}
