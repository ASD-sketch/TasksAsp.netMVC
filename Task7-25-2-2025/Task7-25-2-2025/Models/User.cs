using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task7_25_2_2025.Models;

public partial class User
{
    public int Id { get; set; }

   
    public string Name { get; set; } 

   
    public string Email { get; set; }

   
    public string Password { get; set; }

   
    public string Role { get; set; }
}
