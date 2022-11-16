using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class Calculation
    {
        public Guid Id { get; set; }
        public string Result { get; set; } = null!;
        public string FirstOperand { get; set; } = null!;
        public string? SecondOperand { get; set; }
        public string Operation { get; set; } = null!;

        public static bool ContextEqual(Calculation left, Calculation right)
        {
            if (left == null || right == null) return false;
            return left.Result == right.Result && left.Operation == right.Operation && left.FirstOperand == right.FirstOperand;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(SecondOperand))
                return $"{Operation}({FirstOperand}) = {Result}";
            return $"{FirstOperand} {Operation} {SecondOperand} = {Result}";
        }
    }
}
