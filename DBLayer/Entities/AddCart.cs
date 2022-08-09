using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Entities
{
   public class AddCart
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Zoner { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
        public int cost { get; set; }
        [Display(Name = "image")]
        public string? bookimg { get; set; }
    }
}
