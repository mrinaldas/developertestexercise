namespace FileAttributeChecker
{
    public interface IFileAttributeRequestHandler
    {
        string GetFileAttribute(string attributeRequest, string filePath);
    }
}