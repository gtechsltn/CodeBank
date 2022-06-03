﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category : EntityBase
    {
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<SourceCode> SourceCodes { get; set; }
    }
}
