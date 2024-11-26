using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class TbOrderStatus
{
    [Key]
    public int OrderStatusId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
