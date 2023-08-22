using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys
{
    public class DestekDurum
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Durum { get; set; }
    }
}
