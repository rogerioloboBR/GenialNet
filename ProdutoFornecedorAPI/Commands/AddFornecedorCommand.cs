using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ProdutoFornecedorAPI.Models;

namespace ProdutoFornecedorAPI.Commands
{
    public record AddFornecedorCommand(string Nome, string CNPJ, string CEP, string Telefone) : IRequest<Fornecedor>;
}