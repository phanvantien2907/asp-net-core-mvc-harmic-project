﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class TbProductCategory
{
    [Key]
    public int CategoryProductId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public int? Position { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbNews> TbNews { get; set; } = new List<TbNews>();

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
