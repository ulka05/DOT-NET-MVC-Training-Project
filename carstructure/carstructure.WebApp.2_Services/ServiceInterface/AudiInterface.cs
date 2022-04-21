using carstructure.Common.Model;

namespace carstructure.WebApp._2_Services.ServiceInterface
{
    public interface AudiInterface
    {
        Task<List<Car>> SearchCarAsync(CarSearchingParameter carSearchingParameters);

        Task<bool>SaveCarAsync(Car car);

        Task<bool> DeleteCarAsync(int id);

        Task<bool> UpdateCarAsync(Car car, int id);
    }
}

