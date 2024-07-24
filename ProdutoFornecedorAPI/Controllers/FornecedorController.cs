using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProdutoFornecedorAPI.Commands;
using ProdutoFornecedorAPI.Models;

namespace ProdutoFornecedorAPI.Controllers
{
    //// Controllers/FornecedorController.cs
    //[ApiController]
    //[Route("api/[controller]")]
    //public class FornecedorController : ControllerBase
    //{
    //    private readonly IMediator _mediator;

    //    public FornecedorController(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<Fornecedor>> PostFornecedor(AddFornecedorCommand command)
    //    {
    //        var fornecedor = await _mediator.Send(command);
    //        return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
    //    }
    //}
}