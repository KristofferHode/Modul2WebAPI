using CsvHelper.Configuration.Attributes;
namespace Modul2WEBAPI;

    

    public class VideoGameCSV
    {
        public int GameID{get;set;}
        public string Title{get;set;}="";
        public string Genre{get;set;}="";
        public string Platform{get;set;}="";
        public double ReleaseYear{get;set;}
        public string Publisher{get;set;}="";
        public double GlobalSales{get;set;}
        public string? Rating{get;set;}
    } 
