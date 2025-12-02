using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class Manager : User
    {
        public string MangPassword { get; set; } 
        //public List<User> Users { get; set; } = new List<User>();

       
        //public void AddUser(User user)
        //{
        //    Users.Add(user);
        //}

        
        //public void RemoveUser(User user)
        //{
        //    Users.Remove(user);
        //}

        
        //public User FindUserByEmail(string email)
        //{
        //    return Users.FirstOrDefault(u => u.Email == email);
        //}

       
        //public void ShowAllUsers()
        //{
        //    foreach (var user in Users)
        //    {
        //        Console.WriteLine($"{user.Username} ({user.Email})");
        //    }
        //}
    }
}
