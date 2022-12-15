using Microsoft.AspNetCore.Http;
using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Domain.FormingModels;

public class PhotoManager
{
    public List<Photo> FormingBindingModel(List<PhotoBindingModel> photos)
    {
        try
        {
            var list = new List<Photo>();

            foreach (var photo in photos)
            {
                list.Add(new Photo()
                {
                    FullName = photo.FullName!,
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

    public List<PhotoBindingModel> FormingViewModels(List<Photo>? photos)
    {
        try
        {
            if (photos != null)
            {
                var photoBindingModels = new List<PhotoBindingModel>();

                foreach (var photo in photos)
                {
                    photoBindingModels.Add(new PhotoBindingModel()
                    {
                        FullName = photo.FullName,
                        FileName = photo.FileName,
                        FileSize = photo.FileSize,
                        FileExtension = photo.FileExtension,
                        FileBytes = photo.FileBytes,
                        FilePath = photo.FilePath,
                    });
                }
                return photoBindingModels;
            }
            return null!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public PhotoBindingModel FormingSinglePhoto(List<PhotoBindingModel> photos)
    {
        if (photos != null)
        {
            var newPhoto = new PhotoBindingModel();

            foreach (var photo in photos)
            {
                newPhoto.FullName = photo.FullName;
                newPhoto.FileName = photo.FileName;
                newPhoto.FileSize = photo.FileSize;
                newPhoto.FileExtension = photo.FileExtension;
                newPhoto.FileBytes = photo.FileBytes;
                newPhoto.FilePath = photo.FilePath;
            }

            return newPhoto;
        }

        return null!;
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
                                Id = Guid.NewGuid(),
                                FullName = file.Name,
                                FileName = Path.GetFileName(file.FileName/*.Split('.')[0]*/),
                                FileSize = ms.Length,
                                FileExtension = Path.GetExtension(file.FileName/*.Split('.')[file.FileName.Length - 1]*/),
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
                return photos;
            }
            return null!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
