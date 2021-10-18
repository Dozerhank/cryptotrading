using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;

namespace CryptoTradingML
{
    class Program
    {
        static readonly string dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "BitcoinData.txt");

        static void Main(string[] args)
        {
            MLContext mlcontext = new MLContext();
        }
    }
}