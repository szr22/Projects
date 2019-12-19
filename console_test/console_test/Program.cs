using System;
using System.Collections.Generic;
using System.Linq;

namespace console_test
{
    class Program
    {
        private static string _clientId = "QmLeyGrfsF7axpydh2Q6_QhGdJGWx2sU";

        private readonly string _url = "https://api.lyft.com/oauth/token";
        private readonly string _client_id = "xAXOKN8tCoDB";
        private readonly string _client_secret = "<client_secret>";

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine(GetAuthorizeUrl());
        }

        public static string GetAuthorizeUrl(List<string> scopes = null, string state = null, string redirectUri = null)
        {
            //var authorizeUrl = string.Concat("https://login.uber.com/oauth/authorize?response_type=code&client_id=", _clientId);

            var authorizeUrl = string.Concat("https://login.uber.com/oauth/v2/authorize?client_id=", _clientId);

            authorizeUrl += string.Concat("&response_type=code");
            if (scopes != null && scopes.Any())
            {
                authorizeUrl += string.Concat("&scope=", string.Join(" ", scopes));
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                authorizeUrl += string.Concat("&state=", state);
            }

            if (!string.IsNullOrWhiteSpace(redirectUri))
            {
                authorizeUrl += string.Concat("&redirect_uri=", System.Web.HttpUtility.UrlEncode(redirectUri));
            }
            // Result will be https://login.uber.com/oauth/v2/authorize?client_id={client_ID}=code&scope=profile
            return authorizeUrl;
        }
    }
}
