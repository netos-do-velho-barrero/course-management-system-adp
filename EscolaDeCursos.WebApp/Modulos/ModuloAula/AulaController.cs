using AutoMapper;
using FluentResults;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula;

public class AulaController(ServicoAula servicoAula, ServicoCurso servicoCurso, IMapper mapeador) : Controller
{
    [HttpGet]
public ActionResult Listar()
{

    var cursos = ObterCursosCadastrados();

    ViewBag.Cursos = cursos;

    List<ListarAulaDto> dtos = servicoAula.SelecionarTodos();
    List<ListarAulaViewModel> listarVms = mapeador.Map<List<ListarAulaViewModel>>(dtos);

    foreach (var vm in listarVms)
    {
        var cursoRelacionado = cursos.FirstOrDefault(c => c.Value == vm.CursoId.ToString());
        vm.CursoNome = cursoRelacionado?.Text ?? "Curso não encontrado";
    }

    return View(listarVms);
}
    [HttpPost]
    public ActionResult Cadastrar(CadastrarAulaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Dados inválidos. Certifique-se de preencher todos os campos obrigatórios.";
            return RedirectToAction(nameof(Listar));
        }

        CadastrarAulaDto dto = mapeador.Map<CadastrarAulaDto>(cadastrarVm);
        Result resultado = servicoAula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = string.Join(" ", resultado.Errors.Select(x => x.Message));
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Editar(EditarAulaViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Dados de edição inválidos. Verifique as informações digitadas.";
            return RedirectToAction(nameof(Listar));
        }

        EditarAulaDto dto = mapeador.Map<EditarAulaDto>(editarVm);
        Result resultado = servicoAula.Editar(dto);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = string.Join(" ", resultado.Errors.Select(x => x.Message));
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirAulaViewModel excluirVm)
    {
        Result resultado = servicoAula.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = string.Join(" ", resultado.Errors.Select(x => x.Message));
        }

        return RedirectToAction(nameof(Listar));
    }

    private List<SelectListItem> ObterCursosCadastrados()
    {
        return servicoCurso.SelecionarTodos()
            .Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
            .ToList();
    }
}
