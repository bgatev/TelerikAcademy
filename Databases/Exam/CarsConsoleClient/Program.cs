namespace CarsConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using CarsData;
    using CarsModel;


    public class Program
    {
        private static CarsDB db;
        private const string JSONFilePath = @"../../imports/data.";

        public static void Main()
        {
            db = new CarsDB();
 
            for (int i = 0; i < 5; i++)
            {
                HashSet<Car> allCars = GetFileTextContent(JSONFilePath + i + @".json");
                HashSet<Manifacturer> allManifacturers = new HashSet<Manifacturer>();
                HashSet<City> allCities = new HashSet<City>();

                foreach (var car in allCars)
                {
                    var currentCar = new Car();
                    var currentManifacturer = new Manifacturer();
                    var currentDealer = new Dealer();
                    var currentCity = new City();

                    currentManifacturer.Name = car.ManufacturerName;
                    currentCity.Name = car.Dealer.City;

                    currentDealer.Name = car.Dealer.Name;
                    currentDealer.City = car.Dealer.City;

                    currentCar.ManufacturerName = currentManifacturer.Name;
                    currentCar.Model = car.Model;
                    currentCar.TransmissionType = car.TransmissionType;
                    currentCar.Year = car.Year;
                    currentCar.Price = car.Price;
                    currentCar.Dealer = currentDealer;

                    if (!allCities.Contains(currentCity)) db.City.Add(currentCity);
                    allCities.Add(currentCity);

                    if (!allManifacturers.Contains(currentManifacturer)) db.Manifacturers.Add(currentManifacturer);
                    allManifacturers.Add(currentManifacturer);

                    db.Dealers.Add(currentDealer);
                    db.SaveChanges();
                    db.Cars.Add(currentCar);

                    db.SaveChanges();
                }
            }
        }

        private static HashSet<Car> GetFileTextContent(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("File does not exist. File name: " + fullPath);
            }

            HashSet<Car> allCars = new HashSet<Car>();

            StreamReader reader = new StreamReader(fullPath);

            using (reader)
            {
                string json = reader.ReadToEnd();
                allCars = JsonConvert.DeserializeObject<HashSet<Car>>(json);
            }

            return allCars;
        }

        private static XDocument ConvertStringToXml(string text)
        {
            var xml = XDocument.Parse(text);

            return xml;
        }

        private static string ConvertXmlToJson(XDocument xml)
        {
            var xmlToJson = JsonConvert.SerializeXNode(xml);

            return xmlToJson;
        }
    }
}
