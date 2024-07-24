using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoFornecedorAPI.Models;

namespace ProdutoFornecedorAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasIndex(p => p.Descricao).IsUnique();
            modelBuilder.Entity<Fornecedor>().HasIndex(f => f.CNPJ).IsUnique();
        }
    }
}