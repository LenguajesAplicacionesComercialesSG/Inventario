using System.ComponentModel.DataAnnotations;

namespace Inventario.MODEL
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Nombre del producto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Categoría del producto")]
        public string Categoria { get; set; }

        [Required]
        [Range(0.01, 999999.99,ErrorMessage = "El precio debe ser > 0")]
        [Display(Name = "Precio (₡)")]
        public double Precio { get; set; }

        [Required]
        public int Stock { get; set; }

    }
}
