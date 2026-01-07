using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using VideoGameModel.model;

namespace Modul2WEBAPI
{
    
        public class VideoGameCsvRepository
    {
        private readonly List<VideoGame> _games=new();
        private int _nextId=1;
        public VideoGameCsvRepository()
        {
            LoadFromCsv();
        }
        private void LoadFromCsv()
        {
            using var reader = new StreamReader("VideoGameCsvs.csv");
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                
                HasHeaderRecord=true
            });
            
            var records = csv.GetRecords<VideoGameCSV>();

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
        public List<VideoGame> GetAll() => _games;
        public VideoGame? GetById(int id)=>
            _games.FirstOrDefault(g=>g.GameID==id);
        public VideoGame Add (VideoGame game)
        {
            game.GameID=_nextId++;
            _games.Add(game);
            return game;
        }
        public bool Update(int id, VideoGameCSV update)
        {
            var game = GetById(id);
            if(game==null)return false;

            game.Title=update.Title;
            game.Genere=update.Genere;
            game.Platform=update.Platform;
            game.ReleaseYear=update.ReleaseYear;
            game.Publisher=update.Publisher;
            game.GlobalSales=update.GlobalSales;
            game.Rating=update.Rating;

            return true;;
        }
        
        public bool Delete(int id)
        {
            var game = GetById(id);
            if (game==null)return false;

            _games.Remove(game);
            return true;
        }
    }
}