using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Xamarin.Forms;
using XamarinFirebase.Droid.Services;
using XamarinFirebase.Services;

[assembly:Dependency(typeof(FirebaseAuthDroidcs))]

namespace XamarinFirebase.Droid.Services
{
    class FirebaseAuthDroidcs : FirebaseAuthShared
    {
        public Task<string> GetCurrentUser()
        {
            try
            {
                var user = FirebaseAuth.Instance.CurrentUser;

                if (user != null)
                {
                    // User is signed in
                    return Task.FromResult(user.Uid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return Task.FromResult(ex.Message);
            }
            
        }

        public async Task<string> CreateUserAsync(string email, string password)
        {
            IAuthResult res;
            try
            {
                res = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                if (res.User.Uid != null)
                {
                    return res.User.Uid;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        public async Task<string> LoginWithEmailAndPassword(string Email, string Password)
        {
            IAuthResult res;

            try
            {
                res = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(Email, Password);
                return res.User.Uid;
            }
            catch (Exception ex)
            {
                return await Task.FromResult("false:" + ex.Message);
            }
        }

        public void SignOut()
        {
            FirebaseAuth.Instance.SignOut();
        }
    }
}