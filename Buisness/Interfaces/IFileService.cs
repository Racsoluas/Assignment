namespace Buisness.Interfaces;


//Spara fil
public interface IFileService
{
    bool SaveContentToFile(string content);
    
    string GetContentFromFile();
}