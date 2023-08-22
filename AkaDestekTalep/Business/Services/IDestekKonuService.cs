using Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IDestekKonuService
    {
        void Add(DestekKonu t);
        void Delete(DestekKonu t);
        void Update(DestekKonu t);
        List<DestekKonu> GetList();
        DestekKonu GetById(int id);
    }
}
