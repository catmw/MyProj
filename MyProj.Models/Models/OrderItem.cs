using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.Models.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Book? Book { get; set; }
        public int QtyOrdered { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
