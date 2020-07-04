using DataAccess.Core;
using Services.Common;

namespace Services.AbstractService
{
    public abstract class AbstractService
    {
        private readonly DataAccess.Core.BaseContext _context;
        private readonly IFileUtils _fileUtils;

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
            if (_context == null) return new DataAccess.Core.DevContext(new DevSeeder());
            return _context;
        }

        internal IFileUtils GetFileUtils()
        {
            return _fileUtils;
        }
    }
}
