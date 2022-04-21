using carstructure.Common.Enum;
using carstructure.Common.Model;
using carstructure.WebApp._4_DataAccess;
using carstructure.WebApp._4_DataAccess.DataAccessInterface;
using carstructure.WebApp._4_DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carstructure.WebApp._4_DataAccess.DataAccessClass
{
    public class CarRepository : BaseRepository , ICarRepository
    {
        public CarRepository(Context context) : base(context) { }

        

        public async Task<List<Car>> SearchCarAsync(CarSearchingParameter carSearchingParameter)
        {
            //IQueryable<CarEntity> CarQuery = (IQueryable<CarEntity>)context.CarDbSet.OrderBy(m => m.CarName);
            IQueryable<CarEntity>? CarQuery = (IQueryable<CarEntity>)context.CarDbSet.AsQueryable();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 

            return await CarQuery.Select(m => new Car
            {
               Id = m.Id,
               CarName = m.CarName,
               CarModel = m.CarModel,
               CarManufacturer = m.CarManufacturer,
               CarColor = (CarColor?)(short?)m.CarColor,
               CarReleaseDate = m.CarReleaseDate 
            }).ToListAsync();
        }

        public async Task<bool> SaveCarAsync(Car car)
        {
            var CarObj = context.CarDbSet.Find(car.Id);
            if (CarObj == null)
            {
                CarObj = new CarEntity();
                context.Add(CarObj);
            }
            CarObj.CarColor = (short?)car.CarColor;
            CarObj.CarName = car.CarName;
            CarObj.CarModel = car.CarModel;
            CarObj.CarManufacturer = car.CarManufacturer;
            CarObj.CarReleaseDate = car.CarReleaseDate;

            return await context.SaveChangesAsync() > 0;
        }


        public async Task<bool> UpdateCarAsync(Car car, int id)
        {
            var carObj = new CarEntity()
            {
                Id = id,
                CarColor = (short?)car.CarColor,
                CarName = car.CarName,
                CarModel = car.CarModel,
                CarManufacturer = car.CarManufacturer,
                CarReleaseDate = car.CarReleaseDate
            };
            context.Update(carObj);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            CarEntity ObjCar = new CarEntity() { Id = id };
            context.Remove(ObjCar);
            return await context.SaveChangesAsync() > 0;
        }


    }

    
}
