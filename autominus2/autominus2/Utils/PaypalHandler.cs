using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace autominus2.Utils
{
    public static class PaypalHandler
    {
        public static Payment CreatePayment(APIContext apiContext, string redirectUrl, double payAmount)
        {
            var listItems = new ItemList()
            {
                items = new List<Item>()
            };

            listItems.items.Add(new Item()
            {
                name = "Saskaitos pildymas",
                currency = "USD",
                price = payAmount.ToString(),
                quantity = 1.ToString(),
                sku = "sku"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            //Redirects
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };
            var details = new Details()
            {
                tax = "1",
                subtotal = payAmount.ToString()
            };

            var amountA = new Amount()
            {
                currency = "USD",
                total = payAmount.ToString(),
                details = details
            };

            //Create transaction
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Autominus saskaitos pildymas",
                invoice_number = Convert.ToString((new Random()).Next(10000)),
                amount = amountA,
                item_list = listItems
            });


            Payment payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        //ExecutePayment method
        public static Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
                
            };

            Payment payment = new Payment()
            {
                id = paymentId
            };

            return payment.Execute(apiContext, paymentExecution);
        }

        
        //56:02
        //public ActionResult PaymentWithPaypal()
        //{
        //    APIContext apiContext = PaypalConfiguration.GetAPIContext();

        //    try
        //    {
        //        //string payerId = Request.params["PayerID"];
        //        if(string.IsNullOrEmpty(payerId))
        //        {
        //            string baseUrI = Request.Url.scheme = "://" + Request.Url.Authority + "PaymentWithpaypal?";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}