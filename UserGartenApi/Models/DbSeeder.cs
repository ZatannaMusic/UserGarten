using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserGartenApi.Models
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.UserTitles.Any())
            {
                foreach (var userTitleName in UserTitle.StandardTitles)
                {
                    var userTitle = new UserTitle
                    {
                        Name = userTitleName
                    };
                    dbContext.UserTitles.Add(userTitle);
                    dbContext.SaveChanges();
                }
            }

            // This seeding is intended to test purpose only!
            // So, it contains hardcode that has to be replaced in the future.
            if (!dbContext.Users.Any())
            {
                var userTitle = dbContext.UserTitles.First<UserTitle>(t => t.Name == "Mr");

                bool firts = true;
                for (int i = 0; i < 100; i++)
                {
                    string img_idx = firts ? "00" : "01";
                    firts = !firts;
                    var user = new User
                    {
                        FirstName = "Oleg" + i.ToString("00"),
                        LastName = "Kazantsev" + i.ToString("00"),
                        BirthDate = new DateTime(1900 + i, 2, 3),
                        Phone = "+64 22 000 00 " + i.ToString("00"),
                        ThumbImageUrl = $"Images/thumb_{img_idx}.jpg",
                        ThumbImage = null,
                        ImageUrl = $"Images/image_{img_idx}.jpg",
                        Image = null,
                        Title = userTitle
                    };
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
