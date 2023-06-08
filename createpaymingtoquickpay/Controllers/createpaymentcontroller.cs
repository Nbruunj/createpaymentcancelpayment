using createpaymingtoquickpay.model;
using Microsoft.AspNetCore.Mvc;

namespace createpaymingtoquickpay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class createpaymentcontroller : Controller
    {
        [HttpPost]

        public IActionResult ProcessingDynamicdata([FromBody] dynamics dynamics)
        {
            
            CreateQuickpayPayment createQuickpayPayment = new CreateQuickpayPayment();

            
            var apikey = dynamics.nal_kundesquickpayapikey_name;
            var orderid = dynamics.orderid;
            var kundeurl = dynamics.nal_kundeurl_name;
            var price = dynamics.nal_Price_Name;
            var username = dynamics.nal_User_Name;
            var email = dynamics.nal_Email_Name;
            

            createQuickpayPayment.CreatePayment(apikey, orderid, kundeurl, price, username,email);




            return Ok();
        }

        [HttpPut]

        public IActionResult ProcessingPutrequestDynamicdata([FromBody] dynamics dynamics)
        {


            cancelorrefundpayment cancelorrefundpayment = new cancelorrefundpayment();
            var orderid = dynamics.orderid;
            var paymentstatus = dynamics.nal_Paymentstatus_Name;
            var apikey = dynamics.nal_kundesquickpayapikey_name;
            cancelorrefundpayment.cancelorrefundkursist(orderid, apikey);




            return Ok();
        }


    }
}
