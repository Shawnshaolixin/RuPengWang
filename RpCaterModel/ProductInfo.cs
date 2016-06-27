using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
   public class ProductInfo
    {
        //ProId, CId, ProName, ProCost, ProSpell, ProPrice, ProUnit, Remark, DelFlag, SubTime, ProStock, ProNum, SubBy

       public int ProId { get; set; }
       public int CId { get; set; }
       public string ProName { get; set; }
       public decimal ProCost { get; set; }
       public string ProSpell { get; set; }
       public decimal ProPrice{get;set;}
       public string ProUnit { get; set; }
       public string Remark { get; set; }
       public int DelFlag { get; set; }
       public DateTime SubTime { get; set; }
       /// <summary>
       /// 产品的库存
       /// </summary>
       public int ProStock { get; set; }
       public int ProNum { get; set; }
       public int SubBy { get; set; }
    }
}
