using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserGartenApi.Models
{
    public class MockRepository : IUserRepository
    {
        private List<User> _users;
        private long _userCounter;

        public MockRepository()
        {
            _userCounter = 0;
            _users = new List<User>();
        }

        public long Create(User user)
        {            
            user.Id = _userCounter++;
            _users.Add(user);
            return user.Id;
        }

        public void Delete(long id)
        {
            var user = _users.Find(t => t.Id == id);
            _users.Remove(user);
        }

        public User Get(long id)
        {
            var user = _users.FirstOrDefault<User>(t => t.Id == id);
            if (user == null)
            {
                return null;
            }
 
            return user;
        }

        public List<User> GetList(string firstName, string lastName, int maxResult)
        {
            IEnumerable<User> queryResult = null;
            if (!string.IsNullOrEmpty(firstName))
            {
                if (!string.IsNullOrEmpty(lastName))
                {
                    queryResult = _users.FindAll(t => t.FirstName == firstName && t.LastName == lastName);
                }
                else
                {
                    queryResult = _users.FindAll(t => t.FirstName == firstName);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lastName))
                {
                    queryResult = _users.FindAll(t => t.LastName == lastName);
                }
                else
                {
                    queryResult = _users;
                }
            }

            if (maxResult > 0)
            {
                queryResult = queryResult.Take<User>(maxResult);
            }

            return queryResult.ToList();
        }

        public UserTitle GetTitleByName(string name)
        {
            return new UserTitle { Name = name };
        }

        public void Update(User user)
        {
            var foundUser = Get(user.Id);
            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.BirthDate = user.BirthDate;
            foundUser.Phone = user.Phone;
        }
    }
}
