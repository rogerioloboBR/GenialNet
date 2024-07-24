using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutoFornecedorAPI.Data;
using ProdutoFornecedorAPI.Handlers;
using ProdutoFornecedorAPI.Integration.Interfaces;
using ProdutoFornecedorAPI.Integration.Response;
using ProdutoFornecedorAPI.Models;

namespace ProdutoFornecedorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public FornecedorsController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/Fornecedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        // GET: api/Fornecedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        // POST: api/Fornecedor
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            if (_context.Fornecedores.Any(f => f.CNPJ == fornecedor.CNPJ))
            {
                return Conflict("Fornecedor duplicado.");
            }
            var responseData = await GetEnderecoFromCep(fornecedor.Cep);
            var fornecedorCad = new Fornecedor()
            {
                Nome = fornecedor.Nome,
                Cep = fornecedor.Cep,
                CNPJ = fornecedor.CNPJ,
                Endereco = responseData,
                Telefone = fornecedor.Telefone,
                Id = fornecedor.Id,
                Produtos = fornecedor.Produtos,
                
            };
            


        _context.Fornecedores.Add(fornecedorCad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
        }

        // PUT: api/Fornecedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            fornecedor.Endereco = await GetEnderecoFromCep(fornecedor.Endereco);

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }

        private async Task<string> GetEnderecoFromCep(string cep)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();

            var endereco = await response.Content.ReadFromJsonAsync<ViaCepResponse>();
            return $"{endereco.Logradouro}, {endereco.Bairro}, {endereco.Localidade} - {endereco.UF}";
        }
    }
}