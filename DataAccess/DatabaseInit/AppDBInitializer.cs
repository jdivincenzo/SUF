using DataAccess.Core;
using Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.DatabaseInit
{
    //public class AppDBInitializer : CreateDatabaseIfNotExists<AppContext> 
    public class AppDBInitializer : DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            IList<Picture> pictures = new List<Picture>();
            pictures.Add(new Picture() { FileName = "File 1" });
            pictures.Add(new Picture() { FileName = "File 2" });
            context.Pictures.AddRange(pictures);

            base.Seed(context);
        }
    }
}