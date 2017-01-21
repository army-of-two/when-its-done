using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.Mocks
{
    public class FakeDbModel : IDbModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
