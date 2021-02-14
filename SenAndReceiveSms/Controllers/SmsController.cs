using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace SenAndReceiveSms.Controllers
{
    public class SmsController : TwilioController
    {
        public ActionResult SendSms()
        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(ConfigurationManager.AppSettings["MyPhoneNumber"]);
            var from = new PhoneNumber("+15128724385");
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Hello");

            return Content(message.Sid);
        }

        public ActionResult ReceiveSms()
        {
            var response = new MessagingResponse();
            response.Message("Welcome");

            return TwiML(response);
        }
    }
}