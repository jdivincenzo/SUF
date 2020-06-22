using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common
{
    public class AbstractService
    {
        private DataAccess.Core.AppContext _context;

        public AbstractService() { }

        public AbstractService(DataAccess.Core.AppContext context)
        {
            _context = context;
        }

        internal DataAccess.Core.AppContext NewContext()
        {
            if (_context == null) return new DataAccess.Core.AppContext();
            return _context;
        }
    }
}
