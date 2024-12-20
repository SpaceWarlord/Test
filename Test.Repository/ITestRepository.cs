using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test.Models;

namespace Test.Repository
{
    /// <summary>
    /// Defines methods for interacting with the app backend.
    /// </summary>
    public interface ITestRepository
    {        

        /// <summary>
        /// Returns the clients repository.
        /// </summary>
        IClientRepository Clients { get; }
       
    }
}
