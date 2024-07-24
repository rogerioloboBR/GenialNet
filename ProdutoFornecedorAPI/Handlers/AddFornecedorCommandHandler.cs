using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ProdutoFornecedorAPI.Commands;
using ProdutoFornecedorAPI.Data;
using ProdutoFornecedorAPI.Models;
using ProdutoFornecedorAPI.Services;

namespace ProdutoFornecedorAPI.Handlers
{
    public class AddFornecedorCommandHandler : IRequestHandler<AddFornecedorCommand, Fornecedor>
    {
        private readonly AppDbContext _context;
        private readonly ViaCepService _viaCepService;

        public AddFornecedorCommandHandler(AppDbContext context, ViaCepService viaCepService)
        {
            _context = context;
            _viaCepService = viaCepService;
        }

        public async Task<Fornecedor> Handle(AddFornecedorCommand request, CancellationToken cancellationToken)
        {
            if (_context.Fornecedores.Any(f => f.CNPJ == request.CNPJ))
            {
                throw new Exception("Fornecedor duplicado.");
            }

            if (!CNPJValidation.Validate(request.CNPJ))
            {
                throw new Exception("CNPJ inválido.");
            }

            var endereco = await _viaCepService.ObterDadosViaCep(request.CEP);
            if (endereco == null)
            {
                throw new Exception("CEP inválido.");
            }

            var fornecedor = new Fornecedor
            {
                Nome = request.Nome,
                CNPJ = request.CNPJ,
                Endereco = endereco.Logradouro+" " + endereco.CEP+" " + endereco.Bairro +" "+ endereco.UF,
                Telefone = request.Telefone
            };

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync(cancellationToken);

            return fornecedor;
        }
    }
}