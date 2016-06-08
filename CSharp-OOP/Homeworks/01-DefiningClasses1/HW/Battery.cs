namespace HW
{
    using System;
    using System.Text;
    using Enum;

    internal class Battery
    {
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType? type;

        public Battery(BatteryType? type = null, string model = null, double? hoursIdle = null,
            double? hoursTalk = null)
        {
            Model = model;
            HoursIdle = hoursIdle;
            HoursTalk = hoursTalk;
            Type = type;
        }

        public BatteryType? Type { get; set; }
        public string Model { get; set; }

        public double? HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Standby time must be a positive number!");
                }
                hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Talk time must be a positive number!");
                }
                hoursTalk = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            if (Type != null)
            {
                output.AppendFormat("Battery Type: {0}\n", Type);
            }
            if (Model != null)
            {
                output.AppendFormat("Battery Model: {0}\n", Model);
            }
            if (HoursIdle != null)
            {
                output.AppendFormat("Battery Hours Idle: {0}\n", HoursIdle);
            }
            if (HoursTalk != null)
            {
                output.AppendFormat("Battery Hours Talk: {0}\n", HoursTalk);
            }

            return output.ToString();
        }
    }
}