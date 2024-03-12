using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    
    public enum OperationStatus : int
    {
        SuccessfullyDone = 1,
        NotFound = 2,
        ServerErrorOccurs = 3
    }
}
