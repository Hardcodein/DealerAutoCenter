namespace Utils.Tools;

public static class FileTool
{
    public static string ReplaceInvalidCharsInFileName(string fileName, string replacement)
    {
        return string.Join(replacement,fileName.Split(Path.GetInvalidFileNameChars()));
    }
}
