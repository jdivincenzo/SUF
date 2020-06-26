using Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AbstractService
{
    public class AbstractService
    {
        private DataAccess.Core.BaseContext _context;
        private IFileUtils _fileUtils;

        public AbstractService() 
        {
            _fileUtils = new FileUtils();
        }

        public AbstractService(DataAccess.Core.BaseContext context, IFileUtils fileUtils)
        {
            _context = context;
            _fileUtils = fileUtils;
        }

        public AbstractService(DataAccess.Core.BaseContext context)
        {
            _context = context;
        }

        internal DataAccess.Core.BaseContext NewContext()
        {
            if (_context == null) return new DataAccess.Core.BaseContext();
            return _context;
        }

        internal IFileUtils GetFileUtils()
        {
            return _fileUtils;
        }
    }
}
