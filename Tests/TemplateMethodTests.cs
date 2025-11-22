using DesignPatterns.TemplateMethod;
using Xunit;

namespace Tests
{
    public class TemplateMethodTests
    {
        [Fact]
        public void SalesReport_Generates_Correctly()
        {
            var r = new SalesReport();
            var output = r.GenerateReport();
            Assert.Contains("SalesReport", output);
            Assert.Contains("Total=450", output);
        }

        [Fact]
        public void InventoryReport_Generates_Correctly()
        {
            var r = new InventoryReport();
            var output = r.GenerateReport();
            Assert.Contains("InventoryReport", output);
            Assert.Contains("TotalItems=35", output);
        }
    }
}
