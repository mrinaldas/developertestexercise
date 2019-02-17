namespace FileAttributeChecker
{
    public interface IFileAttributeRequestParser
    {
        FileAttribute ParseFileAttributeRequest(string functionality);
    }
}