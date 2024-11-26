using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class TbCustomer
{
    [Key]
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? LocationId { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool? IsActive { get; set; }
}
