using FluentResults;
using InterfacesProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityModels;

namespace ConnectionDataBase.University
{
    public class TurmaProvider : ICrud<Turma>
    {
        public Result Atualizar(Turma obj)
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

        public Result<List<Turma>> GetAll()
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

        public Result<Turma> GetById(int id)
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

        public Result Inserir(Turma obj)
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

        public bool VerificarTurmaExistente(string nomeTurma)
        {
            throw new NotImplementedException();
        }
    }
}
