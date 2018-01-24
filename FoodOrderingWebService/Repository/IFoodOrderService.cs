using FoodOrderingWebService.Entities;
using FoodOrderingWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingWebService.Repository
{
    public interface IFoodOrderService
    {
        List<RestaurantEntities> GetllRestaurantDetails();
        List<MenuCardEntities> GetHotelMenuDetails(int hotelId);
        List<HotelTableEntities> GetHotelstables(int hotelId);
        List<OrderDetails> AddTablesAndOrderBooking(OrderDetailsEntities orderDetails);
        List<OrderDetails> GetOrderDetails(int OrderID);
        List<OrderDetails> GetOrderDetailsForApproval(int employeeID);
        void SendMailToCustomer(string toEmailID, string message, string subject);

    }
}
