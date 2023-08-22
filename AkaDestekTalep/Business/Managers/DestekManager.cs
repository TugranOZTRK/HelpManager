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
    public class DestekManager:IDestekService
    {
        IDestekDal _destekDal;
        public DestekManager(IDestekDal destekDal)
        {
            _destekDal = destekDal;
        }

        public void Add(Destek t)
        {
            _destekDal.Insert(t);
        }

        public void Delete(Destek t)
        {
            _destekDal.Delete(t);
        }

        public Destek GetById(int id)
        {
            return _destekDal.GetById(id);
        }

        public List<Destek> GetList()
        {
            return _destekDal.GetListAll();
        }

        public void Update(Destek t)
        {
            _destekDal.Update(t);
        }
    }
}
