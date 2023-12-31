﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Models
{
   public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Country { get; set; }

        
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }

        [NotMapped]
        public virtual Album Album { get; set; }

        public Artist()
        {
            
        }
    }
}
