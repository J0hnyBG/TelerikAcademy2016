namespace Events
{
    internal static class Messages
    {
        public static void EventAdded()
        {
            Program.Output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Program.Output.AppendFormat("{0} Events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Program.Output.Append("No Events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Program.Output.Append(eventToPrint + "\n");
            }
        }
    }
}
