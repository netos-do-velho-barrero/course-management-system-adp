using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public class MatriculaController(
    ServicoMatricula servicoMatricula,
    ServicoAluno servicoAluno,
    ServicoTurma servicoTurma,
    IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        // 1. Busca os alunos e turmas cadastrados primeiro
        var alunos = ObterAlunosCadastrados();
        var turmas = ObterTurmasCadastradas();

        // 2. Alimenta a ViewBag para os dropdowns dos modais
        ViewBag.Alunos = alunos;
        ViewBag.Turmas = turmas;

        // 3. Carrega as matrículas e mapeia para a ViewModel
        List<ListarMatriculaDto> dtos = servicoMatricula.SelecionarTodos();
        List<ListarMatriculaViewModel> listarVms = mapeador.Map<List<ListarMatriculaViewModel>>(dtos);

        // 4. Associa manualmente os nomes com base no ID (como no seu exemplo)
        foreach (var vm in listarVms)
        {
            var alunoRelacionado = alunos.FirstOrDefault(a => a.Value == vm.AlunoId.ToString());
            vm.AlunoNome = alunoRelacionado?.Text ?? "Aluno não encontrado";

            var turmaRelacionada = turmas.FirstOrDefault(t => t.Value == vm.TurmaId.ToString());
            vm.TurmaNome = turmaRelacionada?.Text ?? "Turma não encontrada";
        }

        return View(listarVms);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarMatriculaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        CadastrarMatriculaDto dto = mapeador.Map<CadastrarMatriculaDto>(cadastrarVm);
        Result resultado = servicoMatricula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Editar(EditarMatriculaViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        EditarMatriculaDto dto = mapeador.Map<EditarMatriculaDto>(editarVm);
        Result resultado = servicoMatricula.Editar(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Excluir(Guid id)
    {
        Result resultado = servicoMatricula.Excluir(id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Cancelar(Guid id)
    {
        Result resultado = servicoMatricula.Cancelar(id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Concluir(Guid id)
    {
        Result resultado = servicoMatricula.Concluir(id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    // Métodos auxiliares para buscar os registros de Alunos e Turmas
    private List<SelectListItem> ObterAlunosCadastrados()
    {
        return servicoAluno.SelecionarTodos()
            .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nome })
            .ToList();
    }

    private List<SelectListItem> ObterTurmasCadastradas()
    {
        return servicoTurma.SelecionarTodos()
            .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Curso })
            .ToList();
    }
}
