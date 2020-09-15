using DataAccess.Core;
using Services.Common;
using System;
using System.Reflection;
using System.Linq;

namespace Services.AbstractService
{
    public abstract class AbstractService
    {
        private readonly DataAccess.Core.IBaseContext _context;
        private readonly IFileUtils _fileUtils;


        public T GetRepository<T>(IBaseContext c) {
            var AllTypesOfIRepository = from x in Assembly.GetAssembly(typeof(T)).GetTypes()
                                        where
                                        x.GetInterfaces().Contains(typeof(T))
                                        select x;
            var o = Activator.CreateInstance(AllTypesOfIRepository.First(), c);
            return (T)o;
        }

        public AbstractService() 
        {
            _fileUtils = new FileUtils();
        }

        public AbstractService(DataAccess.Core.IBaseContext context, IFileUtils fileUtils)
        {
            _context = context;
            _fileUtils = fileUtils;
        }

        public AbstractService(DataAccess.Core.IBaseContext context)
        {
            _context = context;
        }

        internal DataAccess.Core.IBaseContext NewContext()
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
