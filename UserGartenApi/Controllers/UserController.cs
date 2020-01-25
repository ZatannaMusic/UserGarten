using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserGartenApi.Models;
using UserGartenApi.Models.ViewModels;

namespace UserGartenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// The repository storing information about users.
        /// </summary>
        private IUserRepository _repository;

        #region Constructor

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        #endregion

        #region API handlers

        [HttpPut]
        public IActionResult Put([FromBody]UserViewModel userViewModel)
        {
            try
            {
                var image = userViewModel.Base64Image == null ? null : Convert.FromBase64String(userViewModel.Base64Image);
                var thumbImage = userViewModel.Base64ThumbImage == null ? null : Convert.FromBase64String(userViewModel.Base64ThumbImage);

                var newUser = new User
                {
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    BirthDate = DateTime.Parse(userViewModel.BirthDate),
                    Phone = userViewModel.Phone,
                    Title = new UserTitle
                    {
                        Name = userViewModel.Title
                    },
                    Image = image,
                    ThumbImage = thumbImage
                };
                _repository.Create(newUser);
                return new OkResult();
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }                   
                return Problem(ex.StackTrace, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            try
            {
                var newUser = new User
                {
                    Id = userViewModel.Id,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    BirthDate = DateTime.Parse(userViewModel.BirthDate),
                    Phone = userViewModel.Phone,
                    Title = new UserTitle
                    {
                        Name = userViewModel.Title
                    },
                    ThumbImageUrl = userViewModel.ThumbImageUrl,
                    ImageUrl = userViewModel.ImageUrl
                };
                _repository.Update(newUser);

                return new OkResult();
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }
                return Problem(ex.StackTrace, ex.Message);
            }
        }
        
        [HttpGet]
        public IActionResult Get(
            [FromQuery] string firstName,
            [FromQuery] string lastName,
            [FromQuery] int maxResult)
        {
            try
            {
                var userViewModelList = new List<UserViewModel>();
                var userList = _repository.GetList(firstName, lastName, maxResult);
                foreach (var user in userList)
                {
                    var userViewModel = new UserViewModel()
                    {
                        Id = (int)user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        BirthDate = user.BirthDate == null ? "" : user.BirthDate.Value.ToString("yyyy-MM-dd"),
                        Phone = user.Phone,
                        Title = user.Title.Name,
                        ThumbImageUrl = user.ThumbImageUrl,
                        ImageUrl = user.ImageUrl,

                        // The assignment bellow is off because it causes the huge memory usage.
                        // It needs to accomplish refactoring the architectural decision.
                        //Base64Image = Convert.ToBase64String(System.IO.File.ReadAllBytes(user.ThumbImageUrl))
                        Base64ThumbImage = user.ThumbImage == null ? null : Convert.ToBase64String(user.ThumbImage)
                    };
                    userViewModelList.Add(userViewModel);
                }

                return Ok(userViewModelList);

            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }
                return Problem(ex.StackTrace, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _repository.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                var userViewModel = new UserViewModel()
                {
                    Id = (int)user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate == null ? "" : user.BirthDate.Value.ToString("yyyy-MM-dd"),
                    Phone = user.Phone,
                    Title = user.Title.Name,
                    ThumbImageUrl = user.ThumbImageUrl,
                    //Base64ThumbImage = user.ImageUrl == null ? null : Convert.ToBase64String(System.IO.File.ReadAllBytes(user.ThumbImageUrl)),
                    Base64ThumbImage = user.ThumbImage == null ? null : Convert.ToBase64String(user.ThumbImage),
                    ImageUrl = user.ImageUrl,
                    //Base64Image = user.ImageUrl == null ? null : Convert.ToBase64String(System.IO.File.ReadAllBytes(user.ImageUrl))
                    Base64Image = user.Image == null ? null : Convert.ToBase64String(user.Image),
                };

                return Ok(userViewModel);
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }
                return Problem(ex.StackTrace, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the todo with the given {id} from the database
        /// </summary>
        /// <param name="id">The ID of an existing todo</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _repository.Delete(id);
                return new OkResult();
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }
                return Problem(ex.StackTrace, ex.Message);
            }
        }

        /* 
         * Work with photo.
         * The most controversial decision :)
         * This code has to be refactored.
         */

        [HttpGet("{id}/photo")]
        public IActionResult GetPhoto(int id)
        {
            try
            {
                var user = _repository.Get(id);
                string imagePath = user.ImageUrl;
                Byte[] imageStream = System.IO.File.ReadAllBytes(imagePath);
                return File(imageStream, "image/jpeg");
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }
                return Problem(ex.StackTrace, ex.Message);
            }
        }

        [HttpGet("{id}/thumb")]
        public IActionResult GetThumb(int id)
        {
            try
            {
                var user = _repository.Get(id);
                string imagePath = user.ThumbImageUrl;
                Byte[] imageStream = System.IO.File.ReadAllBytes(imagePath);
                return File(imageStream, "image/jpeg");
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex.ToString());
                }
                return Problem(ex.StackTrace, ex.Message);
            }
        }

        #endregion
    }
}
