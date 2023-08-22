using Entity.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class Context : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LS9JQEU\\SQLEXPRESS;initial catalog=DestekTalep; integrated Security = true");
        }
      
        public DbSet<Destek> Destekler { get; set; }
        public DbSet<DestekKonu> Destek_Konu { get; set; }
        public DbSet<DestekDurum> Destek_Durum { get; set; }
        public DbSet<DestekTur> Destek_Tur { get; set; }
    }
}
