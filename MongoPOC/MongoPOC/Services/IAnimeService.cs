using MongoDB.Driver;
using MongoPOC.Models;
using System.Collections.Generic;
using System.Linq;

namespace MongoPOC.Services
{
    public interface IAnimeService
    {
        List<Anime> Get();
        Anime Get(string id);
        Anime Create(Anime anime);
        void Update(string id, Anime animeIn);
        void Remove(Anime animeIn);
        void Remove(string id);
    }
}
