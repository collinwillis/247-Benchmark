using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmark.Models;

namespace Benchmark.Business.Data
{
    public interface IDataAccess
    {
        bool insertVerse(Verse v);

        Verse getText(Verse v);
    }
}
