﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    public class Taco_Bell : ITrackable  //Conforms to ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
