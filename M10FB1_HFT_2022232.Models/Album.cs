using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Models
{
   public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public virtual Label Label { get; set; }

        [ForeignKey(nameof(Label))]
        public int LabelId { get; set; }

        [NotMapped]
        public virtual ICollection<Artist> Artists { get; set; }
        public Album()
        {
            Artists = new List<Artist>();
        }


    }
}
