namespace NorthwindTwinDataModel.Data
{
    using System;
    using System.Linq;

    using NorthwindDataModel.Data;

    public class Program
    {
        Northwind dbContext = new Northwind();

        /*
         * Steps to reproduse the DB:
         * 1. Open NorthwindModel.edmx
         * 2. Right button click on the empty space between the tables
         * 3. Click Generate Database from model - it will generate a SQL script
         * 4. Add 
         *          CREATE DATABASE [NorthwindTwin]
         *          GO 
         * and edit the USE [Northwind]; to USE [NorthwindTwin];
         * 5. Run the script;
         */
    }
}
