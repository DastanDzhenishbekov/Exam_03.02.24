using System;
using System.Collections.Generic;

using System.Collections.Generic;

namespace EXAM_4
{
    public class CrocodileComparer : IComparer<Crocodile>
    {
        public int Compare(Crocodile x, Crocodile y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
