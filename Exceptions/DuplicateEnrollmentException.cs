﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Exceptions
{
    internal class DuplicateEnrollmentException:ApplicationException
    {
        public DuplicateEnrollmentException() { }
        public DuplicateEnrollmentException(string message) : base(message) { }
    }
}
