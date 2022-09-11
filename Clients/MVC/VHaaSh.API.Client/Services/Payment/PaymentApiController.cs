using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VHaaSh.API.Client.HttpClients.Payment;
using VHaaShAPIModals;

namespace VHaaSh.API.Client.Services.Payment
{
    public class PaymentApiController : System.Web.Http.ApiController, IPaymentApiController
    {
        private IPaymentHttpClient _paymentHttpClient;
        public PaymentApiController(IPaymentHttpClient registerHttpClient)
        {
            _paymentHttpClient = registerHttpClient;
        }

        public HttpResponseMessage CreatePayment(PaymentRequestBody paymentRequestBody)
        {
            var response = _paymentHttpClient.CreatePayment(paymentRequestBody);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }
    }
}
