using Glide.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glide.Data.Interfaces
{
    public interface IFacebookAuthenticationDelegate
    {
        void OnAuthenticationCompleted(FacebookOAuthToken token);
        void OnAuthenticationFailed(string message, Exception exception);
        void OnAuthenticationCanceled();
    }
}
