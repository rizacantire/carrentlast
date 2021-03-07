using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace consoleui
{
    class Program
    {
        static void Main(string[] args)
        {

            var userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.FirstName + " " +item.LastName);
            }
        }
    }
}
