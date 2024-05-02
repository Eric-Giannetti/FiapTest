using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesProject;

public interface ICrud<T>
{
    Result Inserir(T obj);
    Result Atualizar(T obj);
    Result Deletar(int Id);
    Result Reativar(int Id);
    Result<List<T>> GetAll();
    Result<T> GetById(int id);
}