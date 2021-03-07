using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : IEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            {

                using (var context = new CarRentalContext())
                {

                    var result = from c in context.Cars
                                 join b in context.Colors
                                 on c.Id equals b.Id
                                 select new CarDetailDTO()
                                 {
                                     ColorName = b.Name,
                                     CarName = c.Name
                                 };

                    return result.ToList();


                }
            }
        }
    }
}

