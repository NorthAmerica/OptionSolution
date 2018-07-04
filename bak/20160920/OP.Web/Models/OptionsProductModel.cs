using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.Web.Models
{
    /// <summary>
    /// 传送出去 产品模型
    /// </summary>
    public class OPM
    {
        public List<OptionsProductModel> products { get; set; }
    }
    /// <summary>
    /// 产品模型
    /// </summary>
    public class OptionsProductModel
    {
        public Guid optionsProductID { get; set; }

        public string partnerName { get; set; }

        public string productName { get; set; }
        public string productDesc { get; set; }
        public string productDtlDesc { get; set; }
        public string closingPriceDesc { get; set; }
        public string formula { get; set; }
        public string productUrl { get; set; }
        public string contract { get; set; }
        public string contractChs { get; set; }
        /// <summary>
        /// 期权类型决定不同算法
        /// </summary>
        public string optionType { get; set; }
        public string callPriceType { get; set; }

        public string addDate { get; set; }

        public string beginDate { get; set; }

        public string endDate { get; set; }

        public int deadline { get; set; }

        public string unit { get; set; }

        public decimal charge { get; set; }

        public string chargeType { get; set; }

        public decimal price { get; set; }
        public string priceType { get; set; }
        public string amountType { get; set; }
        //public decimal Margin { get; set; }

        //public string MarginType { get; set; }

        public int maxNum { get; set; }
        /// <summary>
        /// 状态分为 0初始化 1启用 2停用
        /// </summary>
        public int status { get; set; }

        public List<FallRoleModel> fallRole { get; set; }

        public List<RiseRoleModel> riseRole { get; set; }

    }
    /// <summary>
    /// 下跌规则模型
    /// </summary>
    public class FallRoleModel
    {
        public Guid fallRoleID { get; set; }

        public string fallRoleName { get; set; }

        public string createDate { get; set; }

        public decimal up { get; set; }

        public decimal down { get; set; }
        /// <summary>
        /// 区间类型 分为《固定值》《百分比》《单位值》
        /// </summary>

        public string upDownType { get; set; }
        /// <summary>
        /// 部分类型 分为《按下跌部分》《按超过下跌部分》
        /// </summary>

        public string partType { get; set; }

        public decimal compensateNum { get; set; }
        /// <summary>
        /// 赔付类型 分为《百分比》
        /// </summary>

        public string compensateType { get; set; }

        public decimal topCompensateNum { get; set; }
        /// <summary>
        /// 最高赔付类型 分为《固定值》
        /// </summary>

        public string topCompensateType { get; set; }

        public Guid optionsProductID { get; set; }

    }
    /// <summary>
    /// 上涨规则模型
    /// </summary>
    public class RiseRoleModel
    {

        public Guid riseRoleID { get; set; }

        public string riseRoleName { get; set; }

        public string createDate { get; set; }

        public decimal up { get; set; }

        public decimal down { get; set; }
        /// <summary>
        /// 区间类型 分为《固定值》
        /// </summary>

        public string upDownType { get; set; }
        /// <summary>
        /// 部分类型 分为《按上涨下跌部分》《按超过上涨下跌部分》
        /// </summary>

        public string partType { get; set; }

        public decimal dividendNum { get; set; }
        /// <summary>
        /// 分红类型 分为《百分比》
        /// </summary>
        public string dividendType { get; set; }

        public decimal topDividendNum { get; set; }
        /// <summary>
        /// 最高赔付类型 分为《固定值》
        /// </summary>
        public string topDividendType { get; set; }

        public Guid optionsProductID { get; set; }
    }
}