using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOApp.Model;

namespace XPTOApp.Core
{
    public class AccompanimentFood
    {
        public AccompanimentFood(string description, decimal value, OrderType._OrderType? orderType){

            Description = description;
            Value = value;
            _OrderType = orderType;  
        
        }

        public AccompanimentFood()
        {
            

         accompanimentFoodListOption.Add(
            new AccompanimentFood (
                "Torrada", 7, OrderType._OrderType.Breakfast
            )
         );  
         
        accompanimentFoodListOption.Add(
            new AccompanimentFood (
                "Salada", 9, OrderType._OrderType.Lunch
            )
        );              
        }


        public string? Description { get; set; }
        public decimal Value { get; set; }

        public OrderType._OrderType? _OrderType;
        public List<AccompanimentFood> accompanimentFoodListOption = new List<AccompanimentFood>();
        
    }
}