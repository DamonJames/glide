using Glide.Data.Interfaces;
using Glide.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Glide.Data.Concrete
{
    public class FacebookAuthenticator : IFacebookAuthenticator
    {
        private readonly OAuth2Authenticator _authenticator;
        private readonly IFacebookAuthenticationDelegate _authenticationDelegate;

        public FacebookAuthenticator(FacebookCredentials facebookCredentials, IFacebookAuthenticationDelegate authenticationDelegate)
        {
            _authenticator = new OAuth2Authenticator(facebookCredentials.ClientId,
                facebookCredentials.Scope, facebookCredentials.AuthoriseUri, facebookCredentials.RedirectUri);
            _authenticationDelegate = authenticationDelegate;

            _authenticator.Completed += OnAuthenticationCompleted;
            _authenticator.Error += OnAuthenticationFailed;
        }

        public OAuth2Authenticator GetAuthenticator()
        {
            return _authenticator;
        }

        public void OnPageLoading(Uri uri)
        {
            _authenticator.OnPageLoading(uri);
        }

        private void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var token = new FacebookOAuthToken
                {
                    AccessToken = e.Account.Properties["access_token"]
                };
                _authenticationDelegate.OnAuthenticationCompleted(token);
            }
            else
            {
                _authenticationDelegate.OnAuthenticationCanceled();
            }
        }

        private void OnAuthenticationFailed(object sender, AuthenticatorErrorEventArgs e)
        {
            _authenticationDelegate.OnAuthenticationFailed(e.Message, e.Exception);
        }
    }
}
