using FoodOrderDataLayer.DataLayer;
using FoodOrderEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrderService.Repository
{
    public class FoodOrderingService :IFoodOrderService
    {
        /// <summary>
        /// get Retaurants details  fro this methods GetllRestaurantDetails
        /// </summary>
        /// <returns> RestaurantEntities </returns>
        public List<RestaurantEntities> GetllRestaurantDetails()
        {           

            List<RestaurantEntities> restaurantEntities = new List<RestaurantEntities>();
            try
            {
                using (bookmytableEntities Context = new bookmytableEntities())
                {

                    var result = Context.Sp_GetRestaurantsDetails(null).ToList();

                    foreach (var item in result)
                    {
                        restaurantEntities.Add(new RestaurantEntities
                        {
                            id = item.id,
                            HotelName = item.HotelName,
                            ContactPersoneName = item.ContactPersoneName,
                            Address = item.Address,
                            City = item.City,
                            Country = item.Country,
                            EmailID = item.EmailID,
                            OpenintHours = item.OpenintHours,
                            PhoneNumber = item.PhoneNumber,
                            Rating = Convert.ToInt32(item.Rating),
                            CreateDate = item.CreateDate
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }          

            return restaurantEntities;

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelTableEntities> GetHotelstables(int hotelId)
        {
            List<HotelTableEntities> hotelTableEntities = new List<HotelTableEntities>();

            using (bookmytableEntities Context = new bookmytableEntities())
            {
                var result = Context.Sp_GetRestaurantsTablesDetails(hotelId).ToList();

                foreach (var item in result)
                {
                    hotelTableEntities.Add(new HotelTableEntities
                    {
                        Id=item.Id,
                        HotelName=item.HotelName,
                        TotalTable = Convert.ToInt32(item.TotalTable),
                        TableCapacity= Convert.ToInt32(item.TableCapacity),
                        CreateDate=Convert.ToDateTime(item.CreateDate)
                    });
                }
            };

            return hotelTableEntities;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<MenuCardEntities> GetHotelMenuDetails(int hotelId)
        {
            List<MenuCardEntities> menuCardEntities = new List<MenuCardEntities>();

            using (bookmytableEntities Context = new bookmytableEntities())
            {
                var result = Context.Sp_GetHotelMenuDetails(hotelId).ToList();
                foreach (var item in result)
                {
                    menuCardEntities.Add(new MenuCardEntities
                    {
                        HotelId = item.HotelId,
                        HotelName = item.HotelName,
                        MenuID = Convert.ToInt32(item.MenuID),
                        MenuName = item.MenuName,
                        MenuDescription = Convert.ToString(item.MenuDescription),
                        IsVeg = Convert.ToInt32(item.IsVeg),
                        IsAvailable = Convert.ToInt32(item.IsAvailable),
                        Price = Convert.ToDecimal(item.Price),
                        CreateDate = Convert.ToDateTime(item.CreateDate)
                    });
                }
            };

            return menuCardEntities;

        }

        public OrderDetails AddTablesAndOrderBooking(OrderDetailsEntities od)
        {
            OrderDetails oredrDetails = new OrderDetails();

            using (bookmytableEntities Context = new bookmytableEntities())
            {
               // var result = Context.AddTableBookAndMenuOrder().ToList();

            };

            return oredrDetails;
        }


    }
}