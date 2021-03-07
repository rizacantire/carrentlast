using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.Name.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);

            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new Result(true, Messages.CarDeleted);
        }

        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == id), Messages.CarListed);

        }

        public IDataResult<List<Car>> GetAll()
        {
            

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new Result(true, Messages.CarUpdated);
        }

        public IDataResult<Car> GetCarByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.ColorId==colorId),Messages.CarListed);
        }

        public IDataResult<Car> GetCarByBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == brandId), Messages.CarListed);
        }
    }
}
