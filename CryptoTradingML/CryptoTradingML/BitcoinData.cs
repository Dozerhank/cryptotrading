using System;
using Microsoft.ML.Data;

namespace CryptoTradingML
{
    public class BitcoinData
    {
        [LoadColumn(0)]
        public string Time { get; set; }
    }
}