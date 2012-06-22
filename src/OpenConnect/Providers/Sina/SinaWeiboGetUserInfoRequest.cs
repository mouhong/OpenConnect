﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;

using OpenConnect.Utils;

namespace OpenConnect.Providers.Weibo
{
    public class SinaWeiboGetUserInfoRequest : IGetUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public SinaWeiboGetUserInfoRequest()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public SinaWeiboGetUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public UserInfo GetResponse(AppInfo appInfo, string accessToken, string userOpenId)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNullOrEmpty(accessToken, "accessToken");

            if (String.IsNullOrEmpty(userOpenId))
            {
                userOpenId = GetUserIdentity(accessToken);
            }

            var userInfo = GetUserInfoByUserIdentity(accessToken, userOpenId);

            return userInfo;
        }

        private string GetUserIdentity(string accessToken)
        {
            var data = new NameValueCollection().FluentAdd("access_token", accessToken);

            var json = HttpClient.Get("https://api.weibo.com/2/account/get_uid.json", data, Encoding.UTF8);
            var result = (GetUIDResult)JsonSerializer.Deserialize(json, typeof(GetUIDResult));

            return result.uid;
        }

        private UserInfo GetUserInfoByUserIdentity(string accessToken, string uid)
        {
            var data = new NameValueCollection().FluentAdd("access_token", accessToken)
                                                .FluentAdd("uid", uid);

            var json = HttpClient.Get("https://api.weibo.com/2/users/show.json", data, Encoding.UTF8);
            var result = (GetUserInfoResult)JsonSerializer.Deserialize(json, typeof(GetUserInfoResult));

            return result.ToUserInfo();
        }
    }
}