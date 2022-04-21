using carstructure.Common.Model;
using carstructure.WebApp._3_BusinessLogic.BusinessInterface;
using carstructure.WebApp._4_DataAccess.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carstructure.WebApp._3_BusinessLogic.BusinessClass
{
    public class AudiBusinessClass : AudiBusinessInterface
    {
        private readonly ICarRepository iCarRepository;

        public AudiBusinessClass(ICarRepository _icarRepository)
        {
            iCarRepository = _icarRepository;
        }

        public async Task<bool> SaveCarAsync(Car car)
        {
            return await iCarRepository.SaveCarAsync(car);
        }

        public async Task<List<Car>> SearchCarAsync(CarSearchingParameter carSearchingParameters)
        {
            return await iCarRepository.SearchCarAsync(carSearchingParameters);
        }



        public async Task<bool> DeleteCarAsync(int id)
        {
            return await iCarRepository.DeleteCarAsync(id);
        }

        public async Task<bool> UpdateCarAsync(Car car, int id)
        {
            return await iCarRepository.UpdateCarAsync(car, id);
        }


    }
}
