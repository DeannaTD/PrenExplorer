﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenExplorer.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NPUser> Users { get; set; }
    }
}
