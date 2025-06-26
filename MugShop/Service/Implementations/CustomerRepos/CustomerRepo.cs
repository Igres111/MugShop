using Microsoft.EntityFrameworkCore;
using MugShop.Common;
using MugShop.Data;

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

    }
}
