using DevBoost.REST.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBoost.REST.Services
{
    public class UserService
    {
        private readonly Dictionary<Guid, User> _userDictionary;

        public UserService()
        {
            _userDictionary = new Dictionary<Guid, User>();
        }

        public IEnumerable<User> GetAll()
        {
            return _userDictionary.Values;
        }

        public User GetById(Guid id)
        {
            User user;
            _userDictionary.TryGetValue(id, out user);

            return user;
        }

        public User Add(User user)
        {
            _userDictionary.Add(user.Id, user);

            return user;
        }

        public User Update(Guid id, User user)
        {
            _userDictionary[id] = user;

            return user;
        }

        public void Delete(Guid id)
        {
            _userDictionary.Remove(id);
        }
    }
}
