﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2084)")]
        public string ProfilePath { get; set; }
        [Required]
        public string TmdbUrl { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }

    }
}
