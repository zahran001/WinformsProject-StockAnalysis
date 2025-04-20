using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD_Project1
{
	/// <summary>
	/// Implement the Candlestick class
	/// </summary>
	public class Candlestick
	{
		// Properties to store candlestick data (OHLC and volume)
		public DateTime Date { get; set; }		// Stores the date of the candlestick
		public decimal Open { get; set; }		// Stores the opening price
		public decimal High { get; set; }		// Stores the highest price
		public decimal Low { get; set; }		// Stores the lowest price
		public decimal Close { get; set; }		// Stores the closing price
		public decimal Volume { get; set; }		// Stores the trading volume

		// Constructor to initialize a Candlestick object with values
		public Candlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, decimal volume)
		{
			Date = date;		// Assigns the provided date to the Date property
			Open = open;		// Assigns the provided open price
			High = high;		// Assigns the provided high price
			Low = low;			// Assigns the provided low price
			Close = close;		// Assigns the provided close price
			Volume = volume;	// Assigns the provided trading volume
		}
	}
}

