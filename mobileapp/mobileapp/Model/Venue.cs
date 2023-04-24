using mobileapp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobileapp.Model
{
    public class Venue
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(constant.VENUE_SEARCH, latitude,longitude);
        }
    }
}
