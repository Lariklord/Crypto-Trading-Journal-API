using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoJournal.Core.Models
{
    internal class Trader
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string HashPassword { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}
