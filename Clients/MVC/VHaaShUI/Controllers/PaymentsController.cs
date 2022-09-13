using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHaaSh.API.Client.Services.Payment;
using VHaaSh.UI.BLL.Logs;
using VHaaShAPIModals;

namespace VHaaSh.WEB.Controllers
{
    public class PaymentsController : Controller
    {
        private IPaymentApiController _paymentApi;
        private IApplicationLogsBL _logs;

        public PaymentsController(IPaymentApiController paymentApi,
            IApplicationLogsBL logs)
        {
            _paymentApi = paymentApi;
            _logs = logs;
        }

        // GET: Payments
        public ActionResult Index()
        {

            //INDEX ACTION METHOD LOGIC
            PaymentRequestBody paymentRequestBody = new PaymentRequestBody()
            {
                FirstName = "Aniket", LastName = "Patil",
                Email = "vikul.rathod.net@gmail.com", Mobile = "9527788887",
                ProductInfo = "Test Demo In Meeting", Amount = 100,
                SuccessUrl = "http://localhost:49974/Payments/Success", 
                FailureUrl = "http://localhost:49974/Payments/Failed"
            };

            var response = _paymentApi.CreatePayment(paymentRequestBody);

            if(response != null && response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                paymentRequestBody = JsonConvert.
                    DeserializeObject<PaymentRequestBody>(responseBody);
            }

            return View(paymentRequestBody);
        }

        // GET: Payments
        public ActionResult Success()
        {
            // need to call api success method

            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}