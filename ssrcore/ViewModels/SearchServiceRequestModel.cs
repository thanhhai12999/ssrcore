﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssrcore.ViewModels
{
    public class SearchServiceRequestModel : ResourceParameters
    {
        public string DepartmentId { get; set; }
        public string ServiceId { get; set; }
        public string StaffUsername { get; set; }
        public string StudentUsername { get; set; }
        public string Status { get; set; }
    }
}
