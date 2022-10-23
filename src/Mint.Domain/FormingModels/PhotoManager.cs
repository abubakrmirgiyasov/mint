using Microsoft.AspNetCore.Http;
using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Domain.FormingModels;

public class PhotoManager
{
    public List<Photo> FormingPhotoBindingModel(List<PhotoBindingModel> photos)
    {
        try
        {
            var list = new List<Photo>();

            foreach (var photo in photos)
            {
                list.Add(new Photo()
                {
                    FileName = photo.FileName,
                    FileSize = photo.FileSize,
                    FileExtension = photo.FileExtension,
                    FileBytes = photo.FileBytes,
                    FilePath = photo.FilePath,
                });
            }

            return list;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public PhotoBindingModel GetSinglePhoto(List<PhotoBindingModel> photos)
    {
        var newPhoto = new PhotoBindingModel();

        foreach (var photo in photos)
        {
            newPhoto.FileName = photo.FileName;
            newPhoto.FileSize = photo.FileSize;
            newPhoto.FileExtension = photo.FileExtension;
            newPhoto.FileBytes = photo.FileBytes;
            newPhoto.FilePath = photo.FilePath;
        }

        return newPhoto;
    }

    public async Task<List<PhotoBindingModel>> AddPhotoAsync(IFormFileCollection? files)
    {
        try
        {
            var photos = new List<PhotoBindingModel>();

            if (files!.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();

                        await file.CopyToAsync(ms);

                        if (ms.Length < 2097152)
                        {
                            var newPhoto = new PhotoBindingModel()
                            {
                                FileName = Path.GetFileName(file.FileName),
                                FileSize = ms.Length,
                                FileExtension = Path.GetExtension(file.FileName),
                                FilePath = Path.GetFullPath(file.FileName),
                                FileBytes = ms.ToArray(),
                            };

                            photos.Add(newPhoto);
                        }
                        else
                        {
                            throw new Exception("Слишком большой файл");
                        }
                    }
                }
            }

            return photos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
