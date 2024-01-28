using Jcm.Models.Api;

namespace Jcm.DAL
{
    public class PerformanceActDataStore
    {
        public List<PerformanceActDto> PerformanceActs { get; set; }
        public static PerformanceActDataStore Current { get; } = new PerformanceActDataStore();

        public PerformanceActDataStore()
        {
            // init dummy data
            PerformanceActs = new List<PerformanceActDto>()
            {
                new PerformanceActDto()
                {
                     Id = 1,
                     Name = "The Beatles",
                     //Description = "The one with that big park.",
                     Performers = new List<PerformerDto>()
                     {
                         new PerformerDto() {
                             Id = 1,
                             FirstName = "John"
                         },
                         new PerformerDto() {
                             Id = 2,
                             FirstName = "Paul"
                         },
                         new PerformerDto() {
                             Id = 3,
                             FirstName = "George"
                         },
                         new PerformerDto() {
                             Id = 4,
                             FirstName = "Ringo"
                         }
                     }
                },
                new PerformanceActDto()
                {
                    Id = 2,
                    Name = "The Rolling Stones",
                    //Description = "The one with the cathedral that was never really finished.",
                     Performers = new List<PerformerDto>()
                     {
                         new PerformerDto() {
                             Id = 5,
                             FirstName = "Mick",
                             LastName = "Jagger"
                         },
                         new PerformerDto() {
                             Id = 6,
                             FirstName = "Keith",
                             LastName = "Richards"
                         },
                         new PerformerDto() {
                             Id = 7,
                             FirstName = "Ron",
                             LastName = "Wood"
                         },
                         new PerformerDto() {
                             Id = 8,
                             FirstName = "Bill",
                             LastName = "Wyman"
                         },
                         new PerformerDto() {
                             Id = 9,
                             FirstName = "Charlie",
                             LastName = "Watts"
                         }
                     }
                }
            };
        }
    }
}
