using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ProdutoFornecedorAPI.Models;

namespace ProdutoFornecedorAPI.Commands
{
    public record AddProdutoCommand(string Descricao, string Marca, string UnidadeMedida) : IRequest<Produto>;
}