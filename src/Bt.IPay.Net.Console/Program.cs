// See https://aka.ms/new-console-template for more information

using Bt.IPay.Net;
using Bt.IPay.Net.General;
using Bt.IPay.Net.Requests;
using Bt.IPay.Net.Requests.Register;


var client = new IpayClient("comunacovasant_api", "comunacovasant_api1");
var data = new RegisterRequest
{
    Currency = IPayCurrency.RON,
    Description = "testBT",
    Amount = 100,// => 15.195,25
    ReturnUrl = "https://ecclients.btrl.ro:5443/payment/merchants/Test_BT/finish.html",
    // JsonParams = new Dictionary<string, string> { { "tipPlata", "IT" },{ "18", "8590" } },
    //JsonParams = "{\"tipPlata\":\"IT\" , \"18\":\"8590\" , \"98\":\"2356\" , \"154\":\"167\"}",
    OrderBundle =
        new OrderBundle
        {
            CustomerDetails = new CustomerDetails
            {
                Phone = "40740123456",
                Email = "mail@test.com",
                Contact = "Vasile Ion ăîîasdsadşţâîăpş",
                BillingInfo = new BillingInfo
                {
                    City = "Cluj",
                    PostAddress = "Str.Sperantei" + Environment.NewLine + " cevăăîş aa",
                    PostalCode = "2345"
                },
                DeliveryInfo = new DeliveryInfo
                {
                    City = "Iasi" + Environment.NewLine + " cevăăîş aa",
                    PostAddress = "M. Eminescu" + Environment.NewLine + " cevăăîş aa",
                }
            }
        }
                    //OrderBundle = "{\"orderCreationDate\":\"2019-05-12\",\"customerDetails\":{\"email\":\"email@test.com\",\"phone\":\"4073119839\",\"contact\":\"contact_text\",\"deliveryInfo\":{\"deliveryType\":\"thistype\",\"country\":\"642\",\"city\":\"Cluj\",\"postAddress\":\"Strada Speraneti nr 132\",\"postalCode\":\"12345\"},\"billingInfo\":{\"deliveryType\":\"thistype\",\"country\":\"642\",\"city\":\"Cluj\",\"postAddress\":\"Strada Speraneti nr 132\",\"postAddress2\":\"Strada Speraneti nr 132\",\"postAddress3\":\"Strada Speraneti nr 132\",\"postalCode\":\"12345\"}}}"
};

var response = await client.Register(data);
Console.WriteLine(response.FormUrl);