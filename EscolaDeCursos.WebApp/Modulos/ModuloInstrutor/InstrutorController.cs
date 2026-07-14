using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor;

public class InstrutorController(ServicoInstrutor servicoInstrutor, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarInstrutorDto> dtos = servicoInstrutor.SelecionarTodos();

        List<ListarInstrutorViewModel> listarVms = mapeador.Map<List<ListarInstrutorViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarInstrutorViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        CadastrarInstrutorDto dto = mapeador.Map<CadastrarInstrutorDto>(cadastrarVm);

        Result resultado = servicoInstrutor.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpPost]
    public ActionResult Editar(EditarInstrutorViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
            return RedirectToAction(nameof(Listar));
        }

        EditarInstrutorDto dto = mapeador.Map<EditarInstrutorDto>(editarVm);

        Result resultado = servicoInstrutor.Editar(dto);

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
        Result resultado = servicoInstrutor.Excluir(id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
}
