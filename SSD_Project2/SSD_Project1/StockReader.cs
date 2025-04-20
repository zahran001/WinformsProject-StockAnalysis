using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace SSD_Project1
{
	internal class StockReader
	{
		/// <summary>
		/// Reads a stock data CSV file and converts it into a list of Candlestick objects.
		/// </summary>
		public static List<Candlestick> ReadStockData(string filePath)
		{
			List<Candlestick> candlesticks = new List<Candlestick>(); // Initializes a list to store candlestick data

			try
			{
				// Open the CSV file for reading
				using (StreamReader reader = new StreamReader(filePath))
				{
					string line; // Stores each line read from the CSV file
					bool isHeader = true; // Flag to skip the header row

					// Read each line until the end of the file
					while ((line = reader.ReadLine()) != null)
					{
						// Skip the first line since it contains headers
						if (isHeader)
						{
							isHeader = false; // Set flag to false after skipping the header
							continue; // Move to the next line
						}

						// Split CSV row into parts while handling double quotes
						string[] parts = line.Split(',');

						if (parts.Length == 6) // Ensuring correct column count
						{
							try
							{
								// Trim double quotes and parse data into appropriate types
								DateTime date = DateTime.ParseExact(parts[0].Trim('"'), "yyyy-MM-dd", CultureInfo.InvariantCulture);
								decimal open = decimal.Parse(parts[1].Trim('"'), CultureInfo.InvariantCulture);
								decimal high = decimal.Parse(parts[2].Trim('"'), CultureInfo.InvariantCulture);
								decimal low = decimal.Parse(parts[3].Trim('"'), CultureInfo.InvariantCulture);
								decimal close = decimal.Parse(parts[4].Trim('"'), CultureInfo.InvariantCulture);
								decimal volume = decimal.Parse(parts[5].Trim('"'), CultureInfo.InvariantCulture);

								// Create a new Candlestick object and add it to the list
								candlesticks.Add(new Candlestick(date, open, high, low, close, volume));
							}
							catch (FormatException ex)
							{
								// Handle errors if a row has invalid formatting
								Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
							}
						}
					}
				}
			}
			catch (IOException ex)
			{
				// Handle errors if the file cannot be read (e.g., missing file or permission issues)
				Console.WriteLine($"Error reading file: {filePath}. Exception: {ex.Message}");
			}

			return candlesticks; // Return the list of parsed candlestick data
		}
	}
}
