using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using Tweetinvi;

namespace _03_Twitter
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Auth.SetUserCredentials("LSYJiufch2jd12Cwazj0JwCXg",
                                    "4w0sO11ElVk4WK91431dWgkEccgBHnB1X01Nc4gbeh6xBSGh17",
                                    "56670536-7OM1UZ57Qj4eVU84owBoWjqNkuMZZ1aE2xqOEmkbX",
                                    "iloLWZvJRQ6mZR4kbqhuBlhPRbiMiL6TzEyzeuhLFaI0R");
        }
    }
}
