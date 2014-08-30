using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private const string DB_CONNECTION_STRING = "Server=localhost; Database=Northwind; Integrated Security=true";
    private const string SOURCE_IMAGE_FILE_NAME = @"..\..\logo.gif";
    private const string DEST_IMAGE_FILE_NAME = @"..\..\pic";

    private static byte[] ReadBinaryFile(string fileName)
    {
        FileStream stream = File.OpenRead(fileName);

        using (stream)
        {
            int currentPosition = 0;
            int length = (int)stream.Length;
            byte[] resultBuffer = new byte[length];

            while (true)
            {
                int bytesRead = stream.Read(resultBuffer, currentPosition, length - currentPosition);
                if (bytesRead == 0) break;
                currentPosition += bytesRead;
            }

            return resultBuffer;
        }
    }

    private static void WriteBinaryFile(string fileName, byte[] fileContents)
    {
        FileStream stream = File.OpenWrite(fileName);

        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }

    private static string GetImageFormat(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string fileExtenstion = fileInfo.Extension;
        string imageFormat = fileExtenstion.ToLower().Substring(1);

        return imageFormat;
    }

    private static int[] ListImageIdsFromDB(SqlConnection dbConnection)
    {
        dbConnection.ConnectionString = DB_CONNECTION_STRING;
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand("Select CategoryID From Categories", dbConnection);
            ArrayList imageIds = new ArrayList();
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    int imageId = (int)reader["CategoryID"];
                    imageIds.Add(imageId);
                }
            }

            int[] imageIdArray = (int[])imageIds.ToArray(typeof(int));

            return imageIdArray;
        }
    }

    private static void ExtractImageFromDB(SqlConnection dbConnection, int imageId, out byte[] image)
    {
        dbConnection.ConnectionString = DB_CONNECTION_STRING;
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand("SELECT Picture FROM Categories " + "WHERE CategoryID = @categoryID", dbConnection);
            SqlParameter categoryID = new SqlParameter("@categoryID", SqlDbType.Int);
            categoryID.Value = imageId;
            command.Parameters.Add(categoryID);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                if (reader.Read())
                {
                    image = (byte[])reader["Picture"];
                }
                else
                {
                    throw new Exception(String.Format("Invalid image ID={0}.", imageId));
                }
            }
        }
    }

    private static void InsertImageToDB(SqlConnection dbConnection, string categoryName, byte[] image)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryName, [Picture]) " + "VALUES (@categoryName, @image)", dbConnection);

            SqlParameter paramCategoryName = new SqlParameter("@categoryName", SqlDbType.VarChar);
            paramCategoryName.Value = categoryName;
            command.Parameters.Add(paramCategoryName);

            SqlParameter paramImage = new SqlParameter("@image", SqlDbType.Image);
            paramImage.Value = image;
            command.Parameters.Add(paramImage);

            command.ExecuteNonQuery();
        }
    }

    private static void DeleteAllImagesFromDB(SqlConnection dbConnection)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Categories", dbConnection);
            command.ExecuteScalar();
        }
    }

    public static void Main()
    {
        SqlConnection northWindDB = new SqlConnection(DB_CONNECTION_STRING);

        int[] imageIds = ListImageIdsFromDB(northWindDB);
        Console.WriteLine("There are {0} images in the DB.", imageIds.Length);

        for (int i = 0; i < imageIds.Length; i++)
        {
            int currentImageId = imageIds[i];
            byte[] imageFromDB;
            ExtractImageFromDB(northWindDB, currentImageId, out imageFromDB);
            Console.WriteLine("Extracted image {0} from the DB.", i);

            byte[] realImage = new byte[imageFromDB.Length - 78];
            for (int j = 0; j < realImage.Length; j++) realImage[j] = imageFromDB[j + 78];

            WriteBinaryFile(DEST_IMAGE_FILE_NAME + i + ".jpg", realImage);
            Console.WriteLine("Image saved to file {0}.", DEST_IMAGE_FILE_NAME + i + ".jpg");
        }

        /*DeleteAllImagesFromDB(northWindDB);
        Console.WriteLine("Deleted all images from the DB.");

        byte[] image = ReadBinaryFile(SOURCE_IMAGE_FILE_NAME);
        string imageFormat = GetImageFormat(SOURCE_IMAGE_FILE_NAME);
        Console.WriteLine("Loaded image file {0}.", SOURCE_IMAGE_FILE_NAME);

        string categoryName = "Food";
        InsertImageToDB(northWindDB, categoryName, image);
        Console.WriteLine("Inserted an image in the DB.");*/
    }
}