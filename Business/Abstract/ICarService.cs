using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IDataResult<Car> GetById(int carId);
        IDataResult<Car> GetCarByColorId(int colorId);
        IDataResult<Car> GetCarByBrandId(int brandId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
