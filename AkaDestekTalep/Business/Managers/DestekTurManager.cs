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
    public class DestekTurManager:IDestekTurService
    {
        IDestekTurDal _destekTurDal;
        public DestekTurManager(IDestekTurDal destekTurDal)
        {
            _destekTurDal = destekTurDal;
        }

        public void Add(DestekTur t)
        {
            _destekTurDal.Insert(t);
        }

        public void Delete(DestekTur t)
        {
            _destekTurDal.Delete(t);
        }

        public DestekTur GetById(int id)
        {
           return _destekTurDal.GetById(id);
        }

        public List<DestekTur> GetList()
        {
            return _destekTurDal.GetListAll();
        }

        public void Update(DestekTur t)
        {
            _destekTurDal.Update(t);
        }
    }
}
