# 📂 SISTEMA DE GESTÃO ACADÊMICA | Cursos, Módulos, Instrutores, Alunos e Matrículas 🚀

> **Gerenciamento completo e inteligente da estrutura pedagógica e administrativa para escolas de cursos profissionalizantes.**

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Razor CSHTML](https://img.shields.io/badge/Razor_CSHTML-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Arquitetura MVC](https://img.shields.io/badge/Architecture-MVC-blue?style=for-the-badge)
![Desenvolvimento Web](https://img.shields.io/badge/Dev-Web-orange?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Concluído-brightgreen?style=for-the-badge)

---

![](gestao-academica.gif)

## 👥 Desenvolvedores

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/pedrohenriquedsdev">
        <img src="https://github.com/pedrohenriquedsdev.png" width="80px" style="border-radius: 50%"/><br/>
        <sub><b>Pedro Henrique</b></sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/Marco-Oliver">
        <img src="https://github.com/Marco-Oliver.png" width="80px" style="border-radius: 50%"/><br/>
        <sub><b>Marco Oliver</b></sub>
      </a>
    </td>
  </tr>
</table>

<br>

## 📋 Sobre o Projeto

O **Sistema de Gestão Acadêmica** é uma aplicação web robusta desenvolvida para a **Academia do Programador**. O objetivo principal é centralizar e otimizar o controle de toda a estrutura acadêmica de uma instituição de ensino. A plataforma permite gerenciar desde a classificação de categorias e cursos até o controle diário de turmas, módulos (aulas) e matrículas de alunos, garantindo a integridade dos dados por meio de validações rígidas.

<br>

## ✨ Funcionalidades

### 🏷️ Módulo de Categorias
- Cadastrar, editar, visualizar e excluir categorias de cursos
- Campo obrigatório: Nome (3–100 caracteres)
- Não é permitido o cadastro de duas categorias com o mesmo nome
- Uma categoria serve de agrupador e pode estar vinculada a um ou mais cursos

### 📚 Módulo de Cursos
- Cadastrar, editar, visualizar e excluir formações oferecidas
- Campos obrigatórios: Nome (3–100 caracteres), Descrição, Carga Horária, Categoria e Nível de Dificuldade
- A carga horária do curso deve ser estritamente maior que zero
- Todo curso deve possuir obrigatoriamente um nível de dificuldade e uma categoria vinculada

### 📖 Módulo de Módulos (Aulas)
- Cadastrar, editar, visualizar e excluir unidades de conteúdo de um curso
- Campos obrigatórios: Título, Curso, Ordem e Duração
- Todo módulo deve pertencer obrigatoriamente a um curso
- A ordem do módulo dentro de um mesmo curso não pode se repetir (organização sequencial única)
- A duração do módulo deve ser maior que zero

### 👨‍🏫 Módulo de Instrutores
- Cadastrar, editar, visualizar e excluir profissionais do corpo docente
- Campos obrigatórios: Nome (3–100 caracteres), Telefone e E-mail
- Não é permitido o cadastro de dois instrutores com o mesmo e-mail

### 🧑‍🎓 Módulo de Alunos
- Cadastrar, editar, visualizar e excluir estudantes
- Campos obrigatórios: Nome (3–100 caracteres), CPF, Telefone e E-mail
- Controle de unicidade rigoroso: não é permitido o cadastro de dois alunos com o mesmo CPF

### 🏫 Módulo de Turmas
- Cadastrar, editar, visualizar e excluir ofertas de cursos por período
- Campos obrigatórios: Curso, Instrutor, Data de Início, Data de Término e Número Máximo de Alunos
- Toda turma deve possuir exatamente um curso vinculado e um instrutor responsável
- A data de término da turma deve ser obrigatoriamente posterior à data de início
- O número máximo de alunos (capacidade da turma) deve ser maior que zero

### 📝 Módulo de Matrículas
- Registrar, visualizar, alterar a situação e cancelar vínculos de alunos com as turmas
- Campos obrigatórios: Aluno, Turma, Data da Matrícula e Situação
- Um aluno não pode ser matriculado duas vezes na mesma turma
- Bloqueio automático: não são permitidas matrículas acima da capacidade máxima configurada na turma
- Validação de integridade: somente alunos e turmas previamente cadastrados podem ser utilizados

<br>

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- Git

### Passo a passo

```bash
# 1. Clone o repositório
git clone [https://github.com/pedrohenriquedsdev/sistema-gestao-academica.git](https://github.com/pedrohenriquedsdev/sistema-gestao-academica.git)

# 2. Acesse a pasta do projeto
cd sistema-gestao-academica

# 3. Restaure os pacotes
dotnet restore

# 4. Execute a aplicação
dotnet run --project src/SistemaGestaoAcademica.Web
