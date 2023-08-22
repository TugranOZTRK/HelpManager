using Business.Services;
using Data.Abstract;
using Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class DestekKonuManager:IDestekKonuService
    {
        IDestekKonuDal _destekKonuDal;
        public DestekKonuManager(IDestekKonuDal destekKonuDal)
        {
            _destekKonuDal = destekKonuDal;
        }

        public void Add(DestekKonu t)
        {
            _destekKonuDal.Insert(t);
        }

        public void Delete(DestekKonu t)
        {
            _destekKonuDal.Delete(t);
        }

        public DestekKonu GetById(int id)
        {
           return _destekKonuDal.GetById(id);
        }

        public List<DestekKonu> GetList()
        {
            return _destekKonuDal.GetListAll();
        }

        public void Update(DestekKonu t)
        {
            _destekKonuDal.Update(t);
        }
    }
}
