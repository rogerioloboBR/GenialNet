using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoFornecedorAPI.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "CNPJ inválido.")]
        public string CNPJ { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}