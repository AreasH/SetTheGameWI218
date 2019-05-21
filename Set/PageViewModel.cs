using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    /// <summary>
    /// This is an interface for all Page ViewModels. 
    /// </summary>

    public interface PageViewModel
    {
        string Name { get; }

        Object Data { get; }
    }

    
}
