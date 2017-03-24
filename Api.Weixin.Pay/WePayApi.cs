using Api.Core.Helpers;
using Api.Core.Logging;
using Api.Weixin.Pay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class WePayApi
    {

        #region 提交被扫支付API

        /// <summary>
        /// 提交被扫支付API
        /// 收银员使用扫码设备读取微信用户刷卡授权码以后，二维码或条码信息传送至商户收银台，
        /// 由商户收银台或者商户后台调用该接口发起支付。
        /// </summary>
        /// <param name="data">提交给被扫支付API的参数</param>
        /// <returns>成功时返回调用结果，其他抛异常</returns>
        public static WePayData Micropay(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/micropay";
            //检测必填参数
            if (!data.IsSet("body"))
            {
                throw new WePayException("提交被扫支付API接口中，缺少必填参数body！");
            }
            else if (!data.IsSet("out_trade_no"))
            {
                throw new WePayException("提交被扫支付API接口中，缺少必填参数out_trade_no！");
            }
            else if (!data.IsSet("total_fee"))
            {
                throw new WePayException("提交被扫支付API接口中，缺少必填参数total_fee！");
            }
            else if (!data.IsSet("auth_code"))
            {
                throw new WePayException("提交被扫支付API接口中，缺少必填参数auth_code！");
            }

            var config = WePayConfigFactory.Get();

            //data.SetValue("spbill_create_ip", config.IP);//终端ip
            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            data.SetValue("sign", data.MakeSign());//签名
            string xml = data.ToXml();

            var start = DateTime.Now;//请求开始时间

            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,MicroPay request : " + xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml);//调用HTTP通信接口以提交数据到API
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,MicroPay response : " + response));
            //Log.Debug("WxPayApi", "MicroPay response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        #endregion

        #region 统一下单
        /// <summary>
        /// 统一下单
        /// </summary>
        /// <param name="data">提交给统一下单API的参数</param>
        /// <returns></returns>
        public static WePayData UnifiedOrder(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            //检测必填参数
            if (!data.IsSet("out_trade_no"))
            {
                throw new WePayException("缺少统一支付接口必填参数out_trade_no！");
            }
            else if (!data.IsSet("body"))
            {
                throw new WePayException("缺少统一支付接口必填参数body！");
            }
            else if (!data.IsSet("total_fee"))
            {
                throw new WePayException("缺少统一支付接口必填参数total_fee！");
            }
            else if (!data.IsSet("trade_type"))
            {
                throw new WePayException("缺少统一支付接口必填参数trade_type！");
            }

            //关联参数
            if (data.GetValue("trade_type").ToString() == "JSAPI" && !data.IsSet("openid"))
            {
                throw new WePayException("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");
            }
            if (data.GetValue("trade_type").ToString() == "NATIVE" && !data.IsSet("product_id"))
            {
                throw new WePayException("统一支付接口中，缺少必填参数product_id！trade_type为JSAPI时，product_id为必填参数！");
            }

            //异步通知url未设置，则使用配置文件中的url
            if (!data.IsSet("notify_url"))
            {
                throw new WePayException("统一支付接口中，缺少必填参数notify_url！");
            }

            var config = WePayConfigFactory.Get();

            data.SetValue(UnifiedOrderFields.appid, config.APPID);//公众账号ID
            data.SetValue(UnifiedOrderFields.mch_id, config.MCHID);//商户号
            //data.SetValue("spbill_create_ip", WxPayConfig.IP);//终端ip
            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名
            string xml = data.ToXml();

            var start = DateTime.Now;

            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,UnfiedOrder request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml);
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,UnfiedOrder response:{0}", response));

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }

        #endregion

        #region 查询订单

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="data">提交给查询订单API的参数</param>
        /// <returns>成功时返回订单查询结果，其他抛异常</returns>
        public static WePayData OrderQuery(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/orderquery";
            //检测必填参数
            if (!data.IsSet("out_trade_no") && !data.IsSet("transaction_id"))
            {
                throw new WePayException("订单查询接口中，out_trade_no、transaction_id至少填一个！");
            }

            var config = WePayConfigFactory.Get();

            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名

            string xml = data.ToXml();

            var start = DateTime.Now;

            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,OrderQuery request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml);//调用HTTP通信接口提交数据
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,OrderQuery response:{0}", response));


            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的数据转化为对象以返回
            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }

        #endregion

        #region 撤销订单API接口

        /// <summary>
        /// 撤销订单API接口
        /// </summary>
        /// <param name="data">提交给撤销订单API接口的参数，out_trade_no和transaction_id必填一个</param>
        /// <returns>成功时返回API调用结果，其他抛异常</returns>
        public static WePayData Reverse(WePayData data, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
            //检测必填参数
            if (!data.IsSet("out_trade_no") && !data.IsSet("transaction_id"))
            {
                throw new WePayException("撤销订单API接口中，参数out_trade_no和transaction_id必须填写一个！");
            }

            var config = WePayConfigFactory.Get();

            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名
            string xml = data.ToXml();

            var start = DateTime.Now;//请求开始时间

            var certpath = HttpContext.Current.Request.PhysicalApplicationPath + config.SSLCERT_PATH;

            //Log.Debug("WxPayApi", "Reverse request : " + xml);
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,Reverse request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml, certpath, config.SSLCERT_PASSWORD);//HttpService.Post(xml, url, true, timeOut);
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,Reverse response:{0}", response));

            //Log.Debug("WxPayApi", "Reverse response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        #endregion

        #region 关闭订单
        public static WePayData CloseOrder(WePayData data, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/closeorder";
            //检测必填参数
            if (!data.IsSet("out_trade_no"))
            {
                throw new WePayException("关闭订单接口中，out_trade_no必填！");
            }

            var config = WePayConfigFactory.Get();

            data.SetValue(CloseOrderFields.appid, config.APPID);//公众账号ID
            data.SetValue(CloseOrderFields.mch_id, config.MCHID);//商户号

            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名
            string xml = data.ToXml();

            var start = DateTime.Now;//请求开始时间
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,CloseOrder request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml);
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,CloseOrder response:{0}", response));

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        #endregion

        #region 申请退款

        /// <summary>
        /// 申请退款
        /// </summary>
        /// <param name="data">提交给申请退款API的参数</param>
        /// <returns>成功时返回接口调用结果，其他抛异常</returns>
        public static WePayData Refund(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            //检测必填参数
            if (!data.IsSet("out_trade_no") && !data.IsSet("transaction_id"))
            {
                throw new WePayException("退款申请接口中，out_trade_no、transaction_id至少填一个！");
            }
            else if (!data.IsSet("out_refund_no"))
            {
                throw new WePayException("退款申请接口中，缺少必填参数out_refund_no！");
            }
            else if (!data.IsSet("total_fee"))
            {
                throw new WePayException("退款申请接口中，缺少必填参数total_fee！");
            }
            else if (!data.IsSet("refund_fee"))
            {
                throw new WePayException("退款申请接口中，缺少必填参数refund_fee！");
            }
            else if (!data.IsSet("op_user_id"))
            {
                throw new WePayException("退款申请接口中，缺少必填参数op_user_id！");
            }
            var config = WePayConfigFactory.Get();

            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            data.SetValue("sign", data.MakeSign());//签名

            string xml = data.ToXml();
            var start = DateTime.Now;

            var certpath = HttpContext.Current.Request.PhysicalApplicationPath + config.SSLCERT_PATH;

            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,Refund request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml, certpath, config.SSLCERT_PASSWORD); //调用HTTP通信接口提交数据到API
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,Refund response:{0}", response));

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        #endregion

        #region 查询退款

        /// <summary>
        /// 查询退款
        /// 提交退款申请后，通过该接口查询退款状态。退款有一定延时，
        /// 用零钱支付的退款20分钟内到账，银行卡支付的退款3个工作日后重新查询退款状态。
        /// out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个
        /// </summary>
        /// <param name="data">提交给查询退款API的参数</param>
        /// <returns>成功时返回，其他抛异常</returns>
        public static WePayData RefundQuery(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/refundquery";
            //检测必填参数
            if (!data.IsSet("out_refund_no") && !data.IsSet("out_trade_no") &&
                !data.IsSet("transaction_id") && !data.IsSet("refund_id"))
            {
                throw new WePayException("退款查询接口中，out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个！");
            }

            var config = WePayConfigFactory.Get();
            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名

            string xml = data.ToXml();

            var start = DateTime.Now;//请求开始时间

            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,RefundQuery request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml); //调用HTTP通信接口以提交数据到API
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,RefundQuery response:{0}", response));

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WePayData result = new WePayData();
            result.FromXml(response);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        #endregion

        #region 下载对账单
        /// <summary>
        /// 下载对账单
        /// </summary>
        /// <param name="data">提交给下载对账单API的参数</param>
        /// <returns>成功时返回，其他抛异常</returns>
        public static WePayData DownloadBill(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/downloadbill";
            //检测必填参数
            if (!data.IsSet("bill_date"))
            {
                throw new WePayException("对账单接口中，缺少必填参数bill_date！");
            }

            var config = WePayConfigFactory.Get();

            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名

            string xml = data.ToXml();

            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,DownloadBill request:{0}", xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml);//调用HTTP通信接口以提交数据到API
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,DownloadBill response:{0}", response));


            WePayData result = new WePayData();
            //若接口调用失败会返回xml格式的结果
            if (response.Substring(0, 5) == "<xml>")
            {
                result.FromXml(response);
            }
            //接口调用成功则返回非xml格式的数据
            else
                result.SetValue("result", response);

            return result;
        }
        #endregion

        #region 测速上报

        /// <summary>
        /// 测速上报
        /// </summary>
        /// <param name="interface_url">接口URL</param>
        /// <param name="data">参数数组</param>
        private static void ReportCostTime(string interface_url, int timeCost, WePayData data)
        {
            var config = WePayConfigFactory.Get();
            //如果不需要进行上报
            if (config.REPORT_LEVENL == 0)
            {
                return;
            }

            //如果仅失败上报
            if (config.REPORT_LEVENL == 1
                && data.IsSet("return_code")
                && data.GetValue("return_code").ToString() == "SUCCESS"
                && data.IsSet("result_code")
                && data.GetValue("result_code").ToString() == "SUCCESS")
            {
                return;
            }

            //上报逻辑
            WePayData report_data = new WePayData();
            report_data.SetValue("interface_url", interface_url);
            report_data.SetValue("execute_time_", timeCost);
            //返回状态码
            if (data.IsSet("return_code"))
            {
                report_data.SetValue("return_code", data.GetValue("return_code"));
            }
            //返回信息
            if (data.IsSet("return_msg"))
            {
                report_data.SetValue("return_msg", data.GetValue("return_msg"));
            }
            //业务结果
            if (data.IsSet("result_code"))
            {
                report_data.SetValue("result_code", data.GetValue("result_code"));
            }
            //错误代码
            if (data.IsSet("err_code"))
            {
                report_data.SetValue("err_code", data.GetValue("err_code"));
            }
            //错误代码描述
            if (data.IsSet("err_code_des"))
            {
                report_data.SetValue("err_code_des", data.GetValue("err_code_des"));
            }
            //商户订单号
            if (data.IsSet("out_trade_no"))
            {
                report_data.SetValue("out_trade_no", data.GetValue("out_trade_no"));
            }
            //设备号
            if (data.IsSet("device_info"))
            {
                report_data.SetValue("device_info", data.GetValue("device_info"));
            }

            try
            {
                Report(report_data);
            }
            catch (WePayException ex)
            {
                //不做任何处理
            }
        }

        /// <summary>
        /// 测速上报接口实现
        /// </summary>
        /// <param name="data">提交给测速上报接口的参数</param>
        /// <returns>成功时返回测速上报接口返回的结果，其他抛异常</returns>
        public static WePayData Report(WePayData data)
        {
            string url = "https://api.mch.weixin.qq.com/payitil/report";
            //检测必填参数
            if (!data.IsSet("interface_url"))
            {
                throw new WePayException("接口URL，缺少必填参数interface_url！");
            }
            if (!data.IsSet("return_code"))
            {
                throw new WePayException("返回状态码，缺少必填参数return_code！");
            }
            if (!data.IsSet("result_code"))
            {
                throw new WePayException("业务结果，缺少必填参数result_code！");
            }
            if (!data.IsSet("user_ip"))
            {
                throw new WePayException("访问接口IP，缺少必填参数user_ip！");
            }
            if (!data.IsSet("execute_time_"))
            {
                throw new WePayException("接口耗时，缺少必填参数execute_time_！");
            }

            var config = WePayConfigFactory.Get();

            data.SetValue("appid", config.APPID);//公众账号ID
            data.SetValue("mch_id", config.MCHID);//商户号
            //data.SetValue("user_ip", config.IP);//终端ip
            data.SetValue("time", DateTime.Now.ToString("yyyyMMddHHmmss"));//商户上报时间	 
            data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeSign());//签名
            string xml = data.ToXml();

            //Log.Info("WxPayApi", "Report request : " + xml);
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,Report request : " + xml));
            string response = HttpHelper.HttpPost.GetResult(url, xml);//HttpService.Post(xml, url, false, timeOut);
            LoggerFactory.GetLogger().Debug(string.Format("WxPayApi,Report response : " + response));
            //Log.Info("WxPayApi", "Report response : " + response);

            WePayData result = new WePayData();
            result.FromXml(response);
            return result;
        }
        #endregion

        #region 生成订单号
        /// <summary>
        /// 根据当前系统时间加随机序列来生成订单号
        /// </summary>
        /// <returns>订单号</returns>
        public static string GenerateOutTradeNo()
        {
            var ran = new Random();
            return string.Format("{0}{1}{2}", WePayConfigFactory.Get().MCHID, DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }
        #endregion

        #region 生成时间戳
        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns>时间戳</returns>
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region 生成随机串
        /// <summary>
        /// 生成随机串，随机串包含字母或数字
        /// </summary>
        /// <returns>随机串</returns>
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        #endregion
    }
}
