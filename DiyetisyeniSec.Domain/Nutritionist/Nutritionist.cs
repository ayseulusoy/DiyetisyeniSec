using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiyetisyeniSec.Domain.Nutritionist
{
    public class Nutritionist
    {
        [Key]
        public int Id { get; set; }

        #region Basic Info
        [Required]
        [StringLength(50, ErrorMessage = "Isminiz 50 karakterden uzun olamaz.")]
        public string Name { get; set; }
        //false erkek true kadın
        public bool Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Range(2, 80, ErrorMessage = "2 yılın altında kayıt yapılamaz.")]
        public byte Experience { get; private set; }
        [Required(ErrorMessage = "Besenme ve Diyetik diploması zorunludur.")]
        public string UniversityName { get; set; }
        #endregion

        #region Social Profiles
        public string CompanyName { get; set; }
        public string WebsiteURL { get; set; }
        public string InstagramUsername { get; set; }
        public string WhatsappNumber { get; set; }

        #endregion

        public bool IsActive { get; set; } = false;
        public bool IsRemoteEligible { get; set; } = false;
        public bool IsEducationConfirmed { get; set; } = false;

        //deneyim kısmını daha kontrollu yaptık böylece kodla bile değişirmek olmayacak.
        public void SetExperience(byte experience)
        {
            if (experience <= 2)
                throw new ArgumentException("Tecrube 2 yılın altında olamaz!!");
            if (UniversityName != "Akdeniz Universitesi" && experience < 4)
                throw new ArgumentException("Onlisans mezunlarının tecrubesi 4 yıldan az olamaz!!");

            Experience = experience;
        }

    }
}
