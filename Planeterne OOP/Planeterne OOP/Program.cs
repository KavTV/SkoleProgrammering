using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeterne_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> Planets = new List<Planet>();

            // Tilføjer til liste
            Planets.Add(new Planet { Name = "Merkur", Mass = 0.33, Diameter = 4879, Density = 5427, Gravity = 3.7, Rotationperiod = 1407.6, Lengthofday = 4222.6, Distancefromsun = 57.9, Orbitalperiod = 88, Orbitalvelocity = 47.4, Meantemperature = 167, Numberofmoons = 0, Ringsystem = false, });
            Planets.Add(new Planet { Name = "Venus", Mass = 4.87, Diameter = 12104, Density = 5243, Gravity = 8.9, Rotationperiod = -5832.5, Lengthofday = 2802, Distancefromsun = 108.2, Orbitalperiod = 224.7, Orbitalvelocity = 35, Meantemperature = 464, Numberofmoons = 0, Ringsystem = false, });
            Planets.Add(new Planet { Name = "Jorden", Mass = 5.97, Diameter = 12756, Density = 5514, Gravity = 9.8, Rotationperiod = 23.9, Lengthofday = 24, Distancefromsun = 149.6, Orbitalperiod = 365.2, Orbitalvelocity = 29.8, Meantemperature = 15, Numberofmoons = 0, Ringsystem = false, });
            Planets.Add(new Planet { Name = "Mars", Mass = 0.642, Diameter = 6792, Density = 3933, Gravity = 3.7, Rotationperiod = 24.6, Lengthofday = 24.7, Distancefromsun = 227.9, Orbitalperiod = 687, Orbitalvelocity = 24.1, Meantemperature = -65, Numberofmoons = 2, Ringsystem = false, });
            Planets.Add(new Planet { Name = "Jupiter", Mass = 1898, Diameter = 142984, Density = 1326, Gravity = 23.1, Rotationperiod = 9.9, Lengthofday = 9.9, Distancefromsun = 778.6, Orbitalperiod = 4331, Orbitalvelocity = 13.1, Meantemperature = -110, Numberofmoons = 67, Ringsystem = true, });
            Planets.Add(new Planet { Name = "Saturn", Mass = 568, Diameter = 120536, Density = 687, Gravity = 9, Rotationperiod = 10.7, Lengthofday = 10.7, Distancefromsun = 1433.5, Orbitalperiod = 10.747, Orbitalvelocity = 9.7, Meantemperature = -140, Numberofmoons = 62, Ringsystem = true, });
            Planets.Add(new Planet { Name = "Pluto", Mass = 0.0146, Diameter = 2370, Density = 2095, Gravity = 0.7, Rotationperiod = -153.3, Lengthofday = 153.3, Distancefromsun = 5906.4, Orbitalperiod = 90.56, Orbitalvelocity = 4.7, Meantemperature = -225, Numberofmoons = 5, Ringsystem = false, });
            Planets.Add(new Planet { Name = "Neptune", Mass = 102, Diameter = 49528, Density = 1638, Gravity = 11, Rotationperiod = 16.1, Lengthofday = 16.1, Distancefromsun = 4495.1, Orbitalperiod = 59.8, Orbitalvelocity = 5.4, Meantemperature = -200, Numberofmoons = 14, Ringsystem = true, });
            Planets.Add(new Planet { Name = "Uranus", Mass = 86.8, Diameter = 51118, Density = 1271, Gravity = 8.7, Rotationperiod = -17.2, Lengthofday = 17.2, Distancefromsun = 2872.5, Orbitalperiod = 30.589, Orbitalvelocity = 6.8, Meantemperature = -195, Numberofmoons = 27, Ringsystem = true, });

            foreach (var item in Planets)
            {
                if (item.Name == "Pluto")
                {
                    Planets.Remove(item);
                    break;
                }
            }
            //tilføjer lige pluto igen
            Planets.Add(new Planet { Name = "Pluto", Mass = 0.0146, Diameter = 2370, Density = 2095, Gravity = 0.7, Rotationperiod = -153.3, Lengthofday = 153.3, Distancefromsun = 5906.4, Orbitalperiod = 90.56, Orbitalvelocity = 4.7, Meantemperature = -225, Numberofmoons = 5, Ringsystem = false, });
            //Udskriver alt information ud i et
            foreach (var item in Planets)
            {

                Console.WriteLine("Name: {0} Mass: {1} Diameter: {2} Density: {3} Gravity: {4} Rotation: {5} Lengthofday: {6} Distancefromsun: {7} Orbital preiod: {8} Orbital velocity: {9} Mean temperature: {10} Number of moons: {11} Ringsystem: {12}", item.Name, item.Mass, item.Diameter, item.Density, item.Gravity, item.Rotationperiod, item.Lengthofday, item.Distancefromsun, item.Orbitalperiod, item.Orbitalvelocity, item.Meantemperature, item.Numberofmoons, item.Ringsystem + Environment.NewLine);
                
            }
            Console.WriteLine("Planeter: {0}", Planets.Count);
            Console.WriteLine("-------------------");
            //opretter ny liste
            List<Planet> ColdPlanets = new List<Planet>();

            //Laver noget der minder om SQL også kaldt LINQ
            IEnumerable<Planet> meanTemp =
                        from Planet in Planets
                        where Planet.Meantemperature < 0
                        select Planet;
            foreach (var item in meanTemp)
            {
                ColdPlanets.Add(item);
                Console.WriteLine("{0} har en Mean temperature på: {1}", item.Name,item.Meantemperature);
            }
            
            List<Planet> THICCPlanets = new List<Planet>();

            //Laver noget der minder om SQL også kaldt LINQ
            IEnumerable<Planet> diameterPlanet =
                        from Planet in Planets
                        where Planet.Diameter > 10000
                        where Planet.Diameter < 50000
                        select Planet;
            //laver en ny liste
            Console.WriteLine(Environment.NewLine);
            //Laver foreach til at smide alt der passer med diameterPlanet ind i en ny liste 
            foreach (var item in diameterPlanet)
            {
                THICCPlanets.Add(item);
                Console.WriteLine("{0} har en diameter på: {1}",item.Name, item.Diameter);
            }
            //Sletter hele listen
            Console.WriteLine("Alle planeter slettes fra main listen her er den skrevet ud ;)");
            Planets.Clear();

            //hvis listen er tom skal den lave ---- og hvis den ikke er udskriver den planeternes navn
            if (Planets.Count != 0)
            {

            foreach (var item in Planets)
            {
                
                Console.WriteLine(item.Name);
                
            }
            }
            else
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
            }

            Console.ReadLine();
        }
    }
}
