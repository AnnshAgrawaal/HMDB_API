using HMDB_API.Models.DTO;

namespace HMDB_API.Data
{
    public static class MovieStore
    {
        public static List<MovieDTO> movieList = new List<MovieDTO> {
                new MovieDTO {Id=1, Name= "Zindagi Na Milegi Dobara", Director="Zoya Akhtar", Rating=8.2f},
                new MovieDTO {Id=2, Name= "Bajirao Mastani", Director="Sanjay Leela Bhansali", Rating=7.2f},
                new MovieDTO { Id = 3, Name = "3 Idiots", Director="Rajkumar Hirani", Rating=8.4f},
                new MovieDTO { Id = 4, Name = "Gangs of Wasseypur", Director="Anurag Kashyap", Rating=8.2f},
                new MovieDTO { Id = 5, Name = "PK", Director="Rajkumar Hirani", Rating=8.1f}
            };
    }
}
