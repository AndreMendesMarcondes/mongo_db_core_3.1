using MongoDB.Driver;
using MongoPOC.Models;
using System.Collections.Generic;
using System.Linq;

namespace MongoPOC.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IMongoCollection<Anime> _animes;

        public AnimeService(IAnimestoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _animes = database.GetCollection<Anime>(settings.AnimesCollectionName);
        }

        public List<Anime> Get() => _animes.Find(anime => true).ToList();

        public Anime Get(string id) => _animes.Find<Anime>(anime => anime.Id == id).FirstOrDefault();

        public Anime Create(Anime anime)
        {
            _animes.InsertOne(anime);
            return anime;
        }

        public void Update(string id, Anime animeIn) =>
            _animes.ReplaceOne(anime => anime.Id == id, animeIn);

        public void Remove(Anime animeIn) =>
            _animes.DeleteOne(anime => anime.Id == animeIn.Id);

        public void Remove(string id) =>
            _animes.DeleteOne(anime => anime.Id == id);
    }
}
