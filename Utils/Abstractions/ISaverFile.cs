namespace Utils.Abstractions;

public interface ISaverFile
{
    string? SaveFileToPath(string NameFile, string filterFile);
}