using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Google
{
    public class GoogleAccessTokenRetriver : OAuthAccessTokenRetriever
    {
        public GoogleAccessTokenRetriver()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public GoogleAccessTokenRetriver(IHttpClient httpClient)
            : base("https://accounts.google.com/o/oauth2/token", httpClient)
        {
        }

        protected override System.Collections.Specialized.NameValueCollection BuildRequestParameters(AppInfo appInfo, string authCode, string state)
        {
            // if passing 'state' parameter, google will return 400 bad request error
            var data = base.BuildRequestParameters(appInfo, authCode, state);
            data.Remove("state");

            return data;
        }
    }
}
