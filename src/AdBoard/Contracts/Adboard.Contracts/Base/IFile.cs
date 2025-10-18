namespace Adboard.Contracts.Base;

public interface IFile
{
    public string Name { get; set; }
    public byte[] Content { get; set; }
}