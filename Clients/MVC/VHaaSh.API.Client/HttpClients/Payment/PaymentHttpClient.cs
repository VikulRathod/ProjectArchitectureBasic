using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VHaaSh.API.Client.Infrastructure;
using VHaaShAPIModals;

namespace VHaaSh.API.Client.HttpClients.Payment
{
    public class PaymentHttpClient : BaseHttpClient, IPaymentHttpClient
    {
        public PaymentHttpClient() : base(AppConfig.VHaaShWebApiEndPointAddress)
        {

        }

        public HttpResponseMessage CreatePayment(PaymentRequestBody paymentRequestBody)
        {
            using (ServiceClient)
            {
                var resource = string.Format("api/payment");

                var response = ServiceClient.PostAsJsonAsync(resource, paymentRequestBody).Result;

                if (response.IsSuccessStatusCode)
                    return response;

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
