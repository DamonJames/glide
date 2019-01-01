using System;

namespace Glide.Models
{
    public class FacebookCredentials
    {
        public string ClientId { get; set; }
        public Uri RedirectUri { get; set; }
        public Uri AuthoriseUri { get; set; }
        public string Scope { get; set; }
    }
}
