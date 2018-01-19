using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMongouille
{
    public class Film
    {
        [BsonElement("film_id")]
        public int Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("release_year")]
        public int ReleaseYear { get; set; }

        [BsonElement("rental_duration")]
        public int RentalDuration { get; set; }

        [BsonElement("rental_rate")]
        public int RentalRate { get; set; }

        [BsonElement("length")]
        public int Length { get; set; }

        [BsonElement("replacement_cost")]
        public int ReplacementCost { get; set; }

        [BsonElement("rating")]
        public int Rating { get; set; }

        [BsonElement("special_features")]
        public string SpecialFeatures { get; set; }

        [BsonElement("film_last_update")]
        public string FilmLastUpdate { get; set; }

        [BsonElement("language_name")]
        public string LanguageName { get; set; }

        [BsonElement("category_name")]
        public string CategoryName { get; set; }

        [BsonElement("actors")]
        public List<Actor> Actors { get; set; }
    }
}
