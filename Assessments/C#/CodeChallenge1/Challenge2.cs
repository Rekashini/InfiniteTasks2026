using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    struct Employeees
    {
         public string Name;
         public struct BirthDate
         {
                public int Day;
                public int Month;
                public int Year;
         }
         public BirthDate DOB;
     }

}
