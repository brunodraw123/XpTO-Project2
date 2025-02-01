using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XPTOApp.Core;


namespace XPTOApp.Model
{
    public class OrderViewModel
    {
            public int OrderID { get; set;}

            //[MinLength(3)]        
            //[Required(ErrorMessage = "Bebida inválida")]
            public DrinkViewModel? Drink {get; set;}
            
            //[MinLength(3)]
            //[Required(ErrorMessage = "Prato principal inválido")]
            public MainFoodViewModel? MainFood {get; set;}
            
            //[MinLength(3)]
            //[Required(ErrorMessage = "Acompanhamento inválido")]
            public AccompanimentViewModel? AccompanimentFood {get; set;} 
            
            //[MinLength(3)]
            //[Required(ErrorMessage = "Sobremesa inválida")]
            public DessertViewModel? Dessert {get; set;}

            [MinLength(3)]
            [Required(ErrorMessage = "Status inválido")]
            public string? Status { get; set;}

            //[MinLength(3)]
            //[Required(ErrorMessage = "Tipo de refeição inválida")]
            // [JsonConverter(typeof(JsonStringEnumConverter))]
            public string? OrderType { get; set;}            

            [MinLength(5)]
            [Required(ErrorMessage = "Nome de aluno inválido")]
            public string? CustomerName { get; set;}
            public string? CustomerMail { get; set;}

            [Required(ErrorMessage = "Data inválida")]
            public decimal TotalValue { get; set; }
            public DateTime ReceivedDate { get; set;}
            public DateTime StartDate { get; set;}
            public DateTime FinishDate { get; set;} 
    }
}