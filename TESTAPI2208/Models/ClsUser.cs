﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTAPI2208.Models
{
    public class ClsUser
    {
         public string Id { get; set; }
        public int ApplicationId { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public decimal Amount { get; set; }
        public DateTime PostingDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime? ClearedDate { get; set; }

    }
}