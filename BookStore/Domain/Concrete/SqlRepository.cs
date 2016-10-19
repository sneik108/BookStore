using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public partial class SqlRepository : IRepository
    {
        EFDbContext context = new EFDbContext();

    }
    //Roles
    public partial class SqlRepository
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return context.Roles;
            }
        }

        public bool CreateRole(Role instance)
        {
            if (instance.ID == 0)
            {
                context.Roles.Add(instance);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRole(Role instance)
        {
            Role cache = context.Roles.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.Name = instance.Name;
                cache.Code = instance.Code;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveRole(int idRole)
        {
            Role instance = context.Roles.FirstOrDefault(p => p.ID == idRole);
            if (instance != null)
            {
                context.Roles.Remove(instance);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
    //Users
    public partial class SqlRepository
    {


        public IQueryable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
                instance.ActivatedLink = User.GetActivateUrl();
                context.Users.Add(instance);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = context.Users.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                cache.Email = instance.Email;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUser(int idUser)
        {
            User instance = context.Users.Where(p => p.ID == idUser).FirstOrDefault();
            if (instance != null)
            {
                context.Users.Remove(instance);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return context.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            IEnumerable<User> users = context.Users;
            IEnumerable<Book> books = context.Books;
            return context.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }
    }
}