using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOApp.Core
{
    public class Dessert
    {
         public Dessert(string description, decimal value, OrderType._OrderType? orderType){
              
            Description = description;
            Value = value;
            _OrderType = orderType;    
                                              
        }

        public Dessert()
        {
            dessertListOption.Add(
            new Dessert (
                "Bolo", 9, OrderType._OrderType.Lunch
            )
        );              
        }

        public string? Description { get; set; }
        public decimal Value { get; set; }

        public OrderType._OrderType? _OrderType;

        public List<Dessert> dessertListOption = new List<Dessert>();

    }
}