﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TimelyDepotMVC.Models.Admin
{
    public class SPECIALITEM
    {
        [Key]
        [MaxLength(50)]
        public string ItemID { get; set; }

        [MaxLength(50)]
        public string Price { get; set; }

        [MaxLength(50)]
        public string Option { get; set; }

        [MaxLength(50)]
        public string PicID { get; set; }
    }
}