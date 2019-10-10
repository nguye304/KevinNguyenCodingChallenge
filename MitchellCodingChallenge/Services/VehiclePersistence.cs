using System;
using System.Collections.Generic;
using MitchellCodingChallenge.Models;

namespace MitchellCodingChallenge.Services
{

    public class VehiclePersistence
    {

        //GET: /api/vehicles
        //Returns all the vehicles currently in the list
        public List<Vehicle> GetAllVehicles()
        {
            return AllVehicles.VehicleList;
        }
        

        //GET: /api/vehicles/id
        //Returns the vehicle with the same Id
        public Vehicle GetVehicleByID(int id)
        {
            Vehicle v = new Vehicle();
            for (int i = 0; i < AllVehicles.VehicleList.Count; i++)
            {
                if (AllVehicles.VehicleList[i].Id == id)
                {
                    v = AllVehicles.VehicleList[i];
                    break;
                }
            }
            return v;
        }


        //POST: /api/vehicles
        //Adds a new Vehicle to the List
        public void CreateNewVehicle(Vehicle Car)
        {
            bool valid = CheckValidation(Car);
            if (valid == true)
            {
                if(Car.Id == 0)
                {
                    Car.Id = AllVehicles.VehicleList.Count+1;
                }
                AllVehicles.VehicleList.Add(Car);
            }
        }

        //PUT: /api/vehicles
        //Updates a vehicle with the same id with the request's information
        public void UpdateVehicle(Vehicle Car)
        {
            bool valid = CheckValidation(Car);
            if (valid == true)
            {
                for (int i = 0; i < AllVehicles.VehicleList.Count; i++)
                {
                    if (AllVehicles.VehicleList[i].Id == Car.Id)
                    {
                        AllVehicles.VehicleList[i].Id = Car.Id;
                        AllVehicles.VehicleList[i].Year = Car.Year;
                        AllVehicles.VehicleList[i].Make = Car.Make;
                        AllVehicles.VehicleList[i].Model = Car.Model;
                    }
                }
            }
        }

        //DELETE: /api/vehicles
        //Removes a vehicle from the List
        public void RemoveAVehicle(int id)
        {
            for (int i = 0; i < AllVehicles.VehicleList.Count; i++)
            {
                if (AllVehicles.VehicleList[i].Id == id)
                {
                    AllVehicles.VehicleList.Remove(AllVehicles.VehicleList[i]);
                }
            }
        }

        //----------------------------------------OPTIONAL----------------------------------------//

        //Checks if the vehicle has the correct values in their fields
        public bool CheckValidation(Vehicle Car)
        {
            bool validity = true;
            if (Car.Year < 1950 || Car.Year > 2050)
            {
                validity = false;
            //("Required Range: inclusive between 1950 and 2050");
            }
            if (Car.Make == null || Car.Make.Length > 100 || Car.Model == null || Car.Model.Length > 100)
            {
                validity = false;
            //("Required String length: inclusive between 0 and 100 ");
            }

            return validity;

        }


        //GET: /api/vehicles/filter?parameters
        //Returns all the vehicles that matches all the filters
        public List<Vehicle> GetAllVehiclesByFilter(string id, string year, string make, string model)//params string[] filters)
        {
            List<Vehicle> VehicleMatches = new List<Vehicle>();
            List<String> ActiveFilters = new List<string>();
            bool valid = true;

            //if the string isnt empty then use it as a filter
            if (id != " ")
                ActiveFilters.Add("id");
            if (year != " ")
                ActiveFilters.Add("year");
            if (make != " ")
                ActiveFilters.Add("make");
            if (model != " ")
                ActiveFilters.Add("model");

            for (int i = 0; i < AllVehicles.VehicleList.Count; i++)
            {
                valid = true;//reset the validity for each vehicle

                if (ActiveFilters.Contains("model") && valid == true)
                {
                    if (AllVehicles.VehicleList[i].Model.ToLower() != model.ToLower())
                    {
                        valid = false;
                    }
                }
                if (ActiveFilters.Contains("make") && valid == true)
                {
                    if (AllVehicles.VehicleList[i].Make.ToLower() != make.ToLower())
                    {
                        valid = false;
                    }
                }

                if (ActiveFilters.Contains("id") && valid == true)
                {
                    try
                    {
                        if (AllVehicles.VehicleList[i].Id != Int32.Parse(id))
                        {
                            valid = false;
                        }
                    }
                    catch (FormatException)
                    {
                        valid = false;
                    }
                }
                if (ActiveFilters.Contains("year") && valid == true)
                {
                    try
                    {
                        if (AllVehicles.VehicleList[i].Year != Int32.Parse(year))
                        {
                            valid = false;
                        }
                    }
                    catch (FormatException)
                    {
                        valid = false;
                    }
                }

                //if it got pass all the filters then add it to VehicleMatches
                if (valid == true)
                {
                    VehicleMatches.Add(AllVehicles.VehicleList[i]);
                }

            }

            return VehicleMatches;

        }


    }
}
