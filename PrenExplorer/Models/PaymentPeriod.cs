﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrenExplorer.Models
{
    public class PaymentPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public long MustTotal { get; set; } //TODO: MUST TOTAL это вообще что?
        public DateTime PaymentStart { get; set; }
        public DateTime PaymentEnd { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual NPUser NPUser { get; set; }
    }
}
