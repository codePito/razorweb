using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor_Entity.Models
{
    //[Table("")]           Razor_Entity.Models.Article
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} phai dai tu {2} den {1} ky tu")]
        [Required]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tieu de")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Ngay tao")]
        public DateTime Created { get; set; }

        [Column(TypeName ="ntext")]
        public string Content { get; set; }

    }
}
