using carstructure.Common.Model;
using carstructure.WebApp._2_Services.ServiceInterface;
using carstructure.WebApp._3_BusinessLogic.BusinessInterface;
using carstructure.WebApp._4_DataAccess;
using carstructure.WebApp._4_DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carstructure.WebApp._2_Services.ServiceClass
{
    public class AudiService : AudiInterface
    {
        private readonly AudiBusinessInterface audiBusinessInterface;

        public AudiService(AudiBusinessInterface _audiBusinessInterface)
        {
            audiBusinessInterface = _audiBusinessInterface;
        }

        public async Task<List<Car>> SearchCarAsync(CarSearchingParameter carSearchingParameters)
        {
            return await audiBusinessInterface.SearchCarAsync(carSearchingParameters);
        }

        public async Task<bool> SaveCarAsync(Car car)
        {
            return await audiBusinessInterface.SaveCarAsync(car);
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            return await audiBusinessInterface.DeleteCarAsync(id);
        }

        public async Task<bool> UpdateCarAsync(Car car, int id)
        {
            return await audiBusinessInterface.UpdateCarAsync(car, id);
        }
    }
}
