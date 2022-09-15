using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Calulations
    {
        public string Result { get; private set; } = string.Empty;
        public string FirstOperand { get; set; } = string.Empty;
        public string SecondOperand { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;

        public Calulations()
        {

        }

        public Calulations(string firstOperand, string secondOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperand(secondOperand);
            ValidateOperation(operation);
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
        }

        public void Calulate()
        {
            ValidateOperand(FirstOperand);
            ValidateOperand(SecondOperand);
            ValidateOperation(Operation);

            try
            {
                switch (Operation)
                {
                    case ("+"):
                        Result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case ("-"):
                        Result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case ("*"):
                        Result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case ("/"):
                        Result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                        break;
                }
            }
            catch
            {
                Result = "Unknown error";
                throw;
            }
        }

        private void ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch
            {
                Result = "Operand error";
                throw;
            }
        }

        private void ValidateOperation(string operation)
        {
            switch (operation) {
                case ("+"):
                case ("-"):
                case ("*"):
                case ("/"):
                    break;
                default:
                    Result = "Operation error";
                    throw new ArgumentException();
            }
        }
    }
}
