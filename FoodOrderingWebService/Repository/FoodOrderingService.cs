using FoodOrderingWebService.DataLayer;
using FoodOrderingWebService.Entities;
using FoodOrderingWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FoodOrderingWebService.Repository
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
                            TotalTable = Convert.ToInt32(item.TotalTable),
                            TableCapacity=Convert.ToInt32(item.TableCapacity),
                            TableAvailable= Convert.ToInt32(item.TableAvailable),
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>

        public List<OrderDetails> GetOrderDetails(int OrderID)
        {
            List<OrderDetails> OrderDetailsEntities = new List<OrderDetails>();

            using (bookmytableEntities Context = new bookmytableEntities())
            {
                var result = Context.Sp_GetOrderDetails(OrderID).ToList();

                foreach (var item in result)
                {
                    OrderDetailsEntities.Add(new OrderDetails
                    {
                        OrderID = item.OrderID,
                        ApprovalName=item.ApprovalName,
                        DishId= Convert.ToInt32(item.DishId),
                        IsApproveStatus = Convert.ToInt32(item.IsApproveStatus)
                        
                    });
                }
             
            };

            return OrderDetailsEntities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="od"></param>
        /// <returns></returns>
        public List<OrderDetails> AddTablesAndOrderBooking(OrderDetailsEntities od)
        {
            List<OrderDetails> oredrDetails = new List<OrderDetails>();

            using (bookmytableEntities Context = new bookmytableEntities())
            {
                                              
                
                var result = Context.AddTableBookAndMenuOrder(od.HotelId,1,od.TotalAmount,od.ApprovalName,od.CustomerName,od.PhoneNumber,od.EmailID,od.City,od.Country,od.Address).ToList();

                foreach (var menuItem in od.MenuList) {

                    var result2 = Context.AddOrderMenuDetails(od.HotelId, menuItem.MenuID, od.TotalAmount, result[0].OrderID, menuItem.Quantity, menuItem.MenuName);
                }
                foreach (var item in result)
                {
                    oredrDetails.Add(new OrderDetails
                    {
                        CustomerID= Convert.ToInt32(item.CustomerID),
                        OrderID= Convert.ToInt32(item.OrderID),
                        OrderPaymentID = Convert.ToInt32(item.OrderPaymentID),
                    });
                 
                }

               //od.EmailID = "ankushpogade@gmail.com";
                if (!string.IsNullOrEmpty(od.EmailID))
                {
                    string subject = "Your Order confirmation : " + oredrDetails[0].OrderID;
                   string message = "Your order has been Succesfully placed </br> Your Total Amount : " + od.TotalAmount;
                    SendMailToCustomer(od.EmailID, message, subject);
                }

            };

            return oredrDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<OrderDetails> GetOrderDetailsForApproval(int employeeID)
        {
            List<OrderDetails> OrderDetailsEntities = new List<OrderDetails>();

            List<OrderItemDetails> orderItemDetails = new List<OrderItemDetails>();

            using (bookmytableEntities Context = new bookmytableEntities())
            {
                var result = Context.Sp_GetOrderDetailsToEmployee(employeeID,null).ToList(); 
                
                foreach (var item in result)
                {
                    var orderItemdetils = Context.OrderMenuEntities.Where(p => p.OrderId == item.OrderID).Select(p=>p);

                    foreach (var orderItem in orderItemdetils)
                    {
                        orderItemDetails.Add(new OrderItemDetails
                        {
                            DishName = orderItem.DishName,
                            DishAmount = Convert.ToDecimal(orderItem.DishAmount),
                            OrderId = Convert.ToInt32(orderItem.OrderId),
                            Quantity = Convert.ToInt32(orderItem.Quantity),
                            DishId = Convert.ToInt32(orderItem.DishId)
                        });
                    }
                    OrderDetailsEntities.Add(new OrderDetails
                    {
                        OrderItemDetails = orderItemDetails,
                        OrderID = item.OrderID,
                        HotelId = Convert.ToInt32(item.HotelId),
                        TotalAmount = Convert.ToDecimal(item.TotalAmount)

                    });
                }

            };

            return OrderDetailsEntities;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="toEmailID"></param>
        /// <param name="message"></param>
        /// <param name="subject"></param>
        public void SendMailToCustomer(string toEmailID,string message,string subject)
        {

            try
            {
                string fromAddress = "prashantamleofficial@gmail.com";
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toEmailID);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("prashantamleofficial@gmail.com", "77091922351990");
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.EnableSsl = true;                

                SmtpServer.Send(mail);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          
            }

    }
}