## 企业号|公众号|钉钉|蓝信的API类库
这是一个基于企业号|公众号|钉钉|蓝信开发文档开发的用于快速访问这些API的类库。

## 如何使用
1.引入核心文件Api.Core.dll

2.引入相应的文件，如访问微信企业号API相关接口，就引入 Api.Weixin.Qy.dll文件；

3.开始使用

```cs
// a.获取access_token
var access_token = TokenManager.Instance().
                 GetAccessToken(corpId, corpSecret);
// b.调相应的API
ApiHelper.Instance().CreateUser(access_token, new Qy.CreateUserRequest
{
    email = "",

});
```
4.如何在一个类中同时使用多个类库，如在一个类中同时使用企业号和公众号的dll
添加using前缀即可
``` cs
using Api.Core;
using qy = Api.Weixin.Qy;
using mp = Api.Weixin.Mp;
// 方法中使用
qy.ApiHelper.Instance().CreateUser(access_token, new Qy.CreateUserRequest
{
	email = "",

});
mp.ApiHelper.Instance().xxxxx ....
```


## 如何使用日志功能
该类库使用的是基于log4net的日志功能，请现在Global文件中注册日志配置文件

请参考[Demo](https://github.com/jaryway/api/tree/master/Api.Weixin.Demo)中的配置

``` cs

protected void Application_Start()
{
    // AreaRegistration.RegisterAllAreas();
    // RouteConfig.RegisterRoutes(RouteTable.Routes);

    //为了调试方便加入日志，否则启用NullLogger
    LoggerFactory.InitializeLogFactory(new Log4NetLoggerFactoryAdapter(Server.MapPath("~/app_data/log4net.config")));
    LoggerFactory.GetLogger().Debug("站点启动");
}

```

## 目录结构
``` txt
+ Api.Core/               -- 核心文件，存放一些公用的方法
- Api.Weixin.Qy/          -- 微信企业号相关文件
    + Messages/           -- 请求和响应类（Request/Result）
    + Models/             -- 请求和响应类中使用到的一些子类
    - ApiHelper.cs        -- API方法实现
    - TokenManager.cs     -- Token管理器实现
```
## 如何添加API方法

1.在相应项目Messages/中添加Request类，如CreateUserRequest,写上对应的字段属性

2.在ApiHelper中添加相应的方法

``` cs
/// <summary>
/// 创建成员
/// </summary>
/// <param name="request">要添加的用户信息</param>
/// <param name="access_token">调用接口凭证</param>
/// <returns></returns>
public JsonResult CreateUser(string access_token, CreateUserRequest request)
{
	string url = string.Format("{0}user/create?access_token={1}", baseUrl, access_token);
	return HttpHelper.HttpPost.GetJsonResult<CreateUserRequest, JsonResult>(url, request);
}

```
更多请参考[ApiHelper.cs](https://github.com/jaryway/api/blob/master/Api.Weixin.Qy/ApiHelper.cs)文件

## License 
The MIT License(http://opensource.org/licenses/MIT)
