using System;
using System.Linq;
using System.IO;
using System.Threading;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines present: {lines.Length}");
            if (lines.Length < 1)
            {
                logger.LogError("ERROR: No lines detected");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("WARNING: Only one line detected");
            }
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------
            logger.LogInfo("Begin parsing...");
         
            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tacoBellAlpha = null;
            ITrackable tacoBellOmega = null;
            double distance = 0.0;
            
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            
            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                //locA holds the location we are on while incrementing through array
                var locA = locations[i];

                // Create a new corA Coordinate with your locA's lat and long
                    //Instantiated GeoCoordinate here, set coordinate's Lat and Long to location's Lat and Long for 'origin'
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

                /* REMEMBER - this nested loop will COMPARE the two variables, x and i. Loop on the inside will iterate thru 
                the array BEFORE loop on the outside, effectively comparing the locations in this instance */
                for (int x = 0; x < locations.Length; x++)
                {
                    var locB = locations[x];
                    // Create a new Coordinate with your locB's lat and long
                    // Exact same as above but for 'destination'
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;
                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    //I keep this inside the second for loop in order to compare the distance for destination to origin

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        /* If the distance is greater than the currently saved distance,
                         update the distance and the two `ITrackable` variables you set above */
                        distance = corA.GetDistanceTo(corB);
                        tacoBellAlpha = locA;
                        tacoBellOmega = locB;
                        /*remember, 'distance' was stored as 0 all the way at the top,
                         represents the max distance we have found */
                    }
                }  
            }
            logger.LogInfo("Furthest locations found, calculating distance...");
            double distanceMiles = distance / 1609;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(1000);
            }
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            logger.LogInfo($"{tacoBellAlpha.Name} and {tacoBellOmega.Name} are the furthest away from each other at {distance} meters, or {distanceMiles} miles.");
        }
    }
}
