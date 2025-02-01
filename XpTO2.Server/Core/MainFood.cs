using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOApp.Model;

namespace XPTOApp.Core
{
    public class MainFood
    {
       public MainFood(string description, decimal value, OrderType._OrderType? orderType){

            Description = description;
            Value = value;
            _OrderType = orderType;                                     
        }

        public MainFood()
        {
        mainFoodListOption.Add(
            new MainFood (
                "Bacon", 8, OrderType._OrderType.Breakfast
            )
         );  
         
        mainFoodListOption.Add(
            new MainFood (
                "Bife", 10, OrderType._OrderType.Lunch
            )
        );                         
        } 

        public string? Description { get; set; }
        public decimal Value { get; set; }

        public OrderType._OrderType? _OrderType;

        public List<MainFood> mainFoodListOption = new List<MainFood>();

    }
}