using JobHunt.Enums;
using System.Text;

namespace JobHunt.Helpers
{
    public static class FileHandling
    {
        public static string ConvertVideoName(string filename, int userid)
        {
            var builder = new StringBuilder(userid.ToString());
            builder.Append('_');
            builder.Append("Video_");
            builder.Append(filename);
           return builder.ToString();
        }

        public static string ConvertResumeName(string filename, int userid)
        {
            var builder = new StringBuilder(userid.ToString());
            builder.Append('_');
            builder.Append("Resume_");
            builder.Append(filename);
            return builder.ToString();
        }

        public static string ConvertImageName(string filename, int userid)
        {
            var builder = new StringBuilder(userid.ToString());
            builder.Append('_');
            builder.Append("Image_");
            builder.Append(filename);
            return builder.ToString();
        }

        public static FileType GetFiletype(string fileExtension)
        {
            return fileExtension switch
            {
                ".mp4" => FileType.Video,
                ".docx" => FileType.Document,
                ".pdf" => FileType.PDF,
                ".JPEG" => FileType.Image,
                ".JPG" => FileType.Image,
                ".Png" => FileType.Image,
                _ => FileType.Invalid,
            };
        }
    }
}
