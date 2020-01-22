using System;
using Xunit;
using UserGartenApi.Controllers;
using UserGartenApi.Models;
using UserGartenApi.Models.ViewModels;

namespace UserGartenApi.Tests
{
    public class UserControllerTest
    {
        [Fact]
        public void Put()
        {
            // Arrange
            var mockRepository = new MockRepository();
            UserController testController = new UserController(null, mockRepository);

            // Act
            UserViewModel viewModel = new UserViewModel();
            viewModel.FirstName = "Oleg";
            viewModel.LastName = "Kazantsev";
            viewModel.BirthDate = new DateTime(2020, 1, 1).ToString("yyyy-MM-dd");
            viewModel.Phone = "00";
            viewModel.Title = "Mr";
            testController.Put(viewModel);

            // Assert
            var userList = mockRepository.GetList(null, null, 0);
            var actualCount = userList.Count;
            Assert.Equal(1, actualCount);
        }

        [Fact]
        public void Get()
        {
            // Arrange
            var mockRepository = new MockRepository();
            UserController testController = new UserController(null, mockRepository);
            User user = new User();
            user.FirstName = "Oleg";
            user.LastName = "Kazantsev";
            user.BirthDate = new DateTime(2020, 1, 1);
            user.Phone = "00";
            user.Title = new UserTitle { Name = "Mr" };
            mockRepository.Create(user);

            // Act
            var result = testController.Get(0);

            // Assert
            var actualLastName = ((UserGartenApi.Models.ViewModels.UserViewModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).LastName;
            Assert.Equal("Kazantsev", actualLastName);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            var mockRepository = new MockRepository();
            UserController testController = new UserController(null, mockRepository);
            User user = new User();
            user.FirstName = "Oleg";
            user.LastName = "Kazantsev";
            user.BirthDate = new DateTime(2020, 1, 1);
            user.Phone = "00";
            user.Title = new UserTitle { Name = "Mr" };
            mockRepository.Create(user);

            // Act
            UserViewModel viewModel = new UserViewModel();
            viewModel.Id = 0;
            viewModel.FirstName = "Ivan";
            viewModel.LastName = "Kazantsev";
            viewModel.BirthDate = new DateTime(2020, 1, 1).ToString("yyyy-MM-dd");
            viewModel.Phone = "00";
            viewModel.Title = "Mr";
            var result = testController.Post(viewModel);

            // Assert
            var actualFirstName = user.FirstName;
            Assert.Equal("Ivan", actualFirstName);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var mockRepository = new MockRepository();
            UserController testController = new UserController(null, mockRepository);
            User user = new User();
            user.FirstName = "Oleg";
            user.LastName = "Kazantsev";
            user.BirthDate = new DateTime(2020, 1, 1);
            user.Phone = "00";
            user.Title = new UserTitle { Name = "Mr" };
            mockRepository.Create(user);

            // Act
            testController.Delete(0);

            // Assert
            var userList = mockRepository.GetList(null, null, 0);
            var actualCount = userList.Count;
            Assert.Equal(0, actualCount);
        }
    }
}
