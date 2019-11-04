using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFirebase.Services
{
    public interface FirebaseAuthShared
    {
        Task<string> GetCurrentUser();
        Task<string> CreateUserAsync(string email, string password);
        Task<string> LoginWithEmailAndPassword(string Email, string Password);
        void SignOut();
    }
}
