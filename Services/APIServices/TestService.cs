using DataAccess.Core;
using DataAccess.Repositories;
using Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Services.APIServices
{
    public class TestService
    {
        public void CreateAndChangeStudents()
        {
            using (var ctx = new DataAccess.Core.AppContext())
            {
                var picture = new Picture() { FileName = "Filenew" };
                ctx.Pictures.Add(picture);
                
                var pictures = new PictureRepository(ctx).GetAll();
                foreach (Picture p in pictures)
                {
                    p.FileName += " MODIFIED"; 
                }
                
                ctx.SaveChanges();
            }
        }
    }
}
