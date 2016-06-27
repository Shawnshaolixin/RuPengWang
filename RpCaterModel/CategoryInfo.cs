using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
   public class CategoryInfo
    {
        //CId, CName, CNum, CRemark, DelFlag, SubTime, SubBy
       public int CId { get; set; }
       public string CName { get; set; }
       public int CNum { get; set; }
       public string CRemark { get; set; }
       public int DelFlag{get;set;}
       public DateTime SubTime{get;set;}
       public int SubBy { get; set; }
    }
}
