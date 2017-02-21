using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;

namespace WhenItsDone.Services.Factories
{
    public interface IWorkerDetailInformationDTOFactory
    {
        WorkerDetailInformationDTO GetWorkerDetailInformationDTO(int id,
                                                                    string firstName,
                                                                    string lastName,
                                                                    GenderType gender,
                                                                    int age,
                                                                    int rating,
                                                                    string email,
                                                                    string phone,
                                                                    string country,
                                                                    string city,
                                                                    string street);
    }
}
