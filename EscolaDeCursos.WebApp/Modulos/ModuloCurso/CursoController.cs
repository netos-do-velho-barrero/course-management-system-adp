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

        ViewBag.Categorias = CarregarCategorias();

        return View(listarVms);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Por favor, preencha todos os campos obrigatórios.";
            return RedirectToAction(nameof(Listar));
        }

        CadastrarCursoDto dto = mapeador.Map<CadastrarCursoDto>(cadastrarVm);
        Result resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Por favor, preencha todos os campos obrigatórios.";
            return RedirectToAction(nameof(Listar));
        }

        EditarCursoDto dto = mapeador.Map<EditarCursoDto>(editarVm);

        Result resultado = servicoCurso.Editar(dto);

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
        Result resultado = servicoCurso.Excluir(id);

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
