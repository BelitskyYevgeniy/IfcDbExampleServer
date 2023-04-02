namespace Services.Exceptions
{
    public class FileAlreadyExistsException : Exception
    {
        public FileAlreadyExistsException() : base("File already exists") { }
    }
}
