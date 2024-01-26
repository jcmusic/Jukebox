using Jcm.Models.Api;

namespace Jcm.DAL
{
    public class PerformanceActDataStore
    {
        public List<PerformanceAct> PerformanceActs { get; set; }
        public static PerformanceActDataStore Current { get; } = new PerformanceActDataStore();

        public PerformanceActDataStore()
        {
            // init dummy data
            PerformanceActs = new List<PerformanceAct>()
            {
                new PerformanceAct()
                {
                     Id = 1,
                     Name = "The Beatles",
                     //Description = "The one with that big park.",
                     Performers = new List<Performer>()
                     {
                         new Performer() {
                             Id = 1,
                             FirstName = "John"
                         },
                         new Performer() {
                             Id = 2,
                             FirstName = "Paul"
                         },
                         new Performer() {
                             Id = 3,
                             FirstName = "George"
                         },
                         new Performer() {
                             Id = 4,
                             FirstName = "Ringo"
                         }
                     }
                },
                new PerformanceAct()
                {
                    Id = 2,
                    Name = "The Rolling Stones",
                    //Description = "The one with the cathedral that was never really finished.",
                     Performers = new List<Performer>()
                     {
                         new Performer() {
                             Id = 5,
                             FirstName = "Mick",
                             LastName = "Jagger"
                         },
                         new Performer() {
                             Id = 6,
                             FirstName = "Keith",
                             LastName = "Richards"
                         },
                         new Performer() {
                             Id = 7,
                             FirstName = "Ron",
                             LastName = "Wood"
                         },
                         new Performer() {
                             Id = 8,
                             FirstName = "Bill",
                             LastName = "Wyman"
                         },
                         new Performer() {
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
