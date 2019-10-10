using System.Collections.Generic;


namespace MitchellCodingChallenge.Models
{
    public class AllVehicles
    {
        public static List<Vehicle> VehicleList = new List<Vehicle>()
        {//sample entries
          new Vehicle(){Id = 1,Year = 1995,Make = "Toyota",Model = "Prius" },
          new Vehicle(){Id = 2,Year = 1996,Make = "Toyota",Model = "Corolla" },
          new Vehicle(){Id = 3,Year = 1997,Make = "Ford",Model = "Truck" },
          new Vehicle(){Id = 4,Year = 1998,Make = "Nissan",Model = "Car" },
          new Vehicle(){Id = 5,Year = 1999,Make = "Subaru",Model = "Sedan" },
          new Vehicle(){Id = 6,Year = 1999,Make = "Honda",Model = "Civic" }
         };

    }
}
