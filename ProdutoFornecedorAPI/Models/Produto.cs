using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoFornecedorAPI.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string UnidadeMedida { get; set; }
        [Required]
        public int FornecedorId { get; set; }
    }
}