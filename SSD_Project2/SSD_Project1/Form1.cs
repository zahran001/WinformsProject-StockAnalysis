using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SSD_Project1
{
	public partial class Form_Start : Form
	{
		// List to store all candlestick data loaded from the CSV file
		private List<Candlestick> candlesticks = new List<Candlestick>();
		// List to store candlestick data filtered by the selected date range
		private List<Candlestick> filteredCandlesticks = new List<Candlestick>();

		public Form_Start()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Event handler for the "Load Data" button click
        /// Opens a file dialog for selecting multiple CSV files and loads the stock data from those files
        /// </summary>
        private void button_loadData_Click(object sender, EventArgs e)
		{
            // Set file dialog filters to only allow CSV files
            openFileDialog_stockData.Filter = "CSV Files (*.csv)|*.csv"; // Ensure only CSV files are selected
			openFileDialog_stockData.Title = "Select Stock Data CSV Files"; // Set the title of the file dialog
            openFileDialog_stockData.Multiselect = true; // Ensure multiple files can be selected

            // Show the file dialog and check if the user selects files
            if (openFileDialog_stockData.ShowDialog() == DialogResult.OK)
            {
                // Load stock data for each selected file
                LoadMultipleStocks(openFileDialog_stockData.FileNames);
            }
        }

        /// <summary>
        /// Loads stock data from multiple CSV files, filters by date, and displays the data in a new chart form
        /// </summary>
        private void LoadMultipleStocks(string[] filePaths)
        {
            // Retrieve selected start and end dates, and margin value
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            int margin = hScrollBar_Start.Value;

            // Iterate over each file path to load stock data
            foreach (string filePath in filePaths)
            {
                try
                {
                    // Read stock data from the file
                    List<Candlestick> stockData = StockReader.ReadStockData(filePath);
                    // Extract the stock name from the file path
                    string stockName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                    // Handle the case where the stock data is null
                    if (stockData == null)
                    {
                        MessageBox.Show($"Error: Stock data is null for {filePath}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Handle the case where no data was read from the file
                    if (stockData.Count == 0)
                    {
                        MessageBox.Show($"No data was read from {filePath}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // If valid stock data is found, open a new chart form for the stock
                    if (stockData.Count > 0)
                    {
                        // Open a new chart form for each stock
                        Form_ChartDisplay chartForm = new Form_ChartDisplay(stockData, stockName, startDate, endDate, margin);
                        chartForm.Show();
                    }
                    else
                    {
                        // If no valid data was found for the stock, show a warning
                        MessageBox.Show($"No valid data found in {stockName}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors during the loading of stock data
                    MessageBox.Show($"Error loading {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Event handler for the "Scroll" event of the horizontal scrollbar.
        /// Updates the tooltip to show the current margin value.
        /// </summary>
        private void hScrollBar_Start_Scroll(object sender, ScrollEventArgs e)
        {
            // Set the tooltip to show the current margin value
            toolTip_marginStart.SetToolTip(hScrollBar_Start, $"Margin: {hScrollBar_Start.Value}");
        }
    }
}

// LINQ: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/write-linq-queries