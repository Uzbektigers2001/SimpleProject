using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Entities
{
    public class Product
    {
        [Key]
        public long Id { get; set; } = 0;
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public double? Amount { get; set; }
        public long ProductId { get; set; }
    }
}
