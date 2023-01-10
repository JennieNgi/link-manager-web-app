using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace linkManagerApp.Models {

    public class Category {
        [Key]
        public int categoryID { get; set; }
        [Required]
        [Display(Name="Category Name")]
        [MaxLength(100)]
        public string categoryName { get; set; }

        // [ForeignKey("categoryRefID")]
        // public ICollection<Link> Links { get; set; }

    } 

}