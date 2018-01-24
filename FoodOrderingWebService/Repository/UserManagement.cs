using FoodOrderingWebService.DataLayer;
using FoodOrderingWebService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrderingWebService.Repository
{
    public class UserManagement: IUserManangement
    {
        public UserDetails GetUserDetails(string userName, string Password)
        {
            UserDetails userDetail = new UserDetails();
            using (bookmytableEntities Context = new bookmytableEntities())
            {

                var result = Context.Sp_GetUserAndUserRoleDetails(userName,Password).ToList();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        userDetail.Success = true;
                        userDetail.FirstName = item.FirstName;
                        userDetail.LastName = item.LastName;
                    }
                }
                else
                {
                    userDetail.Success = false;
                }
            }

            return userDetail;
        }
    }
}