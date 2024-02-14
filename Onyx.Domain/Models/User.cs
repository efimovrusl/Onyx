using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address? Address { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<Wallet> Wallets { get; set; }
    }

}
