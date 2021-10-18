using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace CryptoTradingML
{
    class BitcoinData
    {
        [LoadColumn(0)]
        public string Date { get; set; }

        [LoadColumn(1)]
        public string Time { get; set; }

        [LoadColumn(2)]
        public float prevBitcoin { get; set; }

        [LoadColumn(3)]
        public float currBitcoin { get; set; }

        [LoadColumn(4)]
        public float priceChange { get; set; }
    }
}
