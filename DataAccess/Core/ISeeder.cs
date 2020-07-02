using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core
{
    public interface ISeeder
    {
        public void Seed(DevContext ctx);
    }
}