﻿namespace AnimalHierarchy.Models
{
    using System;

    internal class TomCat : Cat
    {
        private char sex;

        public override char Sex
        {
            get { return sex; }
            set
            {
                if ( value != 'M' && value != 'm' )
                {
                    throw new ArgumentException("Tomcats must be male!!");
                }
                sex = value;
            }
        }

        public TomCat(int age, string name, char sex) : base(age, name, sex)
        {
            this.Sex = sex;
        }
    }
}
