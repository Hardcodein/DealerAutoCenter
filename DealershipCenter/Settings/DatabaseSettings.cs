namespace DealershipCenter.Settings;

internal class DatabaseSettings : ISettings
{
    public string? ConntectionString { get; set; }

    public void Validate()
    {
        if(string.IsNullOrWhiteSpace(ConntectionString))
            throw new ArgumentNullException(nameof(ConntectionString));
    }
}
