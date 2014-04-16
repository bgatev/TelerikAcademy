using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public sealed class IndexTables
    {
        private static readonly Dictionary<Tuple<string, string, string>, int> indexTable  = new Dictionary<Tuple<string, string, string>, int>();
        private static readonly Dictionary<Tuple<string, string, string>, int> indexTableGPRS = new Dictionary<Tuple<string,string,string>,int>();
        private IndexTables() { }
        
        public static Dictionary<Tuple<string, string, string>, int> IndexTable
        {
            get
            {
                return indexTable;
            }
        }

        public static Dictionary<Tuple<string, string, string>, int> IndexTableGPRS
        {
            get
            {
                return indexTableGPRS;
            }
        }
    }

    public abstract class RatingItems// : IRateable
    {
        private const string defaultIndex = "1000";
        //private Dictionary<Tuple<string, string, string>, int> indexTable;
        //private Dictionary<Tuple<string, string, string>, int> indexTableGPRS;

        /*public RatingItems(bool firstTimeInit = false, bool firstTimeInitGPRS = false)
        {
            if (firstTimeInit) CreateIndexTable();
            else if (firstTimeInitGPRS) CreateIndexTable(true);
        }*/

        protected static void CreateIndexTable(bool initGPRS = false)
        {
            Dictionary<Tuple<string, string, string>, int> indexTableCommon;
            var allTypeZones = Enum.GetNames(typeof(DestZone));

            int i = 0, j = 0, k = 0;

            if (initGPRS)
            {
                //indexTableGPRS = new Dictionary<Tuple<string, string, string>, int>();
                //indexTableCommon = indexTableGPRS;
                indexTableCommon = IndexTables.IndexTableGPRS;
                allTypeZones = Enum.GetNames(typeof(GPRSZone));
            }
            else
            {
                //indexTable = new Dictionary<Tuple<string, string, string>, int>();
                //indexTableCommon = indexTable;
                indexTableCommon = IndexTables.IndexTable;
            }

            foreach (var typeZone in allTypeZones)
            {
                i++;
                foreach (var loc in Enum.GetNames(typeof(LocZone)))
                {
                    j++;
                    foreach (var time in Enum.GetNames(typeof(TimeZone)))
                    {
                        k++; 
                        indexTableCommon.Add(new Tuple<string, string, string>(typeZone, loc, time), i * 1000 + j * 100 + k);    
                    }
                    k = 0;        
                }
                j = 0;
            }
        }

        public virtual string Index(params object[] searchKey)
        {
            //Dictionary<Tuple<string, string, string>, int> indexTableCommon = indexTable;
            Dictionary<Tuple<string, string, string>, int> indexTableCommon = IndexTables.IndexTable;
            string ratingIndex = defaultIndex;
            
            string currentTypeZone = searchKey[0] as string;
            var allTypeZones = Enum.GetNames(typeof(DestZone));

            string currentLoc = searchKey[1] as string;
            string currentTime = searchKey[2] as string;

            int gprsTypeFound = Array.IndexOf(Enum.GetNames(typeof(GPRSZone)).ToArray(), currentTypeZone);

            if (gprsTypeFound != -1)
            {
                allTypeZones = Enum.GetNames(typeof(GPRSZone));
                //indexTableCommon = indexTableGPRS;
                indexTableCommon = IndexTables.IndexTableGPRS;
            }

            foreach (var typeZone in allTypeZones)
            {
                foreach (var loc in Enum.GetNames(typeof(LocZone)))
                {
                    foreach (var time in Enum.GetNames(typeof(TimeZone)))
                    {
                        if (indexTableCommon.ContainsKey(new Tuple<string, string, string>(currentTypeZone, currentLoc, currentTime)))
                        {
                            ratingIndex = indexTableCommon[new Tuple<string, string, string>(currentTypeZone, currentLoc, currentTime)].ToString();
                            return ratingIndex;
                        }
                    }
                }
            }

            return ratingIndex;
        }

        public static void PrintTable(bool printGPRS = false)
        {
            if (printGPRS)
            {
                foreach (var item in IndexTables.IndexTableGPRS)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                foreach (var item in IndexTables.IndexTable)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
