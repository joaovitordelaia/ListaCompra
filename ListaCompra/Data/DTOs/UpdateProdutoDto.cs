using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Data.DTOs
{
    public class UpdateProdutoDto
    {
        [Required(ErrorMessage = "O campo de descrição é obrigatório")]
        [MaxLength(70, ErrorMessage = "O campo de descrição cabe 70 caracteres")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "O campo de valor é obrigatório")]
        [Range(0.01, 9999.99)]
        public float? Value { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatório")]
        [Range(0.01, 9999.99)]
        public float? Quantity { get; set; }
    }
}
