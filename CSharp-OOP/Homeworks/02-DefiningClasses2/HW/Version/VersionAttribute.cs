namespace HW.Version
{   //Problem 11
    using System;
    using System.Linq;
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum| AttributeTargets.Interface| AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        public int MajorVersion { get; private set; }
        public int MinorVersion { get; private set; }

        public VersionAttribute(int majorVersion, int minorVersion)
        {
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
        }
        public VersionAttribute()
        {
            MajorVersion = 1;
            MinorVersion = 0;
        }
        public VersionAttribute(string version)
        {
            var ver =
                version.Split(new char[] {' ', '.', ',', ';',':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            if (ver.Length != 2)
            {
                throw new ArgumentException("The version string must be in the format \"MajorVersion.MinorVersion\"");
            }
            MajorVersion = ver[0];
            MinorVersion = ver[1];
        }

        public override string ToString()
        {
            return $"{this.MajorVersion}.{this.MinorVersion}";
        }
    }
}
