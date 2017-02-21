using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.MVP.Tests.Mocks
{
    public class MockedWorkerDetailsEventArgs : WorkerDetailsEventArgs
    {
        public MockedWorkerDetailsEventArgs()
            : base("0", null, null, "Undefined", "0", "0", null, null, null, null, null)
        {
        }

        public MockedWorkerDetailsEventArgs(string id, string firstName, string lastName, string gender, string age, string rating, string email, string phone, string country, string city, string street)
            : base(id, firstName, lastName, gender, age, rating, email, phone, country, city, street)
        {
        }
    }
}
