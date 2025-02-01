using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOApp.Model
{
    public class BaseViewModel <t>
    {
        public BaseViewModel()
        {
            
        }

        public BaseViewModel(bool success )
        {
            Success = success;
        }
        public BaseViewModel(bool success, string message, string title)
        {
            Success = success;
            Message = new Message(title,message);
            
        }
        public BaseViewModel(bool success, string message, string title, t _object)
        {
            Success = success;
            Message = new Message(
                title,
                message
                );
            ResultObject = _object;
        }

        public BaseViewModel(bool success, t _object)
        {
            Success = success;
            ResultObject =_object;
        }    

        public bool Success { get; set; } 
        public t ResultObject {get; set;}
        public Message Message {get; set;}

    }
    public class Message{

        public Message()
        {
                
        }
        public Message(string title,string message)
        {
            Title = title;
            Description = message;
        }

        public string? Title  { get; set;}  
        public string? Description { get; set; }
    }
}