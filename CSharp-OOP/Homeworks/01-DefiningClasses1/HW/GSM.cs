namespace HW
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using Enum;
    using Calls;

    //Problem 1
    internal class Gsm
    {
        //Problem 6 - Static Field & Property
        public static Gsm Iphone4S { get; } = new Gsm("Apple", "IPhone 4S", BatteryType.LiIon, 600, "Steve",
            "SKU1865", 7.3, 1.256, 7.45, 16000000);

        //Fields
        private string manufacturer;
        private string owner;
        private double? price;
        private string model;

        //Problem 2 - Constructors
        public Gsm(string manufacturer, string model, BatteryType? type = null, double? price = null,
            string owner = null,
            string batteryModel = null, double? hoursIdle = null, double? hoursTalk = null,
            double? displaySize = null, int? displayColors = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery(type, batteryModel, hoursIdle, hoursTalk);
            this.Display = new Display(displaySize, displayColors);
            this.CallHistory = new List<Call>();
        }

        public Gsm(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Battery = new Battery();
            this.Display = new Display();
            this.CallHistory = new List<Call>();
        }

        //Problem 5 - Properties
        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GSM Model is mandatory!");
                }
                model = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GSM Manufacturer is mandatory!");
                }
                manufacturer = value;
            }
        }

        public double? Price
        {
            get { return price; }
            set
            {
                if (value > 0 || value == null)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Price must be positive!");
                }
            }
        }

        public string Owner
        {
            get { return owner; }
            set
            {
                if (value.Length > 2)
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException("Owner name must be at least two characters!");
                }
            }
        }

        public Display Display { get; set; }

        public Battery Battery { get; set; }

        //Problem 9 - Call History
        public List<Call> CallHistory { get; }

        //Problem 4 - ToString() overriding
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("Model: {0}\n", Model);
            output.AppendFormat("Brand: {0}\n", Manufacturer);

            if (Price != null)
            {
                output.AppendFormat("Price: {0:F2}\n", Price);
            }
            if (Owner != null)
            {
                output.AppendFormat("Owner: {0}\n", Owner);
            }

            output.AppendFormat(Battery.ToString());
            output.AppendFormat(Display.ToString());
            return output.ToString();
        }

        //Problem 10 - Add/Delete
        public void AddCall(string dateTime, int duration, string dialedNumber)
        {
            var date = DateTime.Parse(dateTime);
            CallHistory.Add(new Call(duration, date, dialedNumber));
        }

        public void DeleteCall(Call call)
        {
            CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        //Problem 11 - Call Price
        public double GetTotalPriceOfCalls(double ppm)
        {
            
            int totalDuration = CallHistory.Sum(call => call.DurationInSeconds);
            return ((double) totalDuration/60)*ppm;
            
        }
    }
}