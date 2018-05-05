using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Areas.Admin.Models
{
    public class EditViewModel
    {
        [Required]
        public string Id { get; set; }

        [Display(Name = "Name:")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "BirthDate:")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "ImageUrl:")]
        [MinLength(20)]
        public string UserImageUrl { get; set; }

        [Display(Name = "IsAdmin:")]
        public bool IsAdmin { get; set; }
    }
}
