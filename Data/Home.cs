using System;
using System.Collections.Generic;

namespace WebApp.Data
{
    public partial class Home
    {

[System.ComponentModel.DataAnnotations.Key]
        public string Key { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public string ColumnName { get; set; } = null!;
    }
}
