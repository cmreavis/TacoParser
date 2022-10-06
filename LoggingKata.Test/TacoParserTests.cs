using System;
using System.Net.WebSockets;
using Xunit;
using Xunit.Sdk;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", " Taco Bell Acwort...")]
        [InlineData("34.996237,-85.291147, Taco Bell Chattanooga", " Taco Bell Chattanooga")]
        [InlineData("4, -29, Taco Bell The Nether", " Taco Bell The Nether")]
        [InlineData("21, 0 , Taco Bell Middle Earth", " Taco Bell Middle Earth")]
        public void ShouldParseName(string line, string expected)
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actualName = tacoParser.Parse(line);

            //Assert
            Assert.Equal(actualName.Name, expected);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga", -85.291147)]
        [InlineData("4, -29, Taco Bell The Nether", -29)]
        [InlineData("21, 0 , arhjkkarr", 0)]
        [InlineData("0, 0, jasdkljl", 0)]
        public void ShouldParseLongitude(string line, double? expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actualLong = tacoParser.Parse(line);
            //Assert
            Assert.Equal(expected, actualLong.Location.Longitude);      /*HERE I was stuck for a while, need to remember to use the ITrackable                                                              properties to get to the Location.Longitude (peel back the layers!) */
        }

        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga", 34.996237)]
        [InlineData("4, -29, Taco Bell The Nether", 4)]
        [InlineData("0, 21 , arhjkkarr", 0)]
        [InlineData("0, 0, jasdkljl", 0)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actualLat = tacoParser.Parse(line);
            //Assert
            Assert.Equal(expected, actualLat.Location.Latitude);
        }

    }
}
