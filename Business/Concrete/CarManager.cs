using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length > 2)
            {
                _carDal.Add(car);
            }
            else if (car.DailyPrice <= 0) 
            {
                Console.WriteLine("Ekleme başarısız. Günlük fiyat 0'dan büyük olmalıdır.");
            }
            else if (car.Name.Length <= 2) 
            {
                Console.WriteLine("Ekleme başarız. İsim 2 karakterden fazla olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length > 2)
            {
                _carDal.Update(car);
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Güncelleme başarısız. Günlük fiyat 0'dan büyük olmalıdır.");
            }
            else if (car.Name.Length <= 2)
            {
                Console.WriteLine("Güncelleme başarız. İsim 2 karakterden fazla olmalıdır.");
            }
        }
    }
}
