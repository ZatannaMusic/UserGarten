using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserGartenApi.Models
{
    /// <summary>
    /// Implementation of repository storing information about users 
    /// implemented using MS-SQL Database.
    /// </summary>
    public class DbRepository : IUserRepository 
    {
        private ApplicationDbContext _dbContext;

        #region Constructor

        public DbRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Implementation of IUserRepository

        public long Create(User user)
        {
            string titleName = UserTitle.StandardTitles[0];
            if (user.Title != null)
            {
                titleName = user.Title.Name;
            }
            var userTitle = _dbContext.UserTitles.First<UserTitle>(t => t.Name == titleName);

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Phone = user.Phone,
                ThumbImageUrl = user.ThumbImageUrl,
                ThumbImage = user.ThumbImage,
                ImageUrl = user.ImageUrl,
                Image = user.Image,
                Title = userTitle
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return newUser.Id;
        }

        public void Delete(long id)
        {
            var delUser = _dbContext.Users.FirstOrDefault<User>(t => t.Id == id);
            if (delUser != null)
            {
                _dbContext.Users.Remove(delUser);
                _dbContext.SaveChanges();
            }
        }

        public User Get(long id)
        {
            var user = _dbContext.Users.FirstOrDefault<User>(t => t.Id == id);
            if (user == null)
            {
                return null;
            }
            user.Title = _dbContext.UserTitles.First<UserTitle>(t => t.Id == user.TitleId);

            return user;
        }

        public List<User> GetList(string firstName, string lastName, int maxResult) 
        {
            IQueryable<User> queryResult = null;
            if (!string.IsNullOrEmpty(firstName))
            {
                if (!string.IsNullOrEmpty(lastName))
                {
                    queryResult = _dbContext.Users.Where(t => t.FirstName == firstName && t.LastName == lastName);
                }
                else
                {
                    queryResult = _dbContext.Users.Where(t => t.FirstName == firstName);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lastName))
                {
                    queryResult = _dbContext.Users.Where(t => t.LastName == lastName);
                }
                else
                {
                    queryResult = _dbContext.Users.Select(t => t);
                }
            }

            if (maxResult > 0)
            {
                queryResult = queryResult.Take(maxResult);
            }

            foreach (var user in queryResult)
            {
                user.Title = _dbContext.UserTitles.First<UserTitle>(t => t.Id == user.TitleId);
            }

            return queryResult.ToList();
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public UserTitle GetTitleByName(string name)
        {
            return _dbContext.UserTitles.First<UserTitle>(t => t.Name == name);
        }

        #endregion
    }
}
