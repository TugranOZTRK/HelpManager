using Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IDestekTurService
    {
        void Add(DestekTur t);
        void Delete(DestekTur t);
        void Update(DestekTur t);
        List<DestekTur> GetList();
        DestekTur GetById(int id);
    }
}
