namespace Library
{
    public class Library : ILibrary
    {
        public int ContainsIn(string destination, string source)
        {
            int index = 0;
            int counter = 0;

            while (true)
            {
                index = destination.IndexOf(source);
                if (index == -1) break;

                destination = destination.Substring(index + source.Length);
                counter++;
            }

            return counter; 
        }
    }
}
