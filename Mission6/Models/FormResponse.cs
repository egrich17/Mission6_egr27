using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
    // create model for the form, make every field required except for the edited,
    // lent to, and notes. add special error messages for invalid fields
{
    public class FormResponse
    {
        [Key]
        [Required]
        public int FormId { get; set; }
        [Required (ErrorMessage ="You must enter a title.")]
        public string Title { get; set; }
        [Required (ErrorMessage = "You must enter a year.")]
        public int Year { get; set; }
        [Required (ErrorMessage = "You must enter a director name.")]
        public string Director { get; set; }
        [Required (ErrorMessage = "You must enter a rating.")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }
        // build foreign key relastionship
        [Required(ErrorMessage = "You must enter a category.")]
        public int CategoryId { get; set; }
        public Category Category {get; set;}
    }
}
