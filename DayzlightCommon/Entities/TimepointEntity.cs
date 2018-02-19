﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayzlightCommon.Entities
{
    public class TimepointEntity
    {
        [Key]
        [Index(IsUnique = true)]
        [Required]
        public Int64 Id { set; get; }

        [Index(IsUnique = true)]
        [Required]
        public DateTime TimePoint { set; get; }
    }
}