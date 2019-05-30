using System;

namespace ClientWebAPI.Model.Dto
{
    public class ClientDto
    { 
        public Guid Id { get; set; }

        public string ClientName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNo { get; set; }

        public string MobileNo { get; set; }

        public string StreetAddr { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Industry { get; set; }

        public string Description { get; set; }
    }
}
