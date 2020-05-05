using System;

namespace MiniProject4_Airline_Networks.Utils
{
    public class TextParser
    {
        public static string GetAircrafts(string filename = "aircrafts")
        {
            var path = @"..\..\..\airlines\" + filename + ".txt";

            // switch ()
            // {
            //     
            // }
            
            
            try
            {
                return System.IO.File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
            
        }
    }
}