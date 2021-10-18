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
        //Create a field to hold the data path
        static readonly string dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "BitcoinData.txt");

        static void Main(string[] args)
        {
            //Initialize mlContext variable
            MLContext mlContext = new MLContext();

            //Load data file
            TrainTestData splitDataView = LoadData(mlContext);

            //Train model
            //ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);
        }

        public static TrainTestData LoadData(MLContext mlContext)
        {
            //Define Schema and read the file
            IDataView dataView = mlContext.Data.LoadFromTextFile<BitcoinData>(dataPath, hasHeader: true);

            //Split data into training sets (80/20) 
            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            //Return training set
            return splitDataView;
        }

        /*
        public static ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
        {

        }
        */
    }
}