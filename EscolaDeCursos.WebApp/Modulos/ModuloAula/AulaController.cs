using AutoMapper;
using FluentResults;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso; // Ajuste para o namespace correto do seu serviço de curso
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula;

public class AulaController(ServicoAula servicoAula, ServicoCurso servicoCurso, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarAulaDto> dtos = servicoAula.SelecionarTodos();
        List<ListarAulaViewModel> listarVms = mapeador.Map<List<ListarAulaViewModel>>(dtos);
        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarAulaViewModel cadastrarVm = new CadastrarAulaViewModel
        {
            Cursos = ObterCursosCadastrados()
        };

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarAulaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            cadastrarVm.Cursos = ObterCursosCadastrados();
            return View(cadastrarVm);
        }

        CadastrarAulaDto dto = mapeador.Map<CadastrarAulaDto>(cadastrarVm);
        Result resultado = servicoAula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            cadastrarVm.Cursos = ObterCursosCadastrados();
            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesAulaDto> resultado = servicoAula.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        EditarAulaViewModel editarVm = mapeador.Map<EditarAulaViewModel>(resultado.Value);
        editarVm.Cursos = ObterCursosCadastrados();

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarAulaViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            editarVm.Cursos = ObterCursosCadastrados();
            return View(editarVm);
        }

        EditarAulaDto dto = mapeador.Map<EditarAulaDto>(editarVm);
        Result resultado = servicoAula.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            editarVm.Cursos = ObterCursosCadastrados();
            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesAulaDto> resultado = servicoAula.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        ExcluirAulaViewModel excluirVm = mapeador.Map<ExcluirAulaViewModel>(resultado.Value);
        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirAulaViewModel excluirVm)
    {
        Result resultado = servicoAula.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    private List<SelectListItem> ObterCursosCadastrados()
    {
        return servicoCurso.SelecionarTodos()
            .Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
            .ToList();
    }
}
