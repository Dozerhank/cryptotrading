using System;
using Microsoft.ML.Data;

namespace CryptoTradingML
{
    public class BitcoinData
    {
        [LoadColumn(0)]
        public string Time { get; set; }

        [LoadColumn(1)]
        public string Date { get; set; }

        [LoadColumn(2)]
        public float PrevBitcoinPrice { get; set; }

        [LoadColumn(3)]
        public float BitcoinPrice { get; set; }

        [LoadColumn(4)]
        public float PriceChange { get; set; }
    }
}