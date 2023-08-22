using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys
{
    public class DestekTur
    {
        [Key]
        public int Id { get; set; }
        public string DestekTuru { get; set; }
        [MaxLength(100)]
        public string Aciklama { get; set; }
    }
}
