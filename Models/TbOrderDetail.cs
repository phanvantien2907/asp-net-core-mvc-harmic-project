using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class TbOrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual TbOrder? Order { get; set; }
}
