using Microsoft.EntityFrameworkCore;
using MugShop.Common;
using MugShop.Data;
using MugShop.DTOs.CustomerDTOs;
using MugShop.Service.Interfaces.CustomerInterfaces;

namespace MugShop.Service.Implementations.CustomerRepos
{
    public class CustomerRepo:ICustomer
    {
        public readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<APIResponse> SignUpCustomer(SignUpCustomerDto customerInfo)
        //{
        //    var userExists = await _context.Customers
        //        .AnyAsync(c => c.Email == customerInfo.Email && c.DeletedAt == null);
        //    if (userExists)
        //    {
        //        return new APIResponse
        //        {
        //            IsSuccess = false,
        //            Error = "User with this email already exists."
        //        };
        //    }

        //}
    }
}
