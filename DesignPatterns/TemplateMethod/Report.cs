namespace DesignPatterns.TemplateMethod;

// Template Method pattern: defines skeleton of an algorithm in base class and lets subclasses override specific steps.
public abstract class Report
{
    // Template method
    public string GenerateReport()
    {
        var data = CollectData();
        var analysis = AnalyzeData(data);
        var formatted = FormatReport(data, analysis);
        return formatted;
    }

    protected abstract string CollectData();
    protected abstract string AnalyzeData(string data);
    protected abstract string FormatReport(string data, string analysis);
}

public class SalesReport : Report
{
    protected override string CollectData()
    {
        // simulate data collection
        return "Sales:100,200,150";
    }

    protected override string AnalyzeData(string data)
    {
        // simple analysis: compute total
        var parts = data.Split(':')[1].Split(',');
        int total = 0;
        foreach (var p in parts) total += int.Parse(p);
        return $"Total={total}";
    }

    protected override string FormatReport(string data, string analysis)
    {
        return $"SalesReport\nData: {data}\nAnalysis: {analysis}";
    }
}

public class InventoryReport : Report
{
    protected override string CollectData()
    {
        return "Items:A:10,B:5,C:20";
    }

    protected override string AnalyzeData(string data)
    {
        // count total items
        var parts = data.Split(':', ',');
        int total = 0;
        for (int i = 2; i < parts.Length; i += 2)
        {
            total += int.Parse(parts[i]);
        }
        return $"TotalItems={total}";
    }

    protected override string FormatReport(string data, string analysis)
    {
        return $"InventoryReport\nData: {data}\nAnalysis: {analysis}";
    }
}
