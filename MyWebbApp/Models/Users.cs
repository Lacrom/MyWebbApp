using System;
using System.Collections.Generic;

namespace MyWebbApp.Models
{
    public partial class Users
    {
        public int ID { get; set; }
        public string UserNick { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Echelon { get; set; } = null!;
    }
}
