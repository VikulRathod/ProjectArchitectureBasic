using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VHaaShAPIModals;

namespace VHaaSh.API.Client.HttpClients.Payment
{
    public interface IPaymentHttpClient
    {
        HttpResponseMessage CreatePayment(PaymentRequestBody paymentRequestBody);
    }
}
