
using AppLibrary.Interfaces;
using AppLibrary.Services;
using System.Reflection.Metadata.Ecma335;
namespace ExamCSharp.Test;

public class FileService_Test
{

    [Fact]

    public void SaveContentShould_SaveContentToASpecifiedFile_ThenReturnTrue()
    {
        //Arrange
        IFileService fileService = new FileService();

        string filePath = @"c:\examcsharp\consoleapp\savetest.txt"; ;
        string content = "detta är testContent";
        fileService.SaveContent(filePath, content);

        //Act

        bool result = fileService.SaveContent(filePath, content);


        //Assert

        Assert.True(result);
    }
    [Fact]
    public void GetContentShould_GetContentFromASpecifiedFile_ThenReturnContent()
    {
        IFileService fileService = new FileService();

        string filePath = @"c:\examcsharp\consoleapp\gettest.txt";
        string content = "detta är testContent";
        fileService.SaveContent(filePath, content);
        fileService.GetContent(filePath);

        //Act

        var fetchedContent = fileService.GetContent(filePath);

        //Assert

        Assert.NotNull(fetchedContent);
    }



}
