using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ProdutoFornecedorAPI.Commands;
using ProdutoFornecedorAPI.Data;
using ProdutoFornecedorAPI.Models;

namespace ProdutoFornecedorAPI.Handlers
{
    public class AddProdutoCommandHandler : IRequestHandler<AddProdutoCommand, Produto>
    {
        private readonly AppDbContext _context;

        public AddProdutoCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Handle(AddProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Descricao = request.Descricao,
                Marca = request.Marca,
                UnidadeMedida = request.UnidadeMedida
            };

            if (_context.Produtos.Any(p => p.Descricao == produto.Descricao && p.Marca == produto.Marca))
            {
                throw new Exception("Produto duplicado.");
            }

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync(cancellationToken);

            return produto;
        }
    }
}