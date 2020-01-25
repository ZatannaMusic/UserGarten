using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserGartenApi.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string ThumbImageUrl { get; set; }
        public string Base64ThumbImage { get; set; }
        public string ImageUrl { get; set; }
        public string Base64Image { get; set; }
    }
}
