using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

class Problem3Cooking
{
    static double GalsToMls(double gals)
    {
        return gals * 3840;
    }

    static double LsToMls(double ls)
    {
        return ls * 1000;
    }

    static double QtsToMls(double qts)
    {
        return qts * 960;
    }

    static double PtsToMls(double pts)
    {
        return pts * 480;
    }

    static double CupsToMls(double cups)
    {
        return cups * 240;
    }

    static double FlOzsToMls(double flOzs)
    {
        return flOzs * 30;
    }

    static double TbspsToMls(double tbsps)
    {
        return tbsps * 15;
    }

    static double TspsToMls(double tsps)
    {
        return tsps * 5;
    }

    static double ConvertToMls(double quantity, string measureUnit)
    {
        string[] gals = new string[2] { "gallons", "gals" };
        string[] ls = new string[2] { "liters", "ls" };
        string[] qts = new string[2] { "quarts", "qts" };
        string[] pts = new string[2] { "pints", "pts" };
        string cups = "cups";
        string[] flOzs = new string[2] { "fluid ounces", "fl ozs" };
        string[] tbsps = new string[2] { "tablespoons", "tbsps" };
        string[] tsps = new string[2] { "teaspoons", "tsps" };
        string[] mls = new string[2] { "milliliters", "mls" };
        
        double result = 0;

        if (measureUnit.ToLower() == gals[0] || measureUnit.ToLower() == gals[1]) result = GalsToMls(quantity);
        else if (measureUnit.ToLower() == ls[0] || measureUnit.ToLower() == ls[1]) result = LsToMls(quantity);
        else if (measureUnit.ToLower() == qts[0] || measureUnit.ToLower() == qts[1]) result = QtsToMls(quantity);
        else if (measureUnit.ToLower() == pts[0] || measureUnit.ToLower() == pts[1]) result = PtsToMls(quantity);
        else if (measureUnit.ToLower() == cups) result = CupsToMls(quantity);
        else if (measureUnit.ToLower() == flOzs[0] || measureUnit.ToLower() == flOzs[1]) result = FlOzsToMls(quantity);
        else if (measureUnit.ToLower() == tbsps[0] || measureUnit.ToLower() == tbsps[1]) result = TbspsToMls(quantity);
        else if (measureUnit.ToLower() == tsps[0] || measureUnit.ToLower() == tsps[1]) result = TspsToMls(quantity);
        else result = quantity;

        return result;
    }

    static double MlsToGals(double mls)
    {
        return mls / 3840;
    }

    static double MlsToLs(double mls)
    {
        return mls / 1000;
    }

    static double MlsToQts(double mls)
    {
        return mls / 960;
    }

    static double MlsToPts(double mls)
    {
        return mls / 480;
    }

    static double MlsToCups(double mls)
    {
        return mls / 240;
    }

    static double MlsToFlOzs(double mls)
    {
        return mls / 30;
    }

    static double MlsToTbsps(double mls)
    {
        return mls / 15;
    }

    static double MlsToTsps(double mls)
    {
        return mls / 5;
    }

    static double ConvertFromMls(double quantity, string ToMeasureUnit)
    {
        string[] gals = new string[2] { "gallons", "gals" };
        string[] ls = new string[2] { "liters", "ls" };
        string[] qts = new string[2] { "quarts", "qts" };
        string[] pts = new string[2] { "pints", "pts" };
        string cups = "cups";
        string[] flOzs = new string[2] { "fluid ounces", "fl ozs" };
        string[] tbsps = new string[2] { "tablespoons", "tbsps" };
        string[] tsps = new string[2] { "teaspoons", "tsps" };
        string[] mls = new string[2] { "milliliters", "mls" };

        double result = 0;

        if (ToMeasureUnit.ToLower() == gals[0] || ToMeasureUnit.ToLower() == gals[1]) result = MlsToGals(quantity);
        else if (ToMeasureUnit.ToLower() == ls[0] || ToMeasureUnit.ToLower() == ls[1]) result = MlsToLs(quantity);
        else if (ToMeasureUnit.ToLower() == qts[0] || ToMeasureUnit.ToLower() == qts[1]) result = MlsToQts(quantity);
        else if (ToMeasureUnit.ToLower() == pts[0] || ToMeasureUnit.ToLower() == pts[1]) result = MlsToPts(quantity);
        else if (ToMeasureUnit.ToLower() == cups) result = MlsToCups(quantity);
        else if (ToMeasureUnit.ToLower() == flOzs[0] || ToMeasureUnit.ToLower() == flOzs[1]) result = MlsToFlOzs(quantity);
        else if (ToMeasureUnit.ToLower() == tbsps[0] || ToMeasureUnit.ToLower() == tbsps[1]) result = MlsToTbsps(quantity);
        else if (ToMeasureUnit.ToLower() == tsps[0] || ToMeasureUnit.ToLower() == tsps[1]) result = MlsToTsps(quantity);
        else result = quantity;

        return result;
    }

    static int FindKey(Dictionary<string, string> dict, string currentKey)
    {
       int counter = 0;

        foreach (var item in dict)
        {
            if (item.Key.ToLower() == currentKey.ToLower()) return counter;
            counter++;
        }

        return -1;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        
        int N = int.Parse(Console.ReadLine());
        
        Dictionary<string, string> productAndMeasureUnit = new Dictionary<string, string>();
        List<double> quantity = new List<double>();
       
        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            string[] recipe = line.Split(':');
            double value;

            int currentIndex = FindKey(productAndMeasureUnit, recipe[2]);
            
            if (currentIndex == -1)
            {
                productAndMeasureUnit.Add(recipe[2], recipe[1]);
                value = ConvertToMls(double.Parse(recipe[0]), recipe[1]);
                quantity.Add(value);
            }
            else
            {
                value = quantity.ElementAt(currentIndex) + ConvertToMls(double.Parse(recipe[0]), recipe[1]);
                quantity[currentIndex] = value;
                //quantity.RemoveAt(currentIndex);
                //quantity.Insert(currentIndex, value);
            }
        }

        int M = int.Parse(Console.ReadLine());

        for (int i = 0; i < M; i++)
        {
            string line = Console.ReadLine();
            string[] recipe = line.Split(':');
            double value;

            int currentIndex = FindKey(productAndMeasureUnit, recipe[2]);

            if (currentIndex >= 0)
            {
                value = quantity.ElementAt(currentIndex) - ConvertToMls(double.Parse(recipe[0]), recipe[1]);
                quantity[currentIndex] = value;
                //quantity.RemoveAt(currentIndex);
                //quantity.Insert(currentIndex, value);
            }
            
        }

        int index = 0;
        foreach (var ingredient in productAndMeasureUnit)
        {
            double currentQuantity = ConvertFromMls(quantity[index], ingredient.Value);

            if (currentQuantity > 0) Console.WriteLine("{0:F}:{1}:{2}", currentQuantity, ingredient.Value, ingredient.Key);
            index++;
        }
       
    }
}

