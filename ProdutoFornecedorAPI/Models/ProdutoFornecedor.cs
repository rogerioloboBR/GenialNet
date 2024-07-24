using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoFornecedorAPI.Models
{
    public class ProdutoFornecedor
    {
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public double ValorCompra { get; set; }
    }
}