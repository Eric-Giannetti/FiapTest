# API RESTful de Gerenciamento de Alunos e Turmas

Este projeto consiste em uma API RESTful desenvolvida em C# utilizando Dapper como ORM (Object-Relational Mapper) para realizar operações de CRUD (Create, Read, Update, Delete) em uma base de dados MySQL. A API permite o cadastro de alunos, turmas e a vinculação entre eles.

## Funcionalidades

- Cadastro de Alunos: Permite adicionar novos alunos à base de dados, fornecendo informações como nome, usuário e senha.
- Cadastro de Turmas: Possibilita a criação de novas turmas, especificando o curso, nome da turma e o ano correspondente.
- Vinculação de Alunos e Turmas: Permite associar alunos a turmas existentes.

## Estrutura do Banco de Dados

O banco de dados possui três tabelas principais:

1. **Aluno**: Armazena informações dos alunos, incluindo nome, usuário, senha e um indicador de exclusão.
   
   ```sql
        CREATE TABLE aluno (
          Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
          Nome varchar(100) NULL,
          Usuario varchar(100) NULL,
          Senha varchar(100) NULL,
          IsDeleted bit NULL
      );

2. **Turma**: Armazena informações das turmas, incluindo o curso associado, nome da turma, ano e um indicador de exclusão.

    ```sql
      CREATE TABLE turma (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        CursoId int NULL,
        NomeTurma varchar(100) NULL,
        Ano int NULL,
        IsDeleted bit NULL
      );

3. **AlunoTurma**: Tabela de associação entre alunos e turmas.
    ```sql
      CREATE TABLE alunoturma (
        AlunoId int NOT NULL,
        TurmaId int NOT NULL,
        CONSTRAINT PK_AlunoTurma PRIMARY KEY (AlunoId, TurmaId),
        CONSTRAINT FK_AlunoTurma_Aluno FOREIGN KEY (AlunoId) REFERENCES aluno(Id),
        CONSTRAINT FK_AlunoTurma_Turma FOREIGN KEY (TurmaId) REFERENCES turma(Id)
      );

## Como Executar

1. Clone este repositório.
2. Configure sua conexão com o banco de dados MySQL no arquivo appsettings.json.
3. No terminal, navegue até o diretório raiz do projeto e escolha o projeto que deseja inicializar localizado na pasta Hosts.
4. O Projeto possui duas API, uma MVC para testes visuais e uma Para Requisições Rest