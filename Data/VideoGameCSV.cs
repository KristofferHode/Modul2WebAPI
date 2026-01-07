using CsvHelper.Configuration.Attributes;

public class VideoGameCsv
{
    public string Title{get;set;}="";
    public string Genere{get;set;}="";
    public string Platform{get;set;}="";
    public double ReleaseYear{get;set;}
    public string Publisher{get;set;}="";
    [Name("Global_Sales")]
    public double GlobalSales{get;set;}
    public double Rating{get;set;}
}