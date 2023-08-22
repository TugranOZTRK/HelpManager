using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys
{
    public class Destek
    {
        [Key]
        public int Id { get; set; }
        public string DestekAlanId { get; set; }
        public string DestekVerenId { get; set; }
        public User User { get; set; }
        [MaxLength(240)]
        public string Acklama { get; set; }
        public int DestekKonuId { get; set; }
        public DestekKonu DestekKonu { get; set; }
        public int DestekTurId { get; set; }
        public DestekTur DestekTur { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
