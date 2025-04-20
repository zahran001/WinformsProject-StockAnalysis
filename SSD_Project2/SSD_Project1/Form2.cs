using SSD_Project1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SSD_Project1
{
    public partial class Form_ChartDisplay : Form
    {
        private List<Candlestick> stockData; // Stores the original stock data
        private List<Candlestick> filteredCandlesticks; // Stores the filtered stock data based on date range
        private string stockName; // Stores the stock name
        private int marginValue; // Margin value for peak/valley detection

        /// <summary>
        /// Initializes the chart display form with stock data.
        /// </summary>
        public Form_ChartDisplay(List<Candlestick> data, string name, DateTime startDate, DateTime endDate, int margin)
        {
            InitializeComponent(); // Initialize the Windows Form components

            this.marginValue = margin; // Store the margin value for peak/valley detection
            stockName = name; // Assign the stock name to the class variable
            this.Text = stockName; // Set the window title to the stock name

            // Initialize data
            stockData = data; // Store the original data
            FilterData(startDate, endDate); // Filter data based on date range
            InitializeChart(); // Initialize chart settings
            DisplayInChart(); // Populate the chart with filtered data

        }

        /// <summary>
        /// Filters stock data within the specified date range.
        /// </summary>
        private void FilterData(DateTime startDate, DateTime endDate)
        {
            // Select candlesticks within the date range and order them chronologically
            filteredCandlesticks = stockData.Where(c => c.Date >= startDate && c.Date <= endDate).OrderBy(c => c.Date).ToList();
            
            // If no data exists in the range, show an alert
            if (filteredCandlesticks.Count == 0)
            {
                MessageBox.Show($"No data available for {stockName} in the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// Initializes chart settings and configurations.
        /// </summary>
        private void InitializeChart()
        {
            // Check if the chart control exists before proceeding
            if (chart_stockData == null)
            {
                // Display an error message if the chart control is missing
                MessageBox.Show("Error: Chart control is missing!", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further errors
            }

            // Retrieve the chart areas for candlestick and volume visualization
            ChartArea candlestickArea = chart_stockData.ChartAreas["CandlestickArea"];
            ChartArea volumeArea = chart_stockData.ChartAreas["VolumeArea"];

            // Enable margins for the X-axis in the candlestick chart to improve readability
            chart_stockData.ChartAreas["CandlestickArea"].AxisX.IsMarginVisible = true;

            // Ensure the X-axis is displayed in normal order (not reversed)
            chart_stockData.ChartAreas["CandlestickArea"].AxisX.IsReversed = false;

            // Recalculate the axis scales to fit the current data range dynamically
            chart_stockData.ChartAreas["CandlestickArea"].RecalculateAxesScale();
            chart_stockData.ChartAreas["VolumeArea"].RecalculateAxesScale();
        }

        /// <summary>
        /// This method clears existing chart data, processes stock data to detect peaks, valleys, and waves, and updates the chart accordingly.
        /// It resets axis ranges, applies formatting, binds data, and adds annotations to highlight key points.
        /// </summary>
        private void DisplayInChart()
        {
            // Clear existing custom labels from both axes in the candlestick and volume areas
            chart_stockData.ChartAreas["CandlestickArea"].AxisX.CustomLabels.Clear();
            chart_stockData.ChartAreas["VolumeArea"].AxisX.CustomLabels.Clear();

            // Clear existing data and annotations from the chart
            chart_stockData.Series["Series_OHLC"].Points.Clear();
            chart_stockData.Series["Series_Volume"].Points.Clear();
            chart_stockData.Annotations.Clear();

            // Retrieve references to the candlestick and volume chart areas
            var candlestickArea = chart_stockData.ChartAreas["CandlestickArea"];
            var volumeArea = chart_stockData.ChartAreas["VolumeArea"];

            // Reset custom labels to ensure proper rendering
            candlestickArea.AxisX.CustomLabels.Clear();
            volumeArea.AxisX.CustomLabels.Clear();

            // Reset X-axis ranges to allow auto-scaling
            candlestickArea.AxisX.Minimum = double.NaN;
            candlestickArea.AxisX.Maximum = double.NaN;
            volumeArea.AxisX.Minimum = double.NaN;
            volumeArea.AxisX.Maximum = double.NaN;

            // Ensure axis labels are enabled for both chart areas
            candlestickArea.AxisX.LabelStyle.Enabled = true;
            volumeArea.AxisX.LabelStyle.Enabled = true;

            // Hide the chart legend if it exists
            if (chart_stockData.Legends.Count > 0)
            {
                chart_stockData.Legends[0].Enabled = false;
            }

            // Detect significant points such as peaks and valleys in the data
            var significantPoints = DetectPeaksAndValleys(filteredCandlesticks, marginValue);

            // Identify waves based on the detected peaks and valleys
            var waves = DetectWaves(significantPoints, filteredCandlesticks);

            // Separate detected waves into UP and DOWN categories
            var upWaves = waves.Where(w => w.IsUpWave).ToList();
            var downWaves = waves.Where(w => !w.IsUpWave).ToList();

            // Populate dropdown lists with detected waves
            comboBox_UpWaves.DataSource = upWaves;
            comboBox_DownWaves.DataSource = downWaves;

            // Retrieve predefined chart series from the Designer
            Series candlestickSeries = chart_stockData.Series["Series_OHLC"];
            Series volumeSeries = chart_stockData.Series["Series_Volume"];
            candlestickSeries.Points.Clear();
            volumeSeries.Points.Clear();

            // Configure candlestick appearance settings
            candlestickSeries["OpenCloseStyle"] = "Candlestick";
            candlestickSeries["PriceUpColor"] = "Lime";
            candlestickSeries["PriceDownColor"] = "Red";
            candlestickSeries["ShowOpenClose"] = "Both";
            candlestickSeries["PointWidth"] = "0.7";

            // Handle X-axis range
            DateTime minDate, maxDate;

            // Determine the minimum and maximum dates in the filtered data
            if (filteredCandlesticks.Any())
            {
                minDate = filteredCandlesticks.Min(c => c.Date).AddDays(-7);
                maxDate = filteredCandlesticks.Max(c => c.Date).AddDays(7);
            }
            else
            {
                // Display an error message if no data is available
                MessageBox.Show($"No data available for {stockName}. Unable to determine date range.", "Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set the X-axis range for both chart areas
            candlestickArea.AxisX.Minimum = minDate.ToOADate();
            candlestickArea.AxisX.Maximum = maxDate.ToOADate();
            volumeArea.AxisX.Minimum = minDate.ToOADate();
            volumeArea.AxisX.Maximum = maxDate.ToOADate();

            // Set automatic interval for X-axis labels
            candlestickArea.AxisX.Interval = 0;
            candlestickArea.AxisX.IntervalType = DateTimeIntervalType.Auto;
            volumeArea.AxisX.Interval = 0;
            volumeArea.AxisX.IntervalType = DateTimeIntervalType.Auto;

            // Normalize Y-axis scale based on data range
            NormalizeYAxis(candlestickArea, filteredCandlesticks);

            // Bind candlestick and volume data to chart series
            candlestickSeries.XValueMember = "Date";
            candlestickSeries.YValueMembers = "High,Low,Open,Close";
            volumeSeries.XValueMember = "Date";
            volumeSeries.YValueMembers = "Volume";

            // If there is no data, clear the chart and exit
            if (filteredCandlesticks.Count == 0)
            {
                chart_stockData.Series["Series_OHLC"].Points.Clear();
                chart_stockData.Series["Series_Volume"].Points.Clear();
                return;
            }

            // Bind the filtered candlestick data to the chart
            chart_stockData.DataSource = filteredCandlesticks;
            chart_stockData.DataBind(); // Apply Data Binding

            // Assign colors and custom X-axis labels for each data point
            for (int i = 0; i < filteredCandlesticks.Count; i++)
            {
                DataPoint dp = candlestickSeries.Points[i];
                var candle = filteredCandlesticks[i];

                // Set the color of the candlestick based on price movement
                dp.Color = (candle.Close >= candle.Open) ? Color.Lime : Color.Red;

                // Add custom labels to the X-axis for better readability
                candlestickArea.AxisX.CustomLabels.Add(new CustomLabel(
                    candle.Date.ToOADate() - 0.5,
                    candle.Date.ToOADate() + 0.5,
                    candle.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    0,
                    LabelMarkStyle.None));

                volumeArea.AxisX.CustomLabels.Add(new CustomLabel(
                    candle.Date.ToOADate() - 0.5,
                    candle.Date.ToOADate() + 0.5,
                    candle.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    0,
                    LabelMarkStyle.None));

                // Check if the current index corresponds to a significant peak or valley
                var pointInfo = significantPoints.FirstOrDefault(sp => sp.Index == i);
                if (pointInfo != default)
                {
                    if (pointInfo.IsPeak)
                    {
                        // peak annotation
                        AddPeakAnnotation(i, candle);
                    }
                    else
                    {
                        // valley annotation
                        AddValleyAnnotation(i, candle);
                    }
                }
            }

            // Refresh the chart to reflect changes
            chart_stockData.Invalidate(); // Redraw chart
        }

        /// <summary>
		/// Method to normalize the Y-axis for the candlestick chart
		/// </summary>
        private void NormalizeYAxis(ChartArea chartArea, List<Candlestick> data)
        {
            // Get the minimum and maximum values of the stock data
            decimal minValue = data.Min(c => c.Low);
            decimal maxValue = data.Max(c => c.High);

            // Add 2% to the maximum value
            decimal maxY = maxValue + (0.02m * maxValue);
            // Subtract 2% from the minimum value
            decimal minY = minValue - (0.02m * minValue);

            // Set the Y-axis minimum and maximum values
            chartArea.AxisY.Minimum = (double)minY;
            chartArea.AxisY.Maximum = (double)maxY;
        }

        /// <summary>
		/// Event handler for the "Refresh" button
		/// </summary>
        private void button_RefreshChart_Click(object sender, EventArgs e)
        {
            // Get the selected start and end date from the DateTimePickers
            DateTime startDate = dateTimePicker_modifyStartDate.Value;
            DateTime endDate = dateTimePicker_modifyEndDate.Value;

            // Update filtered candlesticks based on the new dates
            FilterData(startDate, endDate);
            InitializeChart(); // Initializes the chart - settings and configurations
            DisplayInChart(); // Re-display the chart with the filtered data
        }

        /// <summary>
        /// Detects peaks and valleys in a given list of candlestick data.
        /// A peak is defined as a point where the high price is greater than surrounding highs within the lookback period.
        /// A valley is defined as a point where the low price is lower than surrounding lows within the lookback period.
        /// <returns>List of tuples containing (Index, IsPeak) where Index is the position in the data list, and IsPeak is true for peaks, false for valleys.</returns>
        /// </summary>
        private List<(int Index, bool IsPeak)> DetectPeaksAndValleys(List<Candlestick> data, int lookbackPeriod)
        {
            // Initialize a list to store significant points (peaks and valleys)
            // Each entry is a tuple (index, isPeak)
            var significantPoints = new List<(int, bool)>();

            // Iterate through each candlestick, ensuring we have enough data before and after
            for (int i = lookbackPeriod; i < data.Count - lookbackPeriod; i++)
            {
                // Assume current candle is both peak and valley initially
                bool isPeak = true;
                bool isValley = true;

                // Check the lookbackPeriod number of candles before and after the current candle
                for (int j = 1; j <= lookbackPeriod; j++)
                {
                    // Check if current high is NOT higher than previous or next candle's high
                    // If either is true, it's not a peak
                    if (data[i].High < data[i - j].High || data[i].High < data[i + j].High)
                        isPeak = false;

                    // Check if current low is NOT lower than previous or next candle's low
                    // If either is true, it's not a valley
                    if (data[i].Low > data[i - j].Low || data[i].Low > data[i + j].Low)
                        isValley = false;
                }

                // If after all comparisons it's still a peak, add to list
                if (isPeak) significantPoints.Add((i, true));
                // If after all comparisons it's still a valley, add to list
                if (isValley) significantPoints.Add((i, false));
            }

            // Return all found peaks and valleys
            return significantPoints;
        }

        /// <summary>
        /// Adds a text annotation for a peak (represented by "P") at the specified index and candlestick.
        /// The annotation displays above the peak with the high value and date.
        /// </summary>
        private void AddPeakAnnotation(int index, Candlestick candle)
        {
            // Create a new text annotation to represent a peak
            var textAnnotation = new TextAnnotation();

            // Set the text to display for the annotation (e.g., "P" for Peak)
            textAnnotation.Text = "P";

            // Set the font style and size for the annotation
            textAnnotation.Font = new Font("Verdana", 10, FontStyle.Bold);

            // Set the color of the annotation text to red
            textAnnotation.ForeColor = Color.Red;

            // Set the X and Y axes to the corresponding chart area axes for positioning
            textAnnotation.AxisX = chart_stockData.ChartAreas["CandlestickArea"].AxisX;
            textAnnotation.AxisY = chart_stockData.ChartAreas["CandlestickArea"].AxisY;

            // Position the annotation slightly above the peak price on the Y-axis
            textAnnotation.AnchorX = candle.Date.ToOADate();
            textAnnotation.AnchorY = (double)candle.High * 1.02; // 2% above the high

            // Set a unique name for the annotation using the index
            textAnnotation.Name = $"Peak_Text_{index}";

            // Add a tooltip that displays the peak's high value and date when hovering over the annotation
            textAnnotation.ToolTip = $"PEAK\nHigh: {candle.High:C}\nDate: {candle.Date:MM/dd/yy}";

            // Add the annotation to the chart's annotation collection
            chart_stockData.Annotations.Add(textAnnotation);
        }

        /// <summary>
        /// Adds a text annotation for a valley (represented by "V") at the specified index and candlestick.
        /// The annotation displays below the valley with the low value and date.
        /// </summary>
        private void AddValleyAnnotation(int index, Candlestick candle)
        {
            // Create a new text annotation to represent a valley
            var textAnnotation = new TextAnnotation();

            // Set the text to display for the annotation (e.g., "V" for Valley)
            textAnnotation.Text = "V";

            // Set the font style and size for the annotation
            textAnnotation.Font = new Font("Verdana", 10, FontStyle.Bold);

            // Set the color of the annotation text to green
            textAnnotation.ForeColor = Color.Green;

            // Set the X and Y axes to the corresponding chart area axes for positioning
            textAnnotation.AxisX = chart_stockData.ChartAreas["CandlestickArea"].AxisX;
            textAnnotation.AxisY = chart_stockData.ChartAreas["CandlestickArea"].AxisY;

            // Position the annotation slightly below the valley price on the Y-axis
            textAnnotation.AnchorX = candle.Date.ToOADate();
            textAnnotation.AnchorY = (double)candle.Low * 0.95; // 5% below the low

            // Set a unique name for the annotation using the index
            textAnnotation.Name = $"Valley_Text_{index}";

            // Add a tooltip that displays the valley's low value and date when hovering over the annotation
            textAnnotation.ToolTip = $"VALLEY\nLow: {candle.Low:C}\nDate: {candle.Date:MM/dd/yy}";

            // Add the annotation to the chart's annotation collection
            chart_stockData.Annotations.Add(textAnnotation);
        }

        /// <summary>
        /// Detects waves from a list of peaks and valleys by alternating between peak and valley points.
        /// The method identifies the start and end points of each wave and categorizes the waves as either UP or DOWN.
        /// </summary>
        private List<Wave> DetectWaves(List<(int Index, bool IsPeak)> peaksAndValleys, List<Candlestick> data)
        {
            // Initialize an empty list to store the detected waves
            List<Wave> waves = new List<Wave>();

            // If there are fewer than two points (peaks/valleys), return an empty list as no waves can be detected
            if (peaksAndValleys.Count < 2) return waves; // Not enough points to form a wave

            // Ensure the peaks and valleys are in chronological order (sorted by their index in the data)
            peaksAndValleys = peaksAndValleys.OrderBy(pv => pv.Index).ToList(); // Ensure correct order

            // Loop through consecutive pairs of peaks and valleys
            for (int i = 0; i < peaksAndValleys.Count - 1; i++)
            {
                // Get the current point (start) and the next point (end) in the sequence
                var startPoint = peaksAndValleys[i];
                var endPoint = peaksAndValleys[i + 1];

                // A valid wave must alternate between peak and valley
                // If two peaks or two valleys are found consecutively, they do not form a wave
                // Waves alternate: Valley → Peak (UP) or Peak → Valley (DOWN)
                if (startPoint.IsPeak != endPoint.IsPeak) // Check if start and end points are different types (peak vs. valley)
                {
                    // Create a new Wave object with the detected wave information
                    waves.Add(new Wave
                    {
                        // Set the start date of the wave from the data at the start point index
                        StartDate = data[startPoint.Index].Date,

                        // Set the end date of the wave from the data at the end point index
                        EndDate = data[endPoint.Index].Date,

                        // Start price: if start is a peak, use High price; if valley, use Low price
                        StartPrice = startPoint.IsPeak ? data[startPoint.Index].High : data[startPoint.Index].Low,

                        // End price: if end is a peak, use High price; if valley, use Low price
                        EndPrice = endPoint.IsPeak ? data[endPoint.Index].High : data[endPoint.Index].Low,

                        // Determine wave direction: It's an UP wave if the start is a valley (not a peak), otherwise it's a DOWN wave
                        IsUpWave = !startPoint.IsPeak // If start is a valley, it's an UP wave
                    });
                }
                // If the consecutive points are the same type (both peaks or both valleys), skip them as they don't form a valid wave
            }

            // Return the complete list of detected waves
            return waves;
        }

        /// <summary>
        /// Draws a visual representation of a wave on the chart using annotations.
        /// It draws both a line to represent the trend and a rectangle to show the extent of the wave.
        /// </summary>
        private void DrawWave(Wave wave)
        {
            // Clear previous wave drawings from the chart
            chart_stockData.Annotations.Clear();

            // Convert start and end dates of the wave to OLE Automation Date format for chart plotting
            var startX = wave.StartDate.ToOADate();
            var endX = wave.EndDate.ToOADate();

            // Convert start and end prices of the wave to double for chart plotting
            var startY = (double)wave.StartPrice;
            var endY = (double)wave.EndPrice;

            // Create a line annotation representing the wave's trend
            var line = new LineAnnotation
            {
                // Assign the chart areas for X and Y axes
                AxisX = chart_stockData.ChartAreas["CandlestickArea"].AxisX,
                AxisY = chart_stockData.ChartAreas["CandlestickArea"].AxisY,

                // Set the starting position of the line at the start of the wave
                AnchorX = startX,
                AnchorY = startY,

                // Set the width and height of the line based on the wave's duration and price change
                Width = endX - startX,
                Height = endY - startY,

                // Set the line color to green for UP waves, red for DOWN waves
                LineColor = wave.IsUpWave ? Color.Green : Color.Red,

                // Set the width of the line
                LineWidth = 2,

                // Ensure that the line size is not relative, keeping it consistent with data scale
                IsSizeAlwaysRelative = false
            };

            // Create a rectangle annotation to visually represent the wave's extent
            var rectangle = new RectangleAnnotation
            {
                // Assign the chart areas for X and Y axes
                AxisX = chart_stockData.ChartAreas["CandlestickArea"].AxisX,
                AxisY = chart_stockData.ChartAreas["CandlestickArea"].AxisY,

                // Set the starting coordinates of the rectangle using the minimum of start and end values
                X = Math.Min(startX, endX),
                Y = Math.Min(startY, endY),

                // Set the width and height of the rectangle based on the wave's duration and price change
                Width = Math.Abs(endX - startX),
                Height = Math.Abs(endY - startY),

                // Set the rectangle's border color based on wave direction (green for UP, red for DOWN)
                LineColor = wave.IsUpWave ? Color.Green : Color.Red,

                // Set the width of the rectangle's border
                LineWidth = 1,

                // Set the rectangle's fill color to transparent
                BackColor = Color.Transparent,

                // Ensure that the rectangle size is not relative to chart size but matches data scale
                IsSizeAlwaysRelative = false
            };

            // Add the rectangle and line annotations to the chart
            chart_stockData.Annotations.Add(rectangle);
            chart_stockData.Annotations.Add(line);
        }


        /// <summary>
        /// Handles the selection change event for the combo box displaying UP waves.
        /// Draws the selected wave on the chart when an UP wave is selected.
        /// </summary>
        private void comboBox_UpWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected item is a valid Wave object
            if (comboBox_UpWaves.SelectedItem is Wave selectedWave)
            {
                // Call the method to draw the selected wave on the chart
                DrawWave(selectedWave);
            }
        }

        /// <summary>
        /// Handles the selection change event for the combo box displaying DOWN waves.
        /// Draws the selected wave on the chart when a DOWN wave is selected.
        /// </summary>
        private void comboBox_DownWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected item is a valid Wave object
            if (comboBox_DownWaves.SelectedItem is Wave selectedWave)
            {
                // Call the method to draw the selected wave on the chart
                DrawWave(selectedWave);
            }
        }
    }
}
