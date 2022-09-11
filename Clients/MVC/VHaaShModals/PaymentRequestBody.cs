using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHaaShAPIModals
{
    // https://devguide.payu.in/api/payments/payment-api/

    public class PaymentRequestBase
    {

        public string ApiUrl { get; set; }


        public string MerchantKey { get; set; }


        public string MerchantSalt { get; set; }


        public string TransactionNumber { get; set; }


        public string SuccessUrl { get; set; }


        public string FailureUrl { get; set; }


        public string Hash { get; set; }
    }

    public class PaymentRequestBody : PaymentRequestBase
    {

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string Mobile { get; set; }


        public string ProductInfo { get; set; }

        public double Amount { get; set; }
    }
}
