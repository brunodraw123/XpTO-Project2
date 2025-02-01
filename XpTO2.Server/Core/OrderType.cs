using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOApp.Core
{
    public class OrderType
    {
        public OrderType()
        {
           
        }
        
        public enum _OrderType {
            Breakfast,
            Lunch,
            Invalid
        }

        public string pOrderType { get; set; }        
        public System.DateTime now = DateTime.Now; 
        public string StartHoursBreakFast {get;set;} = "08";   
        public string EndHoursBreakfast {get; set;} = "10";
        public string StartHoursLunch {get; set;} = "11";
        public string EndHoursLunch {get; set;}= "15";

        public _OrderType VerifyTypeOperation(){
            
            DateTime _StartHoursBreakFast = new  DateTime(
                now.Year,now.Month,now.Day,
                int.Parse(StartHoursBreakFast),00,00
                );
            DateTime _EndHoursBreakfast = new  DateTime(
                now.Year,now.Month,now.Day,
                int.Parse(EndHoursBreakfast),00,00
                );
            DateTime _StartHoursLunch = new  DateTime(
                now.Year,now.Month,now.Day,
                int.Parse(StartHoursLunch),00,00
                );
            DateTime _EndHoursLunch = new  DateTime(
                now.Year,now.Month,now.Day,
                int.Parse(EndHoursLunch),00,00
                );

            if(now > _StartHoursBreakFast && now < _EndHoursBreakfast)
                return _OrderType.Breakfast;
                else
            if(now > _StartHoursLunch && now < _EndHoursLunch)
                return _OrderType.Lunch;
            else return _OrderType.Invalid;

        }

    }
}