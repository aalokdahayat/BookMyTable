using FoodOrderingWebService.Entities;
using FoodOrderingWebService.Models;
using FoodOrderingWebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace FoodOrderingWebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Hotel")]
    public class HotelController : ApiController
    {
        // private readonly IFoodOrderService IFoodOrderService;
        private readonly IFoodOrderService _repository;
        private readonly IUserManangement _repositoryUser;

        public HotelController(IFoodOrderService IFoodOrderService, IUserManangement IUserManangement)
        {
            _repository = IFoodOrderService;
            _repositoryUser = IUserManangement;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>

        [Route("GetUserDetailsWithSuccesLogin")]
        [AcceptVerbs("GET", "POST")]
        public UserDetails GetUserDetailsWithSuccesLogin(string userName,string Password)
        {
            UserDetails userSucees = new UserDetails();
            try
            {
                userSucees = _repositoryUser.GetUserDetails(userName, Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userSucees;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetRestaurantDetailsList")]
        [HttpGet]
        public List<RestaurantEntities> GetRestaurantDetailsList()
        {
            List<RestaurantEntities> restaurantEntities = new List<RestaurantEntities>();
            try
            {
                restaurantEntities = _repository.GetllRestaurantDetails().ToList();
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
        /// 

        [Route("GetRestaurantTablesDetailsList")]
        [HttpGet]
        public List<HotelTableEntities> GetRestaurantTablesDetailsList(int hotelId)
        {
            List<HotelTableEntities> hotelTableEntities = new List<HotelTableEntities>();
            try
            {
                hotelTableEntities = _repository.GetHotelstables(hotelId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hotelTableEntities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// 

        [Route("GetOrderDetailsForApproval")]
        [HttpGet]
        public List<OrderDetails> GetOrderDetailsForApproval(int employeeId)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            try
            {
                orderDetails = _repository.GetOrderDetailsForApproval(employeeId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orderDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        /// 
        [Route("GetRestaurantMenuCardDetailsList")]
        [HttpGet]
        public List<MenuCardEntities> GetRestaurantMenuCardDetailsList(int hotelId)
        {
            List<MenuCardEntities> menuCardEntities = new List<MenuCardEntities>();
            try
            {
                menuCardEntities = _repository.GetHotelMenuDetails(hotelId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menuCardEntities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>

        [Route("GetOrderDetails")]
        [HttpGet]
        public List<OrderDetails> GetOrderDetails(int orderId)
        {
            List<OrderDetails> OrderDetailsEntities = new List<OrderDetails>();
            try
            {
                OrderDetailsEntities = _repository.GetOrderDetails(orderId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return OrderDetailsEntities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>

        [Route("AddTablesAndOrderBooking")]
        [AcceptVerbs("GET", "POST")]
        public List<OrderDetails> AddTablesAndOrderBooking(OrderDetailsEntities orderDetails)
        {
            List<OrderDetails> orderDetailsResponse = new List<OrderDetails>();
            try
            {
                orderDetailsResponse = _repository.AddTablesAndOrderBooking(orderDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orderDetailsResponse;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("SendMailToCustomer")]
        [HttpGet]
        public int SendMailToCustomer()
        {
            int ISuceess = 1;
            try
            {
                // _repository.SendMailToCustomer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ISuceess;
        }




    }
}