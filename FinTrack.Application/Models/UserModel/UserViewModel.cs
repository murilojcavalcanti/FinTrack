using FinTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Models.UserModel
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string email, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static UserViewModel FromEntity(User user)=> new (user.Id,user.Name,user.Email,user.CreatedAt,user.UpdatedAt);
    }
}
