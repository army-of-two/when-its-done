using System;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;

namespace WhenItsDone.MVP.AdminPageControls.EventArguments
{
    public class WorkerDetailsEventArgs : EventArgs
    {
        public WorkerDetailsEventArgs(string id,
                                        string firstName,
                                        string lastName,
                                        string gender,
                                        string age,
                                        string rating,
                                        string email,
                                        string phone,
                                        string country,
                                        string city,
                                        string street)
        {
            this.Id = int.Parse(id);
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = this.GenderParse(gender);
            this.Age = int.Parse(age);
            this.Rating = int.Parse(rating);
            this.Email = email;
            this.PhoneNumber = phone;
            this.Country = country;
            this.City = city;
            this.Street = street;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public int Age { get; set; }

        public int Rating { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        private GenderType GenderParse(string value)
        {
            GenderType result;

            Enum.TryParse(value, out result);

            return result;
        }
    }
}
