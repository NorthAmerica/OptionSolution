using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OP.Entities;
using OP.Repository;
using OP.Repository.Implementations;
using OP.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace OP.WebAPI.Controllers
{
    public class KwinerController : ApiController
    {
        public static readonly InterfaceOptionsProductRepository OptionsProductRepository = new OptionsProductRepository();
        public static readonly InterfaceFuturePriceRepository FuturePriceRepository = new FuturePriceRepository();
        public static readonly InterfaceRiseRoleRepository RiseRoleRepository = new RiseRoleRepository();
        public static readonly InterfaceFallRoleRepository FallRoleRepository = new FallRoleRepository();
        public static readonly InterfaceTdaysRepository TdaysRepository = new TdaysRepository();
        public static readonly InterfaceONOFFSetRepository ONOFFSetRepository = new ONOFFSetRepository();
        public static readonly InterfaceONTimeRepository ONTimeRepository = new ONTimeRepository();
        public static readonly InterfaceEventLogRepository LogRepository = new EventLogRepository();
        //public static readonly InterfaceEventLogRepository LogRepository = new EventLogRepository();

        /// <summary>
        /// 得到正在发行的产品
        /// </summary>
        /// <returns></returns>
        //public OPM GetAllProducts()
        //{
        //    OPM opm111 = new OPM();
        //    List<OptionsProductModel> lopm = new List<OptionsProductModel>();

        //    IEnumerable<OptionsProduct> iop = OptionsProductRepository.FindAll().Where(p => p.Status == 1);
        //    if (iop != null && iop.Count() != 0)
        //    {
        //        foreach (var item in iop)
        //        {
        //            OptionsProductModel opm = new OptionsProductModel();
        //            opm.addDate = Convert.ToDateTime(item.AddDate).ToString("yyyy-MM-dd HH:mm:ss");
        //            opm.beginDate = Convert.ToDateTime(item.BeginDate).ToString("yyyy-MM-dd HH:mm:ss");
        //            opm.charge = item.Charge;
        //            opm.chargeType = item.ChargeType;
        //            opm.deadline = item.Deadline;
        //            opm.endDate = string.Empty;
        //            opm.callPriceType = item.CallPriceType;
        //            //opm.Margin = item.Margin;
        //            //opm.MarginType = item.MarginType;
        //            opm.maxNum = item.MaxNum;
        //            opm.optionsProductID = item.OptionsProductID;
        //            opm.optionType = item.OptionType;
        //            opm.partnerName = item.PartnerName;
        //            opm.price = item.Price;
        //            opm.priceType = item.PriceType;
        //            opm.amountType = item.AmountType;
        //            opm.productName = item.ProductName;
        //            opm.status = item.Status;
        //            opm.unit = item.Unit;
        //            opm.productDesc = item.ProductDesc;
        //            opm.productDtlDesc = item.ProductDtlDesc;
        //            opm.formula = item.Formula;
        //            opm.productUrl = item.ProductUrl;
        //            opm.contract = item.Contract;
        //            opm.contractChs = item.ContractChs;
        //            List<FallRoleModel> lfrm = new List<FallRoleModel>();
        //            List<FallRole> lfr = FallRoleRepository.FindList(f => f.OptionsProductID == item.OptionsProductID, string.Empty, false).ToList();
        //            if (lfr != null && lfr.Count() != 0)
        //            {
        //                foreach (var fall in lfr)
        //                {
        //                    FallRoleModel frm = new FallRoleModel();
        //                    frm.compensateNum = fall.CompensateNum;
        //                    frm.compensateType = fall.CompensateType;
        //                    frm.createDate = Convert.ToDateTime(fall.CreateDate).ToString("yyyy-MM-dd HH:mm:ss");
        //                    frm.down = fall.Down;
        //                    frm.fallRoleID = fall.FallRoleID;
        //                    frm.fallRoleName = fall.FallRoleName;
        //                    frm.optionsProductID = fall.OptionsProductID;
        //                    frm.partType = fall.PartType;
        //                    frm.topCompensateNum = fall.TopCompensateNum;
        //                    frm.topCompensateType = fall.TopCompensateType;
        //                    frm.up = fall.Up;
        //                    frm.upDownType = fall.UpDownType;
        //                    lfrm.Add(frm);
        //                }
        //            }
        //            opm.fallRole = lfrm;
        //            List<RiseRoleModel> lrrm = new List<RiseRoleModel>();
        //            List<RiseRole> lrr = RiseRoleRepository.FindList(r => r.OptionsProductID == item.OptionsProductID, string.Empty, false).ToList();
        //            if (lrr != null && lrr.Count() != 0)
        //            {
        //                foreach (var rise in lrr)
        //                {
        //                    RiseRoleModel rrm = new RiseRoleModel();
        //                    rrm.createDate = Convert.ToDateTime(rise.CreateDate).ToString("yyyy-MM-dd HH:mm:ss");
        //                    rrm.dividendNum = rise.DividendNum;
        //                    rrm.dividendType = rise.DividendType;
        //                    rrm.down = rise.Down;
        //                    rrm.optionsProductID = rise.OptionsProductID;
        //                    rrm.partType = rise.PartType;
        //                    rrm.riseRoleID = rise.RiseRoleID;
        //                    rrm.riseRoleName = rise.RiseRoleName;
        //                    rrm.topDividendNum = rise.TopDividendNum;
        //                    rrm.topDividendType = rise.TopDividendType;
        //                    rrm.up = rise.Up;
        //                    rrm.upDownType = rise.UpDownType;
        //                    lrrm.Add(rrm);
        //                }
        //            }
        //            opm.riseRole = lrrm;
        //            lopm.Add(opm);
        //        }
        //        opm111.products = lopm;
        //    }

        //    return opm111;
        //}
        //private static object o = new object();
        /// <summary>
        /// 第三方取得期货价格
        /// 异步操作
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostFuturePriceByDate(HttpRequestMessage request)
        {
            try
            {
                string loginjson = request.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(loginjson))
                {
                    return await Task.Run(async () =>
                    {
                        RequestFuturePriceModel json = JsonConvert.DeserializeObject<RequestFuturePriceModel>(DESEncrypt.DesDecrypt(loginjson));
                        ReturnFuturePriceModel RFPM = new ReturnFuturePriceModel();
                        List<RFuturePrice> LFP = new List<RFuturePrice>();
                        List<DateTime> alldays = GetAllDays(Convert.ToDateTime(json.StartDate), Convert.ToDateTime(json.EndDate));
                        foreach (DateTime day in alldays)
                        {
                            string sday = day.ToString("yyyy-MM-dd");

                            FuturePrice price = await FuturePriceRepository.FindAsync(p => p.TradeCode == json.Contract && p.Date == sday);
                            if (price != null)
                            {
                                LFP.Add(new RFuturePrice { date = sday, price = price.Price });
                            }
                        }
                        RFPM.datas = LFP;
                        RFPM.result = "1";
                        RFPM.message = string.Empty;
                        string str = DESEncrypt.DesEncrypt(JsonConvert.SerializeObject(RFPM));
                        HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                        return result;
                    });

                }
                else
                {
                    string str = DESEncrypt.DesEncrypt("{\"result\":\"0\",\"message\":\"json为空\"}");
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                }

            }
            catch (Exception ex)
            {
                string str = DESEncrypt.DesEncrypt("{\"result\":\"0\",\"message\":\"" + ex.Message + "\"}");
                HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                LogRepository.Add(new EventLog() { Name = "第三方", Date = DateTime.Now.ToLocalTime(), Event = "取得期货价格失败" + ex.Message });
                return result;
            }

        }

        #region 获取某段日期范围内的所有日期
        /// <summary> 
        /// 获取某段日期范围内的所有日期，以数组形式返回  
        /// </summary>  
        /// <param name="dt1">开始日期</param>  
        /// <param name="dt2">结束日期</param>  
        /// <returns></returns>  
        private List<DateTime> GetAllDays(DateTime dt1, DateTime dt2)
        {
            List<DateTime> listDays = new List<DateTime>();
            DateTime dtDay = new DateTime();
            for (dtDay = dt1; dtDay.CompareTo(dt2) <= 0; dtDay = dtDay.AddDays(1))
            {
                listDays.Add(dtDay);
            }
            return listDays;
        }
        #endregion
        /// <summary>
        /// 获取全局是否可购买设置
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostIsCanBuy()
        {
            try
            {
                return await Task.Run(() =>
                {
                    //status=0 停用 不能购买
                    //status=1 启用 可以购买
                    int status = 0;
                    ONOFFSet set = ONOFFSetRepository.FindAll().First();
                    if (set.ONOFFMode == 0)
                    {
                        if (set.HandSwitch)
                        {
                            status = 1;
                        }
                        else
                        {
                            status = 0;
                        }
                    }
                    else
                    {
                        List<ONTime> lontime = ONTimeRepository.FindAll().ToList();
                        foreach (var ontime in lontime)
                        {
                            DateTime BeginTime = Convert.ToDateTime(ontime.BeginTime.ToShortTimeString());
                            DateTime EndTime = Convert.ToDateTime(ontime.EndTime.ToShortTimeString());
                            if (BeginTime <= DateTime.Now && DateTime.Now <= EndTime)
                            {
                                status = 1;
                                break;
                            }
                            status = 0;
                        }
                    }
                    string str = DESEncrypt.DesEncrypt("{\"result\":\"1\",\"isCanBuy\":\"" + status.ToString() + "\"}");
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                });

            }
            catch (Exception ex)
            {
                string str = DESEncrypt.DesEncrypt("{\"result\":\"0\",\"message\":\"" + ex.Message + "\"}");
                HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                LogRepository.Add(new EventLog() { Name = "第三方", Date = DateTime.Now.ToLocalTime(), Event = "获取全局是否可购买设置失败" + ex.Message });
                return result;
            }
        }
        /// <summary>
        /// 联创获取到期日期
        /// 异步操作
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostDates(HttpRequestMessage request)
        {
            try
            {
                string loginjson = request.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(loginjson))
                {
                    //return await GetResult(json);
                    return await Task.Run(async () =>
                    {
                        RequestDateModel json = JsonConvert.DeserializeObject<RequestDateModel>(DESEncrypt.DesDecrypt(loginjson));
                        ReturnDateModel rdm = new ReturnDateModel();
                        string keyTime = ConfigurationManager.AppSettings["KeyTime"];
                        List<Dates> date = new List<Dates>();
                        foreach (RequestDate item in json.datas)
                        {
                            Guid id = new Guid(item.optionsProductId);
                            OptionsProduct op = await OptionsProductRepository.FindAsync(p => p.OptionsProductID == id);
                            int Deadline = op.Deadline;
                            string TradeDate = item.tradeDate;
                            string BeginDate = string.Empty;
                            //如果时间在14：30之前成交的
                            if (DateTime.Compare(Convert.ToDateTime(TradeDate), Convert.ToDateTime(Convert.ToDateTime(TradeDate).ToString("yyyy-MM-dd") + " "+ keyTime)) <= 0)
                            {
                                string STradeDate = Convert.ToDateTime(TradeDate).ToString("yyyy-MM-dd");
                                while (true)
                                {
                                    if (TdaysRepository.FindAsync(t => t.Tdays == STradeDate) == null)//没有查询到对应交易日，说明不是交易日,向后推一天
                                    {
                                        STradeDate = Convert.ToDateTime(STradeDate).AddDays(1).ToString("yyyy-MM-dd");
                                    }
                                    else//是交易日，设置开始时间
                                    {
                                        BeginDate = STradeDate;
                                        break;
                                    }
                                }


                            }//如果是在14：30之后成交的
                            else
                            {
                                string STradeDate = Convert.ToDateTime(TradeDate).AddDays(1).ToString("yyyy-MM-dd");
                                while (true)
                                {
                                    //Tday t1 = TdaysRepository.FindNoTracking(t => t.Tdays == STradeDate);
                                    if (TdaysRepository.FindAsync(t => t.Tdays == STradeDate) == null)//没有查询到对应交易日，说明不是交易日,向后推一天
                                    {
                                        STradeDate = Convert.ToDateTime(STradeDate).AddDays(1).ToString("yyyy-MM-dd");
                                    }
                                    else//是交易日，设置开始时间
                                    {
                                        BeginDate = STradeDate;
                                        break;
                                    }
                                }
                            }
                            string EndDate = string.Empty;
                            string TryEndDate = Convert.ToDateTime(BeginDate).AddDays(Deadline).ToString("yyyy-MM-dd");
                            while (true)
                            {
                                if (TdaysRepository.FindAsync(t => t.Tdays == TryEndDate) == null)//没有查询到对应交易日，说明不是交易日,向前推一天
                                {
                                    TryEndDate = Convert.ToDateTime(TryEndDate).AddDays(-1).ToString("yyyy-MM-dd");
                                }
                                else//是交易日，设置到期时间
                                {
                                    EndDate = TryEndDate;
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(BeginDate) && !string.IsNullOrEmpty(EndDate))
                            {
                                date.Add(new Dates { startDate = BeginDate, endDate = EndDate });
                            }
                            else
                            {
                                throw new Exception("开始日期或结束日期为空。请检查数据。");
                            }

                        }


                        //testdate.Add(new Dates { startDate = DateTime.Now.ToString("yyyy-MM-dd"), endDate = DateTime.Now.ToString("yyyy-MM-dd") });
                        //rdm.datas = testdate;
                        rdm.datas = date;
                        rdm.Result = "1";
                        string str = DESEncrypt.DesEncrypt(JsonConvert.SerializeObject(rdm));
                        HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                        return result;
                    });
                }
                else
                {
                    string str = DESEncrypt.DesEncrypt("{\"result\":\"0\",\"message\":\"传送过来的json为空\"}");
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;
                }

            }
            catch (Exception ex)
            {
                string str = DESEncrypt.DesEncrypt("{\"result\":\"0\",\"message\":\"" + ex.Message + "\"}");
                HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                LogRepository.Add(new EventLog() { Name = "第三方", Date = DateTime.Now.ToLocalTime(), Event = "获取到期日期失败" + ex.Message });
                return result;
            }
        }
    }
}
