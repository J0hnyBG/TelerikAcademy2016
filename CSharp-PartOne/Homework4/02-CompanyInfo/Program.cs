using System;

namespace _02_CompanyInfo
{
    class Program
    {
        static void Main()
        {
            //Company name
            //Company address
            //Phone number
            //Fax number
            //Web site
            //Manager first name
            //Manager last name
            //Manager age
            //Manager phone

            string companyName = Console.ReadLine();
            string companyAddress = Console.ReadLine();
            string phoneNumber = Console.ReadLine();
            string faxNumber = Console.ReadLine();
            string website = Console.ReadLine();
            string manFirstName = Console.ReadLine();
            string manLastName = Console.ReadLine();
            string manAge = Console.ReadLine();
            string manPhone = Console.ReadLine();

            Console.WriteLine(companyName);
            Console.WriteLine("Address: " + companyAddress);
            Console.WriteLine("Tel. " + phoneNumber);
            if (faxNumber.Length > 0)
            {
                Console.WriteLine("Fax: " + faxNumber);
            }
            else
            {
                Console.WriteLine("Fax: (no fax)");
            }


            Console.WriteLine("Web site: " + website);
            Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", manFirstName, manLastName, manAge, manPhone);

        }
    }
}
