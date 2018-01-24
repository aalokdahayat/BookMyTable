using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodOrderEntities.Entities
{

   
    public class OrderDetails
    {
           
        public int HotelId { get; set; }
        public int DishID { get; set; }
        public string TotalAmt { get; set; }
        public string ApprovalName { get; set; }	
        public string CustomerName { get; set; }   
        public string PhoneNumber { get; set; }
        public string Lastname { get; set; } 
        public string EmailID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

    }
}