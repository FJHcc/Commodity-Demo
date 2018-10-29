using NPinyin;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommodityManagement.Service.Common
{
    /// <summary>
    /// 获取拼音公共类
    /// </summary>
    public class GetSpelling
    {
        /// <summary>
        /// 获取商品名字拼音方法
        /// </summary>
        /// <param name="name">商品名字</param>
        /// <returns></returns>
        public static StringBuilder Spelling(string name)
        {
            StringBuilder pinyin = new StringBuilder();
            //获取商品名字拼音
            foreach (var s in name)
            {
                var chineseChar = Pinyin.GetPinyin(s);
                pinyin.Append(chineseChar);
            }
            return pinyin;
        }
    }
}
