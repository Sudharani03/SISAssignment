﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Exceptions
{
    internal class StudentNotFoundException:ApplicationException
    {
        public StudentNotFoundException() { }

        public StudentNotFoundException(string message) : base(message) { }
    }
}
