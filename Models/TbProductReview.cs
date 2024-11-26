using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class TbProductReview
{
    [Key]
    public int ProductReviewId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? Star { get; set; }

    public int? ProductId { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbProduct? Product { get; set; }
}
