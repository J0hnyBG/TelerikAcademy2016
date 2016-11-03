namespace Memento.Documents
{
    using System.Collections.Generic;

    public class DocumentHistory
    {
        public DocumentHistory()
        {
            this.History = new Stack<Document>();
        }

        public Stack<Document> History { get; set; }
    }
}
