﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDcr { get; set; }
        public int Price { get; set; }
    }
}
