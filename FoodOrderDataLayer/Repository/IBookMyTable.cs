using FoodOrderEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderDataLayer.Repository
{
    public interface IBookMyTable
    {
        List<RestaurantEntities> GetllRestaurantDetails();
        List<MenuCardEntities> GetHotelMenuDetails(int hotelId);
        List<HotelTableEntities> GetHotelstables(int hotelId);
        OrderDetails AddTablesAndOrderBooking(OrderDetailsEntities orderDetails);
    }
}
