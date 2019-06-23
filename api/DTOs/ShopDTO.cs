using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTOs
{
    public class ShopDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }

        public int City { get; set; }

        public int Country { get; set; }
        public int District { get; set; }

        public string Photo { get; set; }
        public string Cover { get; set; }
        public string About { get; set; }
        public string Policy { get; set; }
        public string Street { get; set; }
        public ApplicationUserDTO User { get; set; }
        public ShopDTO()
        {

        }
        public ShopDTO(Shop shop)
        {
            Id=shop.Id;
            Name = shop.Name;
            Rating = shop.Rating;
            City = shop.CityId;
            Country = shop.CountryId;
            District = shop.DistrictId;
            About = shop.About;
            Policy = shop.Policy;
            Street = shop.Street;
            User = new ApplicationUserDTO(shop.User);
        }
        public static Shop DTOToShop(ShopDTO shopDto)
        {
            return new Shop()
            {
                Id = shopDto.Id,
                Name = shopDto.Name,
                Rating = shopDto.Rating,
                CityId = shopDto.City,
                CountryId = shopDto.Country,
                DistrictId = shopDto.District,
                Street = shopDto.Street,
                About = shopDto.About,
                Policy = shopDto.Policy
            };
        }

        public static ShopDTO ShopToDTO(Shop shop)
        {
            return new ShopDTO
            {
                Id = shop.Id,
                Name = shop.Name,
                Rating = shop.Rating,
                City = shop.CityId,
                Country = shop.CountryId,
                District = shop.DistrictId,
                About = shop.About,
                Policy = shop.Policy,
                Street = shop.Street,
                User = new ApplicationUserDTO()
                {
                    Id = shop.User.Id,
                    FirstName = shop.User.FirstName,
                    LastName = shop.User.LastName,
                    UserName = shop.User.UserName,
                    Email = shop.User.Email,
                    Photo = shop.User.Photo,
                    Cover = shop.User.CoverPhoto,
                }
            };
        }
    }
}