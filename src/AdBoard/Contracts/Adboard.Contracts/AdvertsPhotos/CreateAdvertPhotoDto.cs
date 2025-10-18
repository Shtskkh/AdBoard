using Adboard.Contracts.Base;

namespace Adboard.Contracts.AdvertsPhotos;

public class CreateAdvertPhotoDto : IFile
{
    public string Name { get; set; }
    public byte[] Content { get; set; }
    public int Order { get; set; }
}