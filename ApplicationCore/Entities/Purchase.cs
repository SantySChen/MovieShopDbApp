using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime PurchaseDateTime { get; set; }
        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid PurchaseNumber { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalPrice { get; set; }

    }
}
