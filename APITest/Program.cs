using Services.PostServices;
using Services.PostServices.ExternalModel;
using System;
using System.Collections.Generic;

namespace APITest
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<GetNearbyPostsReturn> results =  new PostService().GetNearby(new GetNearbyPostsInvoke { Lat= -34.630027,Lon=-58.692221, Distance =1});

            foreach (GetNearbyPostsReturn r in results)
                Console.WriteLine(r.Id);

            Console.WriteLine("Demo completed.");
            Console.ReadLine();
        }
    }
}
