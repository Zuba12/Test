public class Upravovac
{
    private string _filePath;

    public Upravovac(string filePath)
    {
        _filePath = filePath;
    }

    public async Task FormatTextAsync()
    {
        if (!File.Exists(_filePath))
            throw new FileNotFoundException("The specified file does not exist.");

        string content = await File.ReadAllTextAsync(_filePath);

        string[] words = content.Split(';');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Trim(); 
            if (words[i].Length > 0)
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
        }

        string formattedContent = string.Join(Environment.NewLine, words);

        await File.WriteAllTextAsync(_filePath, formattedContent);
    }
}






