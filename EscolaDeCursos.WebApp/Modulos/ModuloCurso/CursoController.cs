using AutoMapper;
using FluentResults;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoController(
    ServicoCurso servicoCurso,
    ServicoCategoria servicoCategoria,
    IMapper mapeador) : Controller
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
            (NivelCurso)(-1),
            null, // Alterado de Guid.Empty para null para coincidir com o Guid?
            CarregarCategorias()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            cadastrarVm = cadastrarVm with
            {
                Categorias = CarregarCategorias()
            };

            return View(cadastrarVm);
        }

        CadastrarCursoDto dto = mapeador.Map<CadastrarCursoDto>(cadastrarVm);

        Result resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            cadastrarVm = cadastrarVm with
            {
                Categorias = CarregarCategorias()
            };

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

        editarVm = editarVm with
        {
            Categorias = CarregarCategorias()
        };

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            editarVm = editarVm with
            {
                Categorias = CarregarCategorias()
            };

            return View(editarVm);
        }

        EditarCursoDto dto = mapeador.Map<EditarCursoDto>(editarVm);

        Result resultado = servicoCurso.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            editarVm = editarVm with
            {
                Categorias = CarregarCategorias()
            };

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


    private List<SelectListItem> CarregarCategorias()
    {
        return servicoCategoria
            .SelecionarTodos()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            })
            .ToList();
    }
}
