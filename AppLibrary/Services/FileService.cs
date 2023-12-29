

using AppLibrary.Interfaces;
using System.Diagnostics;
using System.IO;

namespace AppLibrary.Services;
public class FileService : IFileService
{
    /// <summary>
    /// Loads the content of a specified filepath 
    /// </summary>
    /// <param name="filePath">Enter the filepath with extensions(eg. c:\examcsharp\consoleapp\contacts.json</param>
    /// <returns>Returns the content of the file as text if succesfull, if falied it returns null</returns>

    public string GetContent(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
                //return File.ReadAllText(filePath);
            }
        }


        catch (Exception ex) { Debug.WriteLine("FileService - GetContent" + ex.Message); }
        return null!;
    }

    /// <summary>
    /// Saves the content to a specified file using, if file dosent exist it will create the file
    /// </summary>
    /// <param name="filePath">Enter the filepath with extensions(eg. c:\examcsharp\consoleapp\contacts.json</param>
    /// <param name="content">Enter your content as a string</param>
    /// <returns>Returns true if succesfull, otherwise returns false</returns>
    public bool SaveContent(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine("FileService - SaveContent" + ex.Message); }
        return false;
    }
}