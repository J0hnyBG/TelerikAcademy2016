using System;

namespace _02_MVC_Essentials.Models
{
    public class ShortByteSize
    {
        public static readonly ShortByteSize MinValue = ShortByteSize.FromBits(0L);
        public static readonly ShortByteSize MaxValue = ShortByteSize.FromBits(long.MaxValue);
        public const long BitsInByte = 8;
        public const long BytesInKiloByte = 1000;
        public const long BytesInMegaByte = 1000000;
        public const long BytesInGigaByte = 1000000000;
        public const long BytesInTeraByte = 1000000000000;
        public const long BytesInPetaByte = 1000000000000000;

        public long Bits { get; private set; }

        public double Bytes { get; private set; }

        public double KiloBytes => this.Bytes / 1000.0;

        public double MegaBytes => this.Bytes / 1000000.0;

        public double GigaBytes => this.Bytes / 1000000000.0;

        public double TeraBytes => this.Bytes / 1000000000000.0;

        public double PetaBytes => this.Bytes / BytesInPetaByte;

        private ShortByteSize(double byteSize)
        {
            this.Bits = (long)Math.Ceiling(byteSize * 8.0);
            this.Bytes = byteSize;
        }

        public static ShortByteSize FromBits(long value)
        {
            return new ShortByteSize((double)value / 8.0);
        }

        public static ShortByteSize FromBytes(double value)
        {
            return new ShortByteSize(value);
        }

        public static ShortByteSize FromKiloBytes(double value)
        {
            return new ShortByteSize(value * BytesInKiloByte);
        }

        public static ShortByteSize FromMegaBytes(double value)
        {
            return new ShortByteSize(value * BytesInMegaByte);
        }

        public static ShortByteSize FromGigaBytes(double value)
        {
            return new ShortByteSize(value * BytesInGigaByte);
        }

        public static ShortByteSize FromTeraBytes(double value)
        {
            return new ShortByteSize(value * BytesInTeraByte);
        }

        public static ShortByteSize FromPetaBytes(double value)
        {
            return new ShortByteSize(value * BytesInPetaByte);
        }
    }
}