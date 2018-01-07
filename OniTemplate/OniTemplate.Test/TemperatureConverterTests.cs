using OniTemplate.Extensions;
using Xunit;

namespace OniTemplate.Test
{
    public class TemperatureConverterTests
    {
        [Fact]
        public void ConvertToCelciusTest()
        {
            var kelvin = 315.25;
            var celcius = kelvin.ToCelcius();
            Assert.Equal(42.1, celcius);
        }

        [Fact]
        public void ConvertToFarenheightTest()
        {
            var kelvin = 372.89;
            var farenheight = kelvin.ToFarenheight();
            Assert.Equal(211.8, farenheight);
        }
    }
}
