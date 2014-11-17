using polymer.concepts.Computers.Storage;

namespace polymer.concepts.Computers.FileSystems
{
    public interface IFileInfo
    {
        string FileName { get; set; }
        ComputerSpace Size { get; set; }
        FileType FileType { get; set; }
 
    }
}