using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
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
        List<ListarMatriculaDto> dtos = servicoMatricula.SelecionarTodos();

        List<ListarMatriculaViewModel> listarVms = mapeador.Map<List<ListarMatriculaViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CarregarComponentesSelecao();

        CadastrarMatriculaViewModel cadastrarVm = new CadastrarMatriculaViewModel();

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarMatriculaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            CarregarComponentesSelecao();
            return View(cadastrarVm);
        }

        CadastrarMatriculaDto dto = mapeador.Map<CadastrarMatriculaDto>(cadastrarVm);

        Result resultado = servicoMatricula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            CarregarComponentesSelecao();
            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesMatriculaDto> resultado = servicoMatricula.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        EditarMatriculaViewModel editarVm = mapeador.Map<EditarMatriculaViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarMatriculaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarMatriculaDto dto = mapeador.Map<EditarMatriculaDto>(editarVm);

        Result resultado = servicoMatricula.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesMatriculaDto> resultado = servicoMatricula.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        ExcluirMatriculaViewModel excluirVm = mapeador.Map<ExcluirMatriculaViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirMatriculaViewModel excluirVm)
    {
        Result resultado = servicoMatricula.Excluir(excluirVm.Id);

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

    private void CarregarComponentesSelecao()
    {
        List<SelectListItem> alunos = servicoAluno.SelecionarTodos()
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Nome
            })
            .ToList();

        List<SelectListItem> turmas = servicoTurma.SelecionarTodos()
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.CursoId} - {t.InstrutorId} ({t.DataInicio:dd/MM/yyyy})"
            })
            .ToList();

        ViewBag.Alunos = alunos;
        ViewBag.Turmas = turmas;
    }
}
