using System;
using Microsoft.ML.Data;

namespace CryptoTradingML
{
    public class BitcoinData
    {
        [LoadColumn(0)]
        public int Index { get; set; }

        [LoadColumn(1)]
        public string Date { get; set; }

        [LoadColumn(2)]
        public string Time { get; set; }

        [LoadColumn(3)]
        public float prevBitcoin { get; set; }

        [LoadColumn(4)]
        public float currBitcoin { get; set; }

        [LoadColumn(5)]
        public float priceChange { get; set; }
    }

    public class BitcoinPrediction
    {
        [ColumnName("Index")]
        public int IndexPre { get; set; }

        [ColumnName("Buy/Sell/Pass")]
        public string Decision { get; set; }
    }

    class BitcoinDataPrep
    {
        string testDataFile { get; set; }
        string newDataFile { get; set; }

        public void prepareData()
        {

        }

        public void addData(string d)
        {

        }

        public string getData(int column, int row)
        {
            string result = "";

            return result;
        }

        public float bitcoinPrice()
        {
            float result = 0.0f;
            return result;
        }
    }
}
