using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Data
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
