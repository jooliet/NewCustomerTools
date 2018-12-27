using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoSwitch.CustomerTools.DAL
{
    public interface IDataRepositoryStore
    {
        object this[string key] { get; set; }
    }
}
