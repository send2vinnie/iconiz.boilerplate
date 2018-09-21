using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.UI;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Castle.Core.Logging;
using Abp.Configuration;
using Iconiz.Boilerplate.Configuration;

namespace Iconiz.Boilerplate.Identity
{
    public class SmsSender : ISmsSender, ITransientDependency
    {
        public ILogger Logger { get; set; }
        private IClientProfile profile;
        private readonly ISettingManager _settingManager;

        public SmsSender(ISettingManager settingManager)
        {
            Logger = NullLogger.Instance;
            _settingManager = settingManager;
            profile = DefaultProfile.GetProfile("cn-hangzhou",
                _settingManager.GetSettingValue(AppSettings.SMSManagement.AppKey),
                _settingManager.GetSettingValue(AppSettings.SMSManagement.AppSecret));
        }

        public void Send(string to, string templateCode, string templateParams)
        {
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", "Dysmsapi", "dysmsapi.aliyuncs.com");
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = to;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = _settingManager.GetSettingValue(AppSettings.SMSManagement.SignName);
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = templateCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = templateParams;
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                //request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                Logger.Info("发送返回：" + sendSmsResponse.Message);
            }
            catch (ServerException e)
            {
                throw new UserFriendlyException("短信发送失败",
                    new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                        to,
                        e.ErrorCode,
                        e.Message)));
            }
            catch (ClientException e)
            {
                throw new UserFriendlyException("短信发送失败",
                    new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                        to,
                        e.ErrorCode,
                        e.Message)));
            }
        }

        public async Task SendAsync(string to, string templateCode, string templateParams)
        {
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", "Dysmsapi", "dysmsapi.aliyuncs.com");
            var task = new Task(() =>
            {
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest request = new SendSmsRequest();
                try
                {
                    //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                    request.PhoneNumbers = to;
                    //必填:短信签名-可在短信控制台中找到
                    request.SignName = _settingManager.GetSettingValue(AppSettings.SMSManagement.SignName);
                    //必填:短信模板-可在短信控制台中找到
                    request.TemplateCode = templateCode;
                    //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                    request.TemplateParam = templateParams;
                    //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                    //request.OutId = "yourOutId";
                    //请求失败这里会抛ClientException异常
                    SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                    Logger.Info("发送返回：" + sendSmsResponse.Message);
                }
                catch (ServerException e)
                {
                    throw new UserFriendlyException("短信发送失败",
                        new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                            to,
                            e.ErrorCode,
                            e.Message)));
                }
                catch (ClientException e)
                {
                    throw new UserFriendlyException("短信发送失败",
                        new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                            to,
                            e.ErrorCode,
                            e.Message)));
                }
            });

            task.Start();
        }
    }
}