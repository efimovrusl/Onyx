using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onyx.Domain.Enums;

namespace Onyx.Domain.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
    }
}
