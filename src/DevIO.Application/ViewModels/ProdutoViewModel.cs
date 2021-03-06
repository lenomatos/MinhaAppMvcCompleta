using DevIO.App.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage ="O campo {0} é precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} é precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Imagem { get; set; }

        [Display(Name = "Imagem")]
        public IFormFile ImagemUpload { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Moeda]
        public decimal Valor { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [Display(Name ="Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public FornecedorViewModel Fornecedor { get; set; }
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }

    }
}
