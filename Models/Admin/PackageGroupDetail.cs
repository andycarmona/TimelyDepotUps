﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelyDepotMVC.Models.Admin
{
    public class PackageGroupDetail
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string GroupName { get; set; }

        [MaxLength(100)]
        public string PAckageId { get; set; }
    }
}