
using System.ComponentModel.DataAnnotations;

namespace GYMVCProject.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Ürün Adı boş bırakılamaz.")]
        [StringLength(50,ErrorMessage ="Maksimum 50 Karakter girilmelidir.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Ürün Fiyatı boş bırakılamaz.")]

        [Range(1, 1000, ErrorMessage = "Ürün Fiyatı 1 ile 1000 arasında olmalıdır.")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Ürün Stok boş bırakılamaz.")]
        [Range(1,200, ErrorMessage="Stok adedi 1 ile 200 arasında olmalıdır.")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Ürün Renk boş bırakılamaz.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Ürün Açıklaması boş bırakılamaz.")]
        [StringLength(300,MinimumLength =50, ErrorMessage = "Maksimum 300 Minimum 50 Karakter girilmelidir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi boş bırakılamaz.")]
        public DateTime? PublishDate { get; set; }

        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Yayınlanma Süresi boş bırakılamaz.")]
        public int Expire { get; set; }


    }
}
