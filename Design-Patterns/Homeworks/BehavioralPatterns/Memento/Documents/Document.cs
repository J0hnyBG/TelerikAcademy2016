namespace Memento.Documents
{
    public class Document
    {
        private string content;

        public Document(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get { return this.content; }

            set { this.content = value; }
        }

        public Document GetState()
        {
            return new Document(this.Content);
        }

        public void Undo(Document document)
        {
            this.Content = document.Content;
        }
    }
}
