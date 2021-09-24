using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var accessToken = new PayPalPlusBLL().AccessToken();

            var payPalPlusPaymentRequest = new PayPalPlusPaymentRequest()
            {
                payer = new PayerPaymentRequest()
                {
                    payment_method = "paypal"
                },
                transactions = new List<TransactionPaymentRequest>()
                {
                    new TransactionPaymentRequest()
                    {
                        amount = new AmountPaymentRequest()
                        {
                            currency = "BRL",
                            total = "549.00",
                            details = new DetailsPaymentRequest()
                            {
                                shipping = "0",
                                subtotal = "549.00",
                                tax = "0"
                            }
                        },
                        payee = new PayeePaymentRequest()
                        {
                            email = "contato@meucurso.com.br",
                        },
                        description = $"1111/3",
                        item_list = new ItemListPaymentRequest()
                    }
                },
                redirect_urls = new RedirectUrlsPaymentRequest()
                {
                    return_url = "https://payments.meucurso.com.br/PayPalPlus/Return",
                    cancel_url = "https://payments.meucurso.com.br/PayPalPlus/Cancel"
                }
            };

            payPalPlusPaymentRequest.transactions[0].item_list.items.Add(
                new ItemPaymentRequest()
                {
                    name = "Intensivo OAB XXXII",
                    quantity = "1",
                    price = "549.00",
                    sku = "INTOABXXXII",
                    currency = "BRL",
                }
            );

            var createPaymentResponse = new PayPalPlusBLL().CreatePayment(accessToken.access_token, payPalPlusPaymentRequest);
            if (createPaymentResponse.success && createPaymentResponse.links.Exists(x => x.rel == "approval_url"))
            {
                //Set PAYID created
                string payPalPaymentId = createPaymentResponse.id;

                var linkPaymentResponse = createPaymentResponse.links.Find(x => x.rel == "approval_url");

                ViewData["Success"] = true;
                ViewData["approvalUrl"] = linkPaymentResponse.href;
                ViewData["Environment"] = "sandbox";
                ViewData["PayerEmail"] = "bruno.dimauro@meucurso.com.br";
                ViewData["PayerFirstName"] = "Bruno";
                ViewData["PayerLastName"] = "Di Mauro Machado";
                ViewData["PayerCPF"] = "40746506813";
                ViewData["PayerPhone"] = "55 11980426523";
            }
        }
    }
}
