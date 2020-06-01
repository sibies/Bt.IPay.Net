using System.Globalization;
using System.Threading.Tasks;
using Bt.IPay.Net.Reqursts;
using Bt.IPay.Net.Responses;
using FluentAssertions;
using Xunit;

namespace Bt.IPay.Net.Tests
{
    public class IpayClientTests
    {
        [Fact]
        public async Task RegisterPreAuthTest()
        {
            var client = new IpayClient("test_api", "test_api1");
            var data = new RegisterRequest
            {
                Currency = IPayCurrency.RON,
                Description = "Test",
                Amount = 1519525,// => 15.195,25
                ReturnUrl = "https://ecclients.btrl.ro:5443/payment/merchants/Test_BT/finish.html",
                CultureInfo = CultureInfo.GetCultureInfo("RO-ro"),
                //JsonParams = "{\"tipPlata\":\"IT\" , \"18\":\"8590\" , \"98\":\"2356\" , \"154\":\"167\"}",
                //OrderBundle = "{\"orderCreationDate\":\"2019-05-12\",\"customerDetails\":{\"email\":\"email@test.com\",\"phone\":\"4073119839\",\"contact\":\"contact_text\",\"deliveryInfo\":{\"deliveryType\":\"thistype\",\"country\":\"642\",\"city\":\"Cluj\",\"postAddress\":\"Strada Speraneti nr 132\",\"postalCode\":\"12345\"},\"billingInfo\":{\"deliveryType\":\"thistype\",\"country\":\"642\",\"city\":\"Cluj\",\"postAddress\":\"Strada Speraneti nr 132\",\"postAddress2\":\"Strada Speraneti nr 132\",\"postAddress3\":\"Strada Speraneti nr 132\",\"postalCode\":\"12345\"}}}"
            };

            var response = await client.Register(data);
            response.Should().NotBeNull();
            response.formUrl.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetOrderStatusExtendedTest()
        {
            var client = new IpayClient("test_api", "test_api1");
            var data = new GetOrderStatusExtendedRequest
            {
                OrderId = "735fdedb-ed78-41f5-8d63-56303722d126"
            };

            var response = await client.GetOrderStatusExtended(data);
            response.Should().NotBeNull();
            response.ActionCode.Should().Be(ActionCode.Succes);
        }
    }
}