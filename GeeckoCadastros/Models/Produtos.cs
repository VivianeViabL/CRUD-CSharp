 using System.Data.SqlClient;
 using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;
 
 namespace GeeckoCadastros.Models
 {
    public class Produtos
    {
        [Key] // Chave primária do BD
        [Display(Name = "Código")] // Faz com que apareça no site o nome "Código", não o "Cod_Prod"
        public int Cod_Prod {get; set;}
        [Display(Name = "Código de Barras")]
        [Required(ErrorMessage = "O campo {0} é obrigatório, favor preencher.")] // Caso o usuário não digite nada, aparece essa mensagem
        [RegularExpression(@"\d{13}", ErrorMessage = "O código de barras deve conter 13 dígitos.")] // O "RegularExpression" garante que CodigoBarras tenha exatamente 13 números
        public long CodigoBarras {get; set;}
        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório, favor preencher.")]
        public string? NomeProd {get; set;} // O "?" não permite valor nulo
        [Display(Name = "Categoria")]
        public string? Categoria {get; set;}
        public string? Fabricante {get; set;}
        [Display(Name = "Quantidade em Estoque")]
        public int Quantidade {get; set;}
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório, favor preencher.")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)] // Instrui o ASP.NET sobre como formatar a exibição, nesse ele mantém 2 decimais após a vírgula, até na edição 
        public double? ValorProd {get; set;}
    }
 }