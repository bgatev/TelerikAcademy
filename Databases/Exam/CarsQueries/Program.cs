namespace CarsQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    using CarsData;
    using CarsModel;

    public class Program
    {
        private static CarsDB db;
        private const string XMLQueriesFilePath = @"../../../Queries.xml";

        public static void Main()
        {
            db = new CarsDB();

            var catalogXml = new XmlDocument();
            catalogXml.Load(XMLQueriesFilePath);

            ExtractAllQueries(catalogXml);

        }

        private static void ExtractAllQueries(XmlDocument xmlDocument)
        {
            var queriesXml = xmlDocument.SelectNodes("/Queries/Query");

            foreach (XmlNode query in queriesXml)
            {
                var currentQueryOutputFileName = query.Attributes["OutputFileName"].Value;
                var currentQueryOrderBy = query.FirstChild.InnerText;

                var whereClauses = query.LastChild;
                List<string> currentWhereClausePropertyName = new List<string>();
                List<string> currentWhereClausePropertyType = new List<string>();
                List<string> currentWhereClauseValue = new List<string>();

                foreach (XmlNode whereClause in whereClauses)
                {
                    currentWhereClausePropertyName.Add(whereClause.Attributes["PropertyName"].Value);
                    currentWhereClausePropertyType.Add(whereClause.Attributes["Type"].Value);
                    currentWhereClauseValue.Add(whereClause.InnerText);
                }

                string summaryWhereClause = string.Empty;

                for (int i = 0; i < currentWhereClausePropertyName.Count; i++)
			    {
                    summaryWhereClause += string.Format("{0} {1} '{2}' and ",currentWhereClausePropertyName[i], currentWhereClausePropertyType[i], currentWhereClauseValue[i]);   
			    }

                summaryWhereClause = summaryWhereClause.Substring(0, summaryWhereClause.Length - 5);
                summaryWhereClause = summaryWhereClause.Replace("Equals", "=");
                summaryWhereClause = summaryWhereClause.Replace("GreaterThan", ">");
                summaryWhereClause = summaryWhereClause.Replace("LessThan", "<");
                summaryWhereClause = summaryWhereClause.Replace("Contains", "like");


                //var dbCars = db.Cars.Where(summaryWhereClause).OrderBy(currentQueryOrderBy).Select();

                HashSet<Car> allCars = new HashSet<Car>();
                SqlConnection carsDB = new SqlConnection();
                carsDB.ConnectionString = "Server=localhost; Database=CarsDB; Integrated Security=true";

                carsDB.Open();

                using (carsDB)
                {
                    SqlCommand command = new SqlCommand(string.Format("Select * From Cars Where {0} Order By {1}", summaryWhereClause, currentQueryOrderBy), carsDB);

                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            allCars.Add(new Car() 
                            {
                                ManufacturerName = (string)reader["ManufacturerName"],
                                Model = (string)reader["Model"],
                                TransmissionType = (int)reader["TransmissionType"] == 0 ? TransmissionType.automatic : TransmissionType.manual,
                                Year = (int)reader["Year"],
                                Price = (double)reader["Price"]
                            });
                        }
                    }
                }

                GenerateOutputXML(allCars, currentQueryOutputFileName);   
            }
        }

        private static void GenerateOutputXML(HashSet<Car> allCars, string fileName)
        {

            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter("../../" + fileName, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");

                foreach (var car in allCars)
                {
                    WriteBook(writer, car.ManufacturerName, car.Model, car.Year, car.Price, car.TransmissionType, car.Dealer);
                }

                writer.WriteEndDocument();
            }

            Console.WriteLine("Document {0} created.\n", fileName);
        }

        private static void WriteBook(XmlWriter writer, string manufacturerName, string model, int year, double price, TransmissionType transmissionType, Dealer dealer)
        {
            writer.WriteStartElement("Car");
            writer.WriteAttributeString("Manufacturer", manufacturerName);
            writer.WriteAttributeString("Model", model);
            writer.WriteAttributeString("Year", year.ToString());
            writer.WriteAttributeString("Price", price.ToString());
            writer.WriteElementString("TransmissionType", transmissionType.ToString());
            if (dealer != null)
            {
                writer.WriteElementString("Dealer", dealer.ToString());
                writer.WriteAttributeString("Name", dealer.Name);
                writer.WriteElementString("Cities", dealer.City);
                writer.WriteAttributeString("City", dealer.City);
            }
            writer.WriteEndElement();
        }
    }
}
