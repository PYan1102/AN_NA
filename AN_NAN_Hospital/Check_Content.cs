using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OnCube_Switch
{
    /*
     * Define:檢查的功能都在這
     * 
     * 
     */


    internal class Check_Content
    {

        static public void CsvfileCheck(string[] path)
        {
            if (path.Length == 0)
            {
                throw new Exception("資料夾之中沒有csv檔案，請重新選擇資料夾");
              

            }
            
        }

        
        
    }
}
