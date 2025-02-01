using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOApp.Model;

namespace XPTOApp.Core
{
    public class Drink
    {
        public Drink(string description, decimal value, OrderType._OrderType? orderType){

         Description = description;
         Value = value;
         _OrderType = orderType;       

        }

        public Drink()
        {
            drinkListOption.Add(
            new Drink (
                "Café", 4, OrderType._OrderType.Breakfast
            )
         );  
         
            drinkListOption.Add(
            new Drink (
                "Refrigerante", 6, OrderType._OrderType.Lunch
            )
        );              
        }

        public string? Description { get; set; }
        public decimal Value { get; set; }

        public OrderType._OrderType? _OrderType;

        public List<Drink> drinkListOption = new List<Drink>();

        
    }
}