﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.datacontract
{
    public class MovieDTO
    {
        public string title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public float AverageScore { get; set; }
        public string CategoryName { get; set; }
        public string Rating { get; set; }
        public Guid Id { get; set; }
    }
}
