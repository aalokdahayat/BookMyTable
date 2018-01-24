using FoodOrderEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FoodOrderService.Repository
{
    public interface IFoodOrderService
    {
        List<RestaurantEntities> GetllRestaurantDetails();
        List<MenuCardEntities> GetHotelMenuDetails(int hotelId);
        List<HotelTableEntities> GetHotelstables(int hotelId);
        OrderDetails AddTablesAndOrderBooking(OrderDetailsEntities orderDetails);

    }
}
