using AutoMapper;
using FluentResults;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using Microsoft.AspNetCore.Mvc;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoController(ServicoCurso servicoCurso, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarCursoDto> dtos = servicoCurso.SelecionarTodos();

        List<ListarCursosViewModel> listarVms = mapeador.Map<List<ListarCursosViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCursoViewModel cadastrarVm = new CadastrarCursoViewModel(
            string.Empty,
            string.Empty,
            0,
            default,
            Guid.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarCursoDto dto = mapeador.Map<CadastrarCursoDto>(cadastrarVm);

        Result resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesCursoDto> resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarCursoViewModel editarVm = mapeador.Map<EditarCursoViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarCursoDto dto = mapeador.Map<EditarCursoDto>(editarVm);

        Result resultado = servicoCurso.Editar(dto);

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
        Result<DetalhesCursoDto> resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirCursoViewModel excluirVm = mapeador.Map<ExcluirCursoViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirCursoViewModel excluirVm)
    {
        Result resultado = servicoCurso.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
}
