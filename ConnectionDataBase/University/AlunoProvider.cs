using Dapper;
using FluentResults;
using InterfacesProject;
using System.Data.SqlClient;
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
        _connectionString = config.GetConnectionString("SqlConnection");
    }

    public Result Atualizar(Aluno obj)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                var queryBuilder = new StringBuilder("UPDATE Aluno SET ");

                if (obj.Nome != null)
                {
                    queryBuilder.Append("Nome = @Nome, ");
                    parameters.Add("@Nome", obj.Nome);
                }
                if (obj.Usuario != null)
                {
                    queryBuilder.Append("Usuario = @Usuario, ");
                    parameters.Add("@Usuario", obj.Usuario);
                }
                if (obj.Senha != null)
                {
                    queryBuilder.Append("Senha = @Senha, ");
                    parameters.Add("@Senha", obj.Senha);
                }

                // Remove a última vírgula e espaço
                queryBuilder.Length -= 2;

                // Adiciona a condição WHERE
                queryBuilder.Append(" WHERE Id = @Id");
                parameters.Add("@Id", obj.Id);

                // Executa a consulta
                connection.Execute(queryBuilder.ToString(), parameters);
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
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"UPDATE Aluno SET IsDeleted = 1 WHERE Id = @Id";
                connection.Execute(query, new {Id = Id});
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result<List<Aluno>> GetAll()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM Aluno";
                var result = connection.Query<Aluno>(query).ToList();
                if (result == null) return Result.Fail("Nenhum usuário encontrado");

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result<List<Aluno>> GetAlunosByTurmaId(int turmaId)
    {
        throw new NotImplementedException();
    }

    public Result<Aluno> GetById(int Id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM Aluno WHERE Id = {Id}";
                var result = connection.QuerySingle<Aluno>(query);
                if (result == null) return Result.Fail("Nenhum usuário encontrado");

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

    public Result Inserir(Aluno obj)
    {
        using (var connection = new SqlConnection(_connectionString))
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
        }
    }

    public Result Reativar(int Id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string query = $"UPDATE Aluno SET IsDeleted = 0 WHERE Id = {Id}";
                connection.Execute(query);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
