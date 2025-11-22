namespace DesignPatterns.Strategy
{
    public interface ISortStrategy
    {
        string Name { get; }
        int[] Sort(int[] data);
    }

    public class BubbleSortStrategy : ISortStrategy
    {
        public string Name => "BubbleSort";

        public int[] Sort(int[] data)
        {
            var arr = (int[])data.Clone();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
            return arr;
        }
    }

    public class QuickSortStrategy : ISortStrategy
    {
        public string Name => "QuickSort";

        public int[] Sort(int[] data)
        {
            var arr = (int[])data.Clone();
            System.Array.Sort(arr); // simple reliable implementation
            return arr;
        }
    }

    public class Sorter
    {
        private ISortStrategy _strategy;

        public Sorter(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public string StrategyName => _strategy?.Name ?? "(none)";

        public void SetStrategy(ISortStrategy strategy) => _strategy = strategy;

        public int[] Sort(int[] data) => _strategy.Sort(data);
    }
}
