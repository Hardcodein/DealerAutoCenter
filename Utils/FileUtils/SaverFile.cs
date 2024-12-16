using Utils.Abstractions;

namespace Utils.FileUtils;
public class SaverFile : ISaverFile
{
    public string? SaveFileToPath(string NameFile,string filterFile)
    {
        var windowForSaveFIle = new VistaSaveFileDialog
        {
            FileName = NameFile,
            Filter = filterFile,
        };
        windowForSaveFIle.ShowDialog();

        return windowForSaveFIle.FileName;        
    }
}
