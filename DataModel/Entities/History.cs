using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public DateTime ActualTime { get; set; } = DateTime.Now;
        public bool IsGuest { get; set; } = true;
        public Guid CalculationId { get; set; }
        public Calculation Calculation { get; set; } = null!;

        public override string ToString()
        {
            return Calculation.ToString();
        }
    }
}
