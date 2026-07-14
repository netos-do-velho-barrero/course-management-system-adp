using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaController(ServicoTurma servicoTurma, ServicoCurso servicoCurso,
    ServicoInstrutor servicoInstrutor, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarTurmaDto> dtos = servicoTurma.SelecionarTodos();

        List<ListarTurmaViewModel> listarVms = mapeador.Map<List<ListarTurmaViewModel>>(dtos);

        CarregarComponentesSelecao();

        return View(listarVms);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarTurmaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        CadastrarTurmaDto dto = mapeador.Map<CadastrarTurmaDto>(cadastrarVm);

        Result resultado = servicoTurma.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Editar(EditarTurmaViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        EditarTurmaDto dto = mapeador.Map<EditarTurmaDto>(editarVm);

        Result resultado = servicoTurma.Editar(dto);

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
        Result resultado = servicoTurma.Excluir(id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    private void CarregarComponentesSelecao()
    {
        List<SelectListItem> cursos = servicoCurso.SelecionarTodos()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            })
            .ToList();

        List<SelectListItem> instrutores = servicoInstrutor.SelecionarTodos()
            .Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Nome
            })
            .ToList();

        ViewBag.Cursos = cursos;
        ViewBag.Instrutores = instrutores;
    }
}
