using Model.Entities;
using System.Collections.Generic;

namespace DataAccess.Core
{
    public abstract class BaseSeeder: ISeeder
    {
        private readonly bool _transient;

        public BaseSeeder(bool transient) 
        {
            _transient = transient;
        }

        public abstract void Seed(BaseContext context);

        public bool Transient()
        {
            return _transient;
        }
    }
}
