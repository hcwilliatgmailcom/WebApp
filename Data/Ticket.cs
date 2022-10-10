using System;
using System.Collections.Generic;

namespace WebApp.Data
{
    public partial class Ticket
    {
 

        public int Id { get; set; }
        public string Kurzbeschreibung { get; set; } = null!;
        public DateTime? Erstellt { get; set; }

      
    }
}
