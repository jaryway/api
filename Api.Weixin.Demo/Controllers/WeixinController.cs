using Api.Core.Helpers;
using Api.Core.Logging;
using Api.Weixin.Demo.MessageProcessors;
using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace Api.Weixin.Demo.Controllers
{
    public class WeixinController : Controller
    {
        /// <summary>
        /// 用于验证URL有效性
        /// </summary>
        /// <returns></returns>
        // GET: Weixin
        public ActionResult Callback(string corpId, int agentId, string msg_signature, string timestamp, string nonce, string echostr)
        {
            LoggerFactory.GetLogger().Debug(string.Format("&msg_signature={0}&timestamp={1}&nonce={2}&echostr={3}", msg_signature, timestamp, nonce, echostr));

            var token = ConfigurationManager.AppSettings[string.Format("Token-CorpId:{0}-AgentId:{1}", corpId, agentId)];
            var encodingAESKey = ConfigurationManager.AppSettings[string.Format("EncodingAESKey-CorpId:{0}-AgentId:{1}", corpId, agentId)];

            WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
            int ret = 0;
            string sEchoStr = "";
            ret = wxcpt.VerifyURL(msg_signature, timestamp, nonce, echostr, ref sEchoStr);
            if (ret != 0)
                return Content("ERR: VerifyURL fail, ret: " + ret);

            return Content(sEchoStr);
        }


        [HttpPost]
        public ActionResult Callback(string corpId, int agentId, string msg_signature, string timestamp, string nonce)
        {
            try
            {
                var token = ConfigurationManager.AppSettings[string.Format("Token-CorpId:{0}-AgentId:{1}", corpId, agentId)];
                var encodingAESKey = ConfigurationManager.AppSettings[string.Format("EncodingAESKey-CorpId:{0}-AgentId:{1}", corpId, agentId)];

                //2.验证签名是否正确
                if (SignHelper.Check(msg_signature, timestamp, nonce, token))
                {
                    LoggerFactory.GetLogger().Error("签名错误");
                    return Content("签名错误");
                }

                //3.获取加密消息
                string postData = string.Empty;

                //读取post过来的xml文件流
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    postData = reader.ReadToEnd();
                    reader.Close();
                }
                string desMessage = string.Empty;
                WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
                int decryptResult = wxcpt.DecryptMsg(msg_signature, timestamp, nonce, postData, ref desMessage);
                if (decryptResult != 0)
                    return Content("解密失败");

                //LoggerFactory.GetLogger().Error(string.Format("desMessage:{0}", desMessage));

                //处理消息
                var processor = new ReceiveMessageProcessor(desMessage);
                var response = processor.Process();

                string encryptMsg;
                response.EncryptMessage(wxcpt, token, out encryptMsg);
                //LoggerFactory.GetLogger().Error(string.Format("encryptMsg:{0}", encryptMsg));
                return Content(encryptMsg);

            }
            catch (Exception ex)
            {
                LoggerFactory.GetLogger().Error(ex, "处理消息出错了");

            }
            return Content("123");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Auth()
        {
            return View();
        }
    }
}