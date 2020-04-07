using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Scriban_test;


namespace Scriban_test
{
    public class ProductController
    {

        public static void WriteProducts(string message)
        {
            TextWriter textWrite = new StreamWriter(@"..\netcoreapp3.1\products.txt");
            textWrite.Write(message);
            textWrite.Flush();
            textWrite.Close();
            textWrite = null;

        }


    }
}
