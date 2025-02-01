using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XPTOApp.Core;

namespace XPTOApp.Model
{
        public class AccompanimentViewModel
    {
        [Required(ErrorMessage = "Descrição do acompanhamento inválida")]
        [MinLength(3)]
        public string? Description { get; set; }    
        [Required]
        public decimal Value { get; set;}
        
        //[Required(ErrorMessage = "")]
        //[MinLength(3)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderTypeViewModel._OrderType? _OrderType {get; set;}

    }
}