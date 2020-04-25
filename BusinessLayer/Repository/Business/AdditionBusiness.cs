using BusinessLayer.Repository.Abstract;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Concrete
{
    public class AdditionBusiness
    {
        private IRepository<Addition> _Additionrepository;
        private IUnitOfWork _AdditionUnitofwork;
        private DbContext _dbContext;

        public AdditionBusiness()
        {
            _dbContext = new RestoranDBEntities();
            _AdditionUnitofwork = new EFUnitOfWork(_dbContext);
            _Additionrepository = _AdditionUnitofwork.GetRepository<Addition>();
        }

        public List<Addition> GetAddition()
        {
            return _Additionrepository.GetAll().ToList();
        }

        public void Add(Addition t)
        {
            _Additionrepository.Insert(t);
            _AdditionUnitofwork.SaveChanges();
        }

        public void Delete(int id)
        {
            _Additionrepository.Delete(id);
            _AdditionUnitofwork.SaveChanges();
        }

        public void Edit(Addition t)
        {
            _Additionrepository.Update(t);
            _AdditionUnitofwork.SaveChanges();
        }

        public void Delete(Addition t)
        {
            _Additionrepository.Delete(t);
            _AdditionUnitofwork.SaveChanges();
        }

        public Addition Get(int id)
        {
            return _Additionrepository.Get(x => x.AdditionID == id);
        }
        public Addition GetByPrice(int price)
        {
            using (RestoranDBEntities db = new RestoranDBEntities())
            {
                return db.Additions.FirstOrDefault(a => a.TotalPrice == price);
            }
        }
        public Addition GetByTableId(int tableid)
        {
            using (RestoranDBEntities db = new RestoranDBEntities())
            {

                var firstaddition = db.Additions.FirstOrDefault(a => a.TableID == tableid && a.Status == true);

                if (firstaddition != null)
                {
                    return firstaddition;
                }
                else
                {
                    return null;
                }
            }
        }
        public Addition GetByTable(int tableid)
        {
            using (RestoranDBEntities db = new RestoranDBEntities())
            {

                var tableId = db.Additions.FirstOrDefault(a => a.TableID == tableid && a.Status == true);

                if (tableId != null)
                {
                    return tableId;
                }
                else
                {
                    return null;
                }
            }
        }
    }
    
	}

