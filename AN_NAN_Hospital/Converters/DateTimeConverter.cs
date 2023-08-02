using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCube_Switch.Converters
{
    /// <summary>
    /// 用來處理時間轉換的
    /// </summary>
   
    internal class DateTimeConverter  
    {
        /// <summary>
        /// 轉換日期行蝶和字串型別的，引數：輸入時間，需要格式，回傳DateTime 型別
        /// </summary>
        internal static DateTime ToDateTime(string input, string format)
        {
            DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out DateTime result);
            return result;
        }
    }
}
