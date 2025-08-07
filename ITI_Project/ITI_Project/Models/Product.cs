using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Product
    {

        //-----------------------------------------------------------------
        [Key]
        [DisplayName("Id")]
        [Column("ProductId")]
        public int Id { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage ="*Title Is Required")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="*Title Must Be Between 3 & 30")]
        public string Title { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*Description Is Required")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "*Description Must Be Between 10 & 80")]
        public string Description { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*Price Is Required")]
        public decimal Price { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*Quantity Is Required")]
        [Range(5,200,ErrorMessage = "*Quantity Must Be Between 5 & 200")]
        public int Quantity { get; set; }

        //-----------------------------------------------------------------
        //[Required(ErrorMessage = "*Image Path Is Required")]
        public string ImagePath { get; set; }

        //-----------------------------------------------------------------
        [ForeignKey("Category")]
        [Required(ErrorMessage = "*Category Name Is Required")]
        public int CategoryId { get; set; }

        //-----------------------------------------------------------------

        public virtual Category Category { get; set; }

        //-----------------------------------------------------------------

    }
}
