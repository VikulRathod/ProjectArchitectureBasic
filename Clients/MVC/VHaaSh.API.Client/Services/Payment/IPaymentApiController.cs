using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VHaaShAPIModals;

namespace VHaaSh.API.Client.Services.Payment
{
    public interface IPaymentApiController
    {
        HttpResponseMessage CreatePayment(PaymentRequestBody paymentRequestBody);
    }
}
