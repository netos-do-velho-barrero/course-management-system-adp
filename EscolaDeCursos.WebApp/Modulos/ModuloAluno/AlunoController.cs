using AutoMapper;
using FluentResults;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using Microsoft.AspNetCore.Mvc;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public class AlunoController(ServicoAluno servicoAluno, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarAlunoDto> dtos = servicoAluno.SelecionarTodos();

        List<ListarAlunoViewModel> listarVms = mapeador.Map<List<ListarAlunoViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarAlunoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Dados inválidos. Certifique-se de preencher todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        CadastrarAlunoDto dto = mapeador.Map<CadastrarAlunoDto>(cadastrarVm);

        Result resultado = servicoAluno.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = string.Join(" ", resultado.Errors.Select(x => x.Message));
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Editar(EditarAlunoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Dados de edição inválidos. Verifique as informações digitadas.";
            return RedirectToAction(nameof(Listar));
        }

        EditarAlunoDto dto = mapeador.Map<EditarAlunoDto>(editarVm);

        Result resultado = servicoAluno.Editar(dto);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = string.Join(" ", resultado.Errors.Select(x => x.Message));
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirAlunoViewModel excluirVm)
    {
        Result resultado = servicoAluno.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = string.Join(" ", resultado.Errors.Select(x => x.Message));
        }

        return RedirectToAction(nameof(Listar));
    }
}
