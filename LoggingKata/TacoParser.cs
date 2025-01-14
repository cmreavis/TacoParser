﻿namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogWarning("Location info incomplete. Will not be able to parse all information.");
                // Do not fail if one record parsing fails, return null
                return null;
                // TODO Implement
            }
                    // grab the latitude from your array at index 0
                    // grab the longitude from your array at index 1
                    // grab the name from your array at index 2
                    // You're going to need to parse your string as a `double`
                    // which is similar to parsing a string as an `int`

            //Lat and Long are being parsed from array 'cells' to double 
            var latitude = double.Parse(cells[0]);    
            var longitude = double.Parse(cells[1]);
            var nameTB = cells[2];


                    // You'll need to create a TacoBell class
                    // that conforms to ITrackable
                    // Then, you'll need an instance of the TacoBell class
                    // With the name and point set correctly

            //Instantiate Point struct to properly call for location 
            var location = new Point()
            {
                Latitude = latitude,
                Longitude = longitude,
            };
            var tBell = new Taco_Bell()
            {

                Name = nameTB,
                Location = location,
            };
            
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tBell;
        }
    }
}