using System;

namespace ecommerce.DTOs.Response
{
    public class UserResponse
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
