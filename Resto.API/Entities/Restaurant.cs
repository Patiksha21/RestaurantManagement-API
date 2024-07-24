using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;

namespace Resto.API.Entities
{
    public class Restaurant
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public string? UserId { get; set; }

    }
}
