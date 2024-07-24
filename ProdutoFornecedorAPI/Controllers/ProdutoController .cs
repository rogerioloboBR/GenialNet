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
    //[ApiController]
    //[Route("api/[controller]")]
    //public class ProdutoController : ControllerBase
    //{
    //    private readonly IMediator _mediator;

    //    public ProdutoController(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<Produto>> PostProduto(AddProdutoCommand command)
    //    {
    //        var produto = await _mediator.Send(command);
    //        return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
    //    }
    //}

    
}