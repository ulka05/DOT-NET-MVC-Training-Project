using carstructure.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carstructure.WebApp._3_BusinessLogic.BusinessInterface
{
    public interface AudiBusinessInterface
    {
        Task<List<Car>> SearchCarAsync(CarSearchingParameter carSearchingParameters);

        Task<bool> SaveCarAsync(Car car);

        Task<bool> DeleteCarAsync(int id);
        Task<bool> UpdateCarAsync(Car car, int id);

    }

}
