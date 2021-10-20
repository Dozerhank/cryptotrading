using System;
using System.IO;
using Microsoft.ML;

namespace CryptoTradingML
{
    class Program
    {
        //Create a field to hold the data paths and trained model
        static readonly string trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "BitcoinTrain.csv");
        static readonly string testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "BitcoinTest.csv");
        static readonly string modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        static void Main(string[] args)
        {
            /*** Machine Learning Setup ***/
            /*
            //Create ML model instance
            BitcoinMLAlgorithm mlModel = new BitcoinMLAlgorithm();
            //Initialize mlContext variable
            MLContext mlContext = new MLContext(seed: 0);
            //Train model
            var model = BitcoinMLAlgorithm.Train(mlContext, trainDataPath);
            //Evaluate model
            BitcoinMLAlgorithm.Evaluate(mlContext, model);
            */

            /*** Bitcoin Price ***/
        }
    }
}