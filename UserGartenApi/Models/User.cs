using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserGartenApi.Models
{

    public class User
    {
        #region Constructor

        public User() { }

        #endregion

        #region Keys

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        #endregion

        #region Properties

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Phone { get; set; }

        #endregion

        #region Images

        /* 
         * It can be used to strategy for storing images:
         * 1. Using database
         * 2. Using a file system folder
         * Each of them has its pros and cons depending on the situation.
         * I'm going to start with the first approach. In case of having enough time,
         * it will be implemented the second approach.
         */

        public string ThumbImageUrl { get; set; }

        public byte[] ThumbImage { get; set; }

        public string ImageUrl { get; set; }

        public byte[] Image { get; set; }

        #endregion

        #region Relationships

        [Required]
        public long TitleId { get; set; }

        [ForeignKey("TitleId")]
        public virtual UserTitle Title { get; set; }

        #endregion
    }
}
