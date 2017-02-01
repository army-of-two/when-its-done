using System.Collections.Generic;

using WhenItsDone.Common.Enums;

namespace WhenItsDone.Models.Contracts
{
    public interface IClient : IDbModel
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        GenderType Gender { get; set; }

        int Age { get; set; }

        bool IsAvailable { get; set; }

        int Rating { get; set; }

        int ContactInformationId { get; set; }

        IContactInformation ContactInformation { get; set; }

        ICollection<IPayment> Payments { get; set; }

        ICollection<IJob> Jobs { get; set; }
    }
}
