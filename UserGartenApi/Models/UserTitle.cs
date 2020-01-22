using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserGartenApi.Models
{
    public class UserTitle
    {
        #region Constants

        /// <summary>
        /// Standard Titles. They have to be seeded by default.
        /// </summary>
        public static readonly string[] StandardTitles = { "Mr", "Mrs", "Miss", "Ms", "Mx", "Sir", "Dr", "Lady", "Lord" };

        #endregion

        #region Constructor

        public UserTitle() { }

        #endregion

        #region Keys

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        #endregion

        #region Properties

        [Required]
        public string Name { get; set; }

        #endregion

        #region Relationships

        /// <summary>
        /// The ability to get users, associated with the particular title.
        /// This relationship is not necessary but can be useful in some cases.
        /// </summary>
        public virtual List<User> Users { get; set; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
