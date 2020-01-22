using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserGartenApi.Models
{
    /// <summary>
    /// Interface of repository storing information about users.
    /// </summary>
    public interface IUserRepository
    {
        /*
         * Create
         */

        /// <summary>
        /// Creating the user.
        /// </summary>
        /// <param name="user">Initial information about the user. The property 'Id' will be ignored</param>
        /// <returns>Identifier of the created user</returns>
        long Create(User user);

        /*
         * Read
         */

        /// <summary>
        /// Getting the list of users satisfying with the requirements.
        /// </summary>
        /// <param name="firstName">First name. In the case of null or empty value, the argument is not used.</param>
        /// <param name="lastName">Second name. In the case of null or empty value, the argument is not used.</param>
        /// <param name="maxResult">Maximum size of the result. In the case of 0 or less, the argument is not used.</param>
        /// <returns>The list of satisfying with the requirements </returns>
        List<User> GetList(string firstName, string lastName, int maxResult);
        
        /// <summary>
        /// Getting a single user.
        /// </summary>
        /// <param name="id">Identifier of the user</param>
        /// <returns>The user with the specified identifier or null in case the user doesn't exist</returns>
        User Get(long id);

        /*
         * Update
         */

        /// <summary>
        /// Updating the infromation about the user.
        /// </summary>
        /// <param name="user">The description of the user. For specifying the user, it has to be used property 'Id</param>
        void Update(User user);

        /*
         * Delete
         */

        /// <summary>
        /// Deleting the user.
        /// </summary>
        /// <param name="id">Identifier of the user</param>
        void Delete(long id);

        /*
         * Title
         */

        /// <summary>
        /// Getting tutle by name.
        /// </summary>
        /// <param name="name">The name of title</param>
        /// <returns>Title</returns>
        UserTitle GetTitleByName(string name);
    }
}
