﻿using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.Order
{
    public class Order : AuditableEntity
    {

        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public string Address { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}