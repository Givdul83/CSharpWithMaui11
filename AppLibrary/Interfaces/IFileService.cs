

namespace AppLibrary.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Saves your content to a specified file
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    bool SaveContent(string filePath, string content);

    /// <summary>
    /// gets content from a specified file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    string GetContent(string filePath);
}
