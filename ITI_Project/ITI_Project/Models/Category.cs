using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Category
    {

        //-----------------------------------------------------------------
        [Key]
        [DisplayName("Id")]
        [Column("CategoryId")]
        public int Id { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*Category Name is Required")]
        [StringLength(25,MinimumLength=3,ErrorMessage = "*Category Name Must Be Between 3 & 25")]
        public string Name { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*Category Description is Required")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "*Category Description Must Be Between 10 & 80")]
        public string Description { get; set; }

        //-----------------------------------------------------------------

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        //-----------------------------------------------------------------



    }
}
