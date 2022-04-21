using carstructure.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carstructure.WebApp._4_DataAccess.DataAccessInterface
{
    public interface ICarRepository
    {
        Task<List<Car>> SearchCarAsync(CarSearchingParameter carSearchingParameters);
        Task<bool> SaveCarAsync(Car car);
        Task<bool> DeleteCarAsync(int id);

        Task<bool> UpdateCarAsync(Car car, int id);

    }

}
