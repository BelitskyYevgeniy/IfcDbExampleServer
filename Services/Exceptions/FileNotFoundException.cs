namespace Services.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException() : base("File not found") { }
    }
}
