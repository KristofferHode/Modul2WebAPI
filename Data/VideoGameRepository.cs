using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Videgame.model;

namespace Modul2WEBAPI.Data;


public class VideoGameRepository
{
    private readonly List<VideoGame> _games=new();
    private int _nextId=1;
    public VideoGameRepository()
    {
        LoadFromCsv();
    }
    private void LoadFromCsv()
    {
        using var reader = new StreamReader("VideoGames.csv");
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            
            HasHeaderRecord=true
        });
        
        var records = csv.GetRecords<VideoGameCsv>();

        foreach (var r in records)
        {
            _games.Add(new VideoGame
            {
                GameID=_nextId++,
                Title= r.Title,
                Genere= r.Genere,
                Platform=r.Platform,
                ReleaseYear= r.ReleaseYear,
                Publisher=r.Publisher,
                GlobalSales=r.GlobalSales,
                Rating=r.Rating
            });
        }
    }
    public List<Videogame> GetAll() => _games;
    public VideoGame? GetById(int id)=>
        _games.FirstOrDefault(g=>g.Id==id);
    public VideoGame Add (VideoGame game)
    {
        game.Id=_nextId++;
        _games.Add(game);
    }
}
