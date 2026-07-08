# DOCUMENTO DE REQUISITOS DE SOFTWARE
## Sistema de Gestão Acadêmica
### Academia do Programador

**Versão 1.0**
**8 de julho de 2026**

---

## Sumário

1. [Introdução](#1-introdução)
   1.1 Finalidade do Documento
   1.2 Escopo do Produto
   1.3 Definições, Acrônimos e Abreviações
2. [Descrição Geral](#2-descrição-geral)
   2.1 Perspectiva do Produto
   2.2 Principais Entidades do Domínio
   2.3 Usuários do Sistema
3. [Requisitos Funcionais e Regras de Negócio](#3-requisitos-funcionais-e-regras-de-negócio)
   3.1 Módulo de Categoria
   3.2 Módulo de Cursos
   3.3 Módulo de Módulos (Aulas)
   3.4 Módulo de Instrutores
   3.5 Módulo de Alunos
   3.6 Módulo de Turmas
   3.7 Módulo de Matrículas
4. [Requisitos Não Funcionais](#4-requisitos-não-funcionais)
5. [Critérios de Aceitação](#5-critérios-de-aceitação)

---

## 1. Introdução

### 1.1 Finalidade do Documento

Este documento tem como objetivo especificar, de forma clara e estruturada, os requisitos funcionais e as regras de negócio do Sistema de Gestão Acadêmica a ser desenvolvido para a Academia do Programador. Ele serve como referência única entre as partes interessadas (equipe de desenvolvimento, gestores e usuários finais) para o correto entendimento do que deve ser construído.

### 1.2 Escopo do Produto

O sistema tem como finalidade gerenciar toda a estrutura acadêmica de uma escola de cursos profissionalizantes, contemplando o cadastro e a manutenção de categorias, cursos, módulos (aulas), instrutores, alunos, turmas e matrículas, além do controle das regras que garantem a consistência dessas informações.

### 1.3 Definições, Acrônimos e Abreviações

| Termo | Definição |
|---|---|
| RF | Requisito Funcional |
| RN | Regra de Negócio |

---

## 2. Descrição Geral

### 2.1 Perspectiva do Produto

O sistema será uma aplicação web utilizada pela equipe administrativa e pedagógica da escola para o gerenciamento completo da estrutura acadêmica, cobrindo desde o cadastro de categorias e cursos até o controle de matrículas de alunos em turmas.

### 2.2 Principais Entidades do Domínio

- **Categoria** — classifica os cursos oferecidos pela escola.
- **Curso** — formação oferecida, associada a uma categoria e a um nível de dificuldade.
- **Módulo (Aula)** — unidade de conteúdo que compõe um curso, organizada em ordem sequencial.
- **Instrutor** — profissional responsável por conduzir uma turma.
- **Aluno** — pessoa que pode se matricular em turmas.
- **Turma** — oferta de um curso em um período determinado, vinculada a um instrutor.
- **Matrícula** — vínculo entre um aluno e uma turma, com data e situação próprias.

### 2.3 Usuários do Sistema

O sistema será utilizado por colaboradores administrativos e coordenadores pedagógicos responsáveis pelo cadastro e pela gestão de cursos, turmas, instrutores, alunos e matrículas.

---

## 3. Requisitos Funcionais e Regras de Negócio

Os requisitos a seguir estão organizados por módulo funcional. Cada requisito funcional (RF) descreve uma capacidade que o sistema deve oferecer, enquanto cada regra de negócio (RN) descreve uma restrição ou condição que deve ser respeitada pelo sistema.

### 3.1 Módulo de Categorias

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF01 | O sistema deve permitir o cadastro de novas categorias de curso. | Alta |
| RF02 | O sistema deve permitir a visualização de todas as categorias cadastradas. | Alta |
| RF03 | O sistema deve permitir a edição de categorias existentes. | Média |
| RF04 | O sistema deve permitir a exclusão de categorias cadastradas. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN01 | O campo Nome é obrigatório e deve conter entre 3 e 100 caracteres. |
| RN02 | Não é permitido o cadastro de duas categorias com o mesmo nome. |
| RN03 | Uma categoria pode estar vinculada a um ou mais cursos. |

---

### 3.2 Módulo de Cursos

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF05 | O sistema deve permitir o cadastro de novos cursos. | Alta |
| RF06 | O sistema deve permitir a visualização de todos os cursos cadastrados. | Alta |
| RF07 | O sistema deve permitir a edição de cursos existentes. | Média |
| RF08 | O sistema deve permitir a exclusão de cursos cadastrados. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN04 | Os campos Nome (3-100 caracteres), Descrição, Carga Horária, Categoria e Nível são obrigatórios. |
| RN05 | Todo curso deve obrigatoriamente estar vinculado a uma categoria. |
| RN06 | Todo curso deve possuir um nível de dificuldade definido. |
| RN07 | A carga horária do curso deve ser maior que zero. |

---

### 3.3 Módulo de Módulos (Aulas)

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF09 | O sistema deve permitir o cadastro de novos módulos (aulas). | Alta |
| RF10 | O sistema deve permitir a visualização de todos os módulos cadastrados. | Alta |
| RF11 | O sistema deve permitir a edição de módulos existentes. | Média |
| RF12 | O sistema deve permitir a exclusão de módulos cadastrados. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN08 | Os campos Título, Curso, Ordem e Duração são obrigatórios. |
| RN09 | Todo módulo deve pertencer obrigatoriamente a um curso. |
| RN10 | A ordem do módulo dentro de um mesmo curso não pode se repetir. |
| RN11 | A duração do módulo deve ser maior que zero. |

---

### 3.4 Módulo de Instrutores

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF13 | O sistema deve permitir o cadastro de novos instrutores. | Alta |
| RF14 | O sistema deve permitir a visualização de todos os instrutores cadastrados. | Alta |
| RF15 | O sistema deve permitir a edição de instrutores existentes. | Média |
| RF16 | O sistema deve permitir a exclusão de instrutores cadastrados. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN12 | Os campos Nome (3-100 caracteres), Telefone e E-mail são obrigatórios. |
| RN13 | Não é permitido o cadastro de dois instrutores com o mesmo e-mail. |

---

### 3.5 Módulo de Alunos

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF17 | O sistema deve permitir o cadastro de novos alunos. | Alta |
| RF18 | O sistema deve permitir a visualização de todos os alunos cadastrados. | Alta |
| RF19 | O sistema deve permitir a edição de alunos existentes. | Média |
| RF20 | O sistema deve permitir a exclusão de alunos cadastrados. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN14 | Os campos Nome (3-100 caracteres), CPF, Telefone e E-mail são obrigatórios. |
| RN15 | Não é permitido o cadastro de dois alunos com o mesmo CPF. |

---

### 3.6 Módulo de Turmas

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF21 | O sistema deve permitir o cadastro de novas turmas. | Alta |
| RF22 | O sistema deve permitir a visualização de todas as turmas cadastradas. | Alta |
| RF23 | O sistema deve permitir a edição de turmas existentes. | Média |
| RF24 | O sistema deve permitir a exclusão de turmas cadastradas. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN16 | Os campos Curso, Instrutor, Data de Início, Data de Término e Número Máximo de Alunos são obrigatórios. |
| RN17 | Toda turma deve possuir exatamente um curso vinculado. |
| RN18 | Toda turma deve possuir exatamente um instrutor responsável. |
| RN19 | A data de término da turma deve ser posterior à data de início. |
| RN20 | O número máximo de alunos deve ser maior que zero. |

---

### 3.7 Módulo de Matrículas

**Requisitos Funcionais**

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RF25 | O sistema deve permitir o registro de novas matrículas. | Alta |
| RF26 | O sistema deve permitir a visualização de todas as matrículas cadastradas. | Alta |
| RF27 | O sistema deve permitir a alteração da situação de uma matrícula. | Média |
| RF28 | O sistema deve permitir o cancelamento de matrículas. | Média |

**Regras de Negócio**

| ID | Regra de Negócio |
|---|---|
| RN21 | Os campos Aluno, Turma, Data da Matrícula e Situação são obrigatórios. |
| RN22 | Um aluno não pode ser matriculado duas vezes na mesma turma. |
| RN23 | Não pode haver matrículas acima da capacidade máxima da turma. |
| RN24 | Somente alunos previamente cadastrados podem ser matriculados. |
| RN25 | Somente turmas previamente cadastradas podem receber matrículas. |

---

## 4. Requisitos Não Funcionais

| ID | Descrição do Requisito | Prioridade |
|---|---|---|
| RNF01 | O sistema deve ser acessível via navegador web, em ambiente desktop. | Alta |
| RNF02 | O sistema deve validar os dados obrigatórios antes de persistir qualquer cadastro. | Alta |
| RNF03 | O sistema deve garantir a integridade referencial entre cursos, módulos, turmas e matrículas. | Alta |
| RNF04 | As mensagens de erro exibidas ao usuário devem ser claras e orientar a correção do problema. | Média |

---

## 5. Critérios de Aceitação

Um requisito funcional será considerado atendido quando a funcionalidade correspondente estiver implementada, todas as regras de negócio associadas estiverem sendo validadas pelo sistema, e os testes funcionais relacionados forem executados com sucesso, sem violação das restrições descritas na Seção 3.
