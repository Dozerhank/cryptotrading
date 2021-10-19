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
            //Initialize mlContext variable
            MLContext mlContext = new MLContext(seed: 0);

            //Train model
            var model = Train(mlContext, trainDataPath);

            //Evaluate model
            Evaluate(mlContext, model);
        }

        public static ITransformer Train(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<BitcoinData>(dataPath, hasHeader: true, separatorChar: ',');
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "BitcoinTradeDecision")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "DateEncoded", inputColumnName: "Date"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "TimeEncoded", inputColumnName: "Time"))
                .Append(mlContext.Transforms.Concatenate("Features", "DateEncoded", "TimeEncoded", "prevBitcoin", "currBitcoin", "priceChange"))
                .Append(mlContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);
            return model;
        }

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<BitcoinData>(testDataPath, hasHeader: true, separatorChar: ',');
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Index", "Buy/Sell/Pass");

            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
        }

        private static void TestSinglePrediction(MLContext mlContext, ITransformer model)
        {
            TestSinglePrediction(mlContext, model);
            var predictionFunction = mlContext.Model.CreatePredictionEngine<BitcoinData, BitcoinPrediction>(model);

            var BitcoinPredictionSample = new BitcoinData()
            {
                Index = 1,
                Date = "1/1/2021",
                Time = "3:24pm",
                prevBitcoin = 40000,
                currBitcoin = 42000,
                priceChange = 2000,
            };

            var prediction = predictionFunction.Predict(BitcoinPredictionSample);

            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Predicted fare: {prediction.Decision:0.####}, actual fare: 15.5");
            Console.WriteLine($"**********************************************************************");
        }
    }
}