using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeedMe.Models
{
    public class RecipeNote
    {
        [StringLength(400, MinimumLength = 3)]
        public string Content { get; set; }

        [Display(Name = "Date Saved")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd)", ApplyFormatInEditMode = true)]
        public DateTime DateSaved { get; set; }

        public int RecipeId { get; set; }
    }
}