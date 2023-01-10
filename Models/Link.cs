using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace linkManagerApp.Models {

    public class Link {
        [Key]
        public int linkID { get; set; }
        // public int categoryID {get;set;}
         public int categoryRefID { get; set; }
        [Required]
        [Display(Name="Label")]
        [MaxLength(100)]
        public string linkName { get; set; }
        [Required]
        [Display(Name="href")]
        [MaxLength(500)]
        [RegularExpression(@"^http(s?)\:\/\/.*$" , ErrorMessage="Incorrect format for URL")]
        //[RegularExpression(@"^(?!https?://).*$" , ErrorMessage="Incorrect format for URL")]
        public string href { get; set; }
        [Required]
        [Display(Name="Pin link to top")]
        public int pinned {get;set;}

       
        //public Category Category { get; set; }
    } 

    

    
}
