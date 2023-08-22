using Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IDestekService
    {
        void Add(Destek t);
        void Delete(Destek t);
        void Update(Destek t);
        List<Destek> GetList();
        Destek GetById(int id);
    }
}
