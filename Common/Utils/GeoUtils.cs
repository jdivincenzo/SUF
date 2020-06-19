using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils
{
    public static class GeoUtils
    {
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
                double rlat1 = Math.PI * lat1 / 180;
                double rlat2 = Math.PI * lat2 / 180;
                double theta = lon1 - lon2;
                double rtheta = Math.PI * theta / 180;
                double dist =
                    Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                    Math.Cos(rlat2) * Math.Cos(rtheta);
                dist = Math.Acos(dist);
                dist = dist * 180 / Math.PI;
                dist = dist * 60 * 1.1515;

                return dist * 16.09344;
        }
    }
}
