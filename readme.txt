# OpenConnect

OpenConnect is a library aimed to provide an abstraction over different OAuth 2.0 based login service providers. It's written in C# and supports Windows Live Connect, QQ Login, Sina Weibo Connect, Renren Connect, etc.

## How to use?

	// 1. Create app in your connect service provider, for example, Google
	var appInfo = new AppInfo(appId, appSecret, scope, redirectUri);

	// 2. Instanciate a new OpenConnectClient instance
	var client = new OpenConnectClient(appInfo, new GoogleOpenConnectProvider());

	// 3. Build login url, and show it as a hyperlink in your website
	var loginUrl = client.GetAuthUrl(null, RepsonseType.Code);

	// 4. Visitors click login button -> go to login url -> enter username/password to login
	// 5. Google redirects to your "redirectUri" with the authorization code

	// 6. Retrieve access token with the authorization code returned from Google
	var accessToken = client.GetAccessToken(autoCode);

	// 7. Retrieve user information with the returned access token in step 6
	var userInfo = client.GetUserInfo(accessToken);

	// 8. Play with the returned user information
	var nickName = userInfo.NickName;

## Setup sample application:

Step 1 - Edit windows host file, add a new record: 127.0.0.1	test.sigcms.com

Step 2 - Create a website in IIS with domain "test.sigcms.com", and set website physical path to OpenConnect.MvcExample project;

Step 3 - Open /src/OpenConnect.sln in Visual Studio 2010;

Step 4 - Run OpenConnect.MvcExample project in Visual Studio;

## Resources:

Author's Blog (Chinese): http://www.cnblogs.com/mouhong-lin/
