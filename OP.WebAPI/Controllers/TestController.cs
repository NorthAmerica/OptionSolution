using Newtonsoft.Json;
using OP.WebAPI.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace OP.WebAPI.Controllers
{
    /// <summary>
    /// 测试用WEB API
    /// </summary>
    public class TestController : ApiController
    {
        /// <summary>
        /// 返回模拟成交数据
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public HttpResponseMessage PostqueryInsureOrder(QueryInsureOrderModel json)
        {
            try
            {
                if (json!=null)
                {
                    ReturnOrderModel ret = new ReturnOrderModel();
                    List<TradeOrder> lto = new List<TradeOrder>();
                    ret.Result = "1";
                    TradeOrder to = new TradeOrder();
                    to.OptionsProductID = "3AC52347-430C-E611-9C2F-5404A64F5E65";
                    to.PayTime = "2016-05-03 09:09:00";
                    to.BusinessInfo = "test111";
                    to.BusinessNo = "test111";
                    to.Charge = 12;
                    to.TradeNum = 1;
                    to.TradePrice = 32;
                    
                    lto.Add(to);
                    TradeOrder to1 = new TradeOrder();
                    to1.OptionsProductID = "3AC52347-430C-E611-9C2F-5404A64F5E65";
                    to1.PayTime = "2016-05-03 09:09:00";
                    to1.BusinessInfo = "test111";
                    to1.BusinessNo = "test111";
                    to1.Charge = 12;
                    to1.TradeNum = 1;
                    to1.TradePrice = 32;

                    lto.Add(to1);
                    ret.orders = lto;
                    string str = JsonConvert.SerializeObject(ret);
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                }
                else
                {
                    ReturnOrderModel ret = new ReturnOrderModel();
                    ret.Result = "0";
                    ret.Message = "json数据为空";
                    string str = JsonConvert.SerializeObject(ret);
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                ReturnOrderModel ret = new ReturnOrderModel();
                ret.Result = "0";
                ret.Message = ex.Message;
                string str = JsonConvert.SerializeObject(ret);
                HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
                
            }
            
        }

        public HttpResponseMessage PostConfirmOrder(ReturnConfirmOrder json)
        {
            try
            {
                if (json != null)
                {
                    ReturnOrderModel ret = new ReturnOrderModel();
                    ret.Result = "1";
                    ret.Message = "";
                    string str = JsonConvert.SerializeObject(ret);
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                }
                else
                {
                    ReturnOrderModel ret = new ReturnOrderModel();
                    ret.Result = "0";
                    ret.Message = "json数据为空";
                    string str = JsonConvert.SerializeObject(ret);
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                }
            }
            catch (Exception ex)
            {
                ReturnOrderModel ret = new ReturnOrderModel();
                ret.Result = "0";
                ret.Message = ex.Message;
                string str = JsonConvert.SerializeObject(ret);
                HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                return result;
            }
        }
    }
}
