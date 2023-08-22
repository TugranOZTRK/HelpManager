using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys
{
    public class DestekKonu
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Konu { get; set; }
        [MaxLength(100)]
        public string Aciklama { get; set; }
    }
}
