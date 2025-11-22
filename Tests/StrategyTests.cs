using DesignPatterns.Strategy;
using System.Linq;
using Xunit;

namespace Tests
{
    public class StrategyTests
    {
        [Fact]
        public void Sorter_Uses_Strategies_Correctly()
        {
            var data = new[] { 5, 3, 8, 1, 4 };
            var bubble = new BubbleSortStrategy();
            var quick = new QuickSortStrategy();

            var sorter = new Sorter(bubble);
            var sortedByBubble = sorter.Sort(data);
            Assert.True(sortedByBubble.SequenceEqual(new[] { 1, 3, 4, 5, 8 }));
            Assert.Equal("BubbleSort", sorter.StrategyName);

            sorter.SetStrategy(quick);
            var sortedByQuick = sorter.Sort(data);
            Assert.True(sortedByQuick.SequenceEqual(new[] { 1, 3, 4, 5, 8 }));
            Assert.Equal("QuickSort", sorter.StrategyName);
        }
    }
}
