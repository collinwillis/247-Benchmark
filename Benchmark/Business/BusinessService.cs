using Benchmark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Benchmark.Business.Data;


namespace Benchmark.Business
{
    public class BusinessService : IBusinessService
    {
        private IDataAccess _iAccess;

        public BusinessService(IDataAccess dataAccess)
        {
            _iAccess = dataAccess;
        }

        public Verse getText(Verse V)
        {
            return _iAccess.getText(V);
        }

        public bool insertVerse(Verse v)
        {
            return _iAccess.insertVerse(v);
        }
    }
}