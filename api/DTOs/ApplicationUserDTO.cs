using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTOs
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public string Cover { get; set; }
        public ApplicationUserDTO(ApplicationUser User)
        {
            Id = User.Id;
            FirstName = User.FirstName;
            LastName = User.LastName;
            UserName = User.UserName;
            Email = User.Email;
            Photo = User.Photo;
            Cover = User.CoverPhoto;
        }
    }
}