using DevIO.App.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} é precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} é precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Display(Name = "Tipo")]
        public TipoFornecedor TipoFornecedor { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoViewModel Endereco { get; set; }
        [Display(Name = "Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
