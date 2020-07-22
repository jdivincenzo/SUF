namespace DataAccess.Core
{
    public interface ISeeder
    {
        public void Seed(IBaseContext ctx);
        public bool Transient();
    }
}