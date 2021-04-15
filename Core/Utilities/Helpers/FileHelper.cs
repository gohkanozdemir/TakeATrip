using Core.Business;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static (IResult, string dbPath) Upload(IFormFile file, string[] checkExtensions, params string[] folderNames)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            IResult result = BusinessRules.Run(
                                             CheckFileIsEmpty(file),
                                             CheckFileTypeValid(fileExtension, checkExtensions));
            if (result != null)
            {
                return (result, null);
            }

            // Gecerli ve dolu bir dosya geldi. Islemlere devam

            var folderName = Path.Combine(folderNames);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            // Guid Document --->    https://docs.microsoft.com/fr-fr/dotnet/api/system.guid.tostring?view=net-5.0
            var creatingUniqueFilename = Guid.NewGuid().ToString("N")  // 0f8fad5bd9cb469fa16570867728950e
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

            var fullPath = Path.Combine(pathToSave, creatingUniqueFilename);
            var dbPath = Path.Combine(folderName, creatingUniqueFilename);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return (new SuccessResult(), dbPath);
        }

        private static IResult CheckFileIsEmpty(IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult(AspectMessages.FileIsEmpty);
        }

        private static IResult CheckFileTypeValid(string fileExtension, string[] checkExtensions)
        {
            foreach (var fileExt in checkExtensions)
            {
                if (fileExt == fileExtension)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult(AspectMessages.WrongFileType);
        }
    }
}
