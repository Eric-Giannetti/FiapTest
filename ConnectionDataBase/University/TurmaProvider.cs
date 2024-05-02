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

public class TurmaProvider : ICrud<Turma>
{
    private readonly string _connectionString;
    public TurmaProvider(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("MySqlConnectionString");
    }
    public Result Atualizar(Turma obj)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"UPDATE Turma SET ";

                if (obj.CursoId != null) query += $"CursoId = @CursoId";
                if (obj.NomeTurma != null) query += $"NomeTurma = @NomeTurma";
                if (obj.Ano != null) query += $"Ano = @Ano";

                query += $" WHERE Id = @Id";
                connection.Execute(query, obj);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result Deletar(int Id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"UPDATE Turma SET IsDeleted = 1 WHERE Id = {Id}";
                connection.Execute(query);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
    public Result Reativar(int Id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"UPDATE Turma SET IsDeleted = 0 WHERE Id = {Id}";
                connection.Execute(query);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result<List<Turma>> GetAll()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM Turma";
                var result = connection.Query<Turma>(query).ToList();
                if (result == null) return Result.Fail("Nenhum usuário encontrado");

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result<Turma> GetById(int Id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM Turma WHERE Id = {Id}";
                var result = connection.QuerySingle<Turma>(query);
                if (result == null) return Result.Fail("Nenhum usuário encontrado");

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result Inserir(Turma obj)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO Turma(CursoId, NomeTurma, Ano) VALUES (@CursoId, @NomeTurma, @Ano)";
                connection.Execute(query, obj);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public bool VerificarTurmaExistente(string nomeTurma)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = $"SELECT * FROM Turma WHERE NomeTurma = {nomeTurma}";
            var result = connection.QuerySingle<Turma>(query) != null;

            return result;
        }
    }
}
