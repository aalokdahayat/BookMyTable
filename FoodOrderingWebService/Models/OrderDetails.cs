using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodOrderingWebService.Models
{


    public class OrderDetails
    {

        public int CustomerID { get; set; }

        public List<OrderItemDetails> OrderItemDetails { get; set; }
        public int OrderID { get; set; }
        public int HotelId { get; set; }
        public int DishId { get; set; }
        public int IsApproveStatus { get; set; }
        public string ApprovalName { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderPaymentID { get; set; }

    }

    public class OrderItemDetails
    {

        public int OrderId { get; set; }
        public int HotelId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public string DishName { get; set; }
        public decimal DishAmount { get; set; }
        public DateTime CreateDate { get; set; }


    }
}