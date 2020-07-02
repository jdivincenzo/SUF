using Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AbstractService
{
    public abstract class AbstractService
    {
        private DataAccess.Core.DevContext _context;
        private IFileUtils _fileUtils;

        public AbstractService() 
        {
            _fileUtils = new FileUtils();
        }

        public AbstractService(DataAccess.Core.DevContext context, IFileUtils fileUtils)
        {
            _context = context;
            _fileUtils = fileUtils;
        }

        public AbstractService(DataAccess.Core.DevContext context)
        {
            _context = context;
        }

        internal DataAccess.Core.DevContext NewContext()
        {
            if (_context == null) return new DataAccess.Core.DevContext();
            return _context;
        }

        internal IFileUtils GetFileUtils()
        {
            return _fileUtils;
        }
    }
}
