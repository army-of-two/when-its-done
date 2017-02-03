using System;
using System.Web;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public class DefaultRegisterEventArgs : EventArgs
    {
        public DefaultRegisterEventArgs(HttpContext context, string email, string password)
        {
            this.Context = context;
            this.Email = email;
            this.Password = password;
        }

        public HttpContext Context { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
