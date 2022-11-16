using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Globalization;

namespace ViewModelsViews.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Comma => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private readonly IErrorHandler? errorHandler;

        private Calculations model = new Calculations();
        private string displayIn = "0";
        private string lastOperation = "";
        

        public string DisplayIn
        {
            get => displayIn;
            set
            {
                displayIn = value;
                CommaPress.RaiseCanExecuteChanged();
                OnPropertyChanged("DisplayIn");
            }
        }

        private string displayOut = "";

        public string DisplayOut
        {
            get => displayOut;
            set
            {
                displayOut = value;
                OnPropertyChanged("displayOut");
                Result.RaiseCanExecuteChanged();
            }
        }

        public Command<string> DigitPress { get; }
        public Command<string> CommandPress { get; }
        public Command SymbolChange { get; }
        public Command CommaPress { get; }
        public Command Delete { get; }
        public Command Clear { get; }
        public Command Result { get; }

        public MainViewModel(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
            DigitPress = new Command<string>(digitPress);
            CommandPress = new Command<string>(commandPress);
            SymbolChange = new Command(symbolChange);
            CommaPress = new Command(commaPress, () => !DisplayIn.Contains(Comma));
            Delete = new Command(delete);
            Clear = new Command(clear);
            Result = new Command(result, () => !DisplayOut.Contains("="), errorHandler);
        }

        private void commandPress(string param)
        {
            if (displayOut.Contains("="))
            {
                DisplayOut = "";
            }
            
            if (lastOperation == "")
            {
                DisplayOut = $"{DisplayIn} {param}";
                
                DisplayIn = "0";
            }

            else
            {
                DisplayOut = DisplayOut.Remove(DisplayOut.Length - 1) + param;
            }
            lastOperation = param;
            model.Operation = param;
        }
        private void result()
        {
            model.Calulate();
            DisplayOut += $" {DisplayIn} = {model.Result}";
            DisplayIn = model.Result;
            lastOperation = "";
            model = new Calculations() { FirstOperand = displayIn };
        }

        private void digitPress(string param)
        {
            if (DisplayIn == "0")
            {
                DisplayIn = param;
            }
            else if (DisplayIn == "-0")
            {
                DisplayIn = $"-{param}";
            }
            else
            {
                DisplayIn += param;
            }
            if (string.IsNullOrEmpty(lastOperation))
            {
                model.FirstOperand = DisplayIn;
            }
            else
            {
                model.SecondOperand = DisplayIn;
            }
        }

        private void commaPress()
        {
            DisplayIn += Comma;
        }
        private void delete()
        {
            if (DisplayIn == "0" || DisplayIn == "-0" || DisplayIn.Length == 1)
            {
                DisplayIn = "0";
                return;
            }

            DisplayIn = DisplayIn.Remove(DisplayIn.Length-1);
        }
        private void clear()
        {
            DisplayIn = "0";
            lastOperation = DisplayOut = "";
            model = new Calculations();
        }

        private void symbolChange()
        {
            if (DisplayIn.StartsWith('-'))
            {
                DisplayIn = DisplayIn.Remove(0, 1);
            }
            else
            {
                DisplayIn = DisplayIn.Insert(0, "-");
            }
        }
    }
}
