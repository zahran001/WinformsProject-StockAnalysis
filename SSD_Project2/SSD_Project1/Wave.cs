using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD_Project1
{
    /// <summary>
	/// Implement the Wave class
	/// </summary>
    // Represents a Wave object in the stock data, either an UP or DOWN wave
    public class Wave
    {
        public DateTime StartDate { get; set; } // The start date of the wave
        public DateTime EndDate { get; set; } // The end date of the wave
        public decimal StartPrice { get; set; } // The price at the start of the wave
        public decimal EndPrice { get; set; } // The price at the end of the wave
        public bool IsUpWave { get; set; } // Boolean indicating whether the wave is an UP wave (true) or DOWN wave (false) - True for UP wave, False for DOWN wave

        // Overrides ToString method to provide a string representation of the wave in "MM/dd/yyyy - MM/dd/yyyy" format
        public override string ToString()
        {
            return $"{StartDate:MM/dd/yyyy} - {EndDate:MM/dd/yyyy}";
        }
    }
}
