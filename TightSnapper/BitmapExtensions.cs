using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TightSnapper
{
    // Provides JPEG encoder and compression caps
    public static class BitmapExtensions
    {
        public static void SaveJpg100(this Bitmap bmp, string filename)
        {
            var encoderParameters = new EncoderParameters(1)
            {
                Param = {[0] = new EncoderParameter(Encoder.Quality, Form1.CompressionLevel)}
            };
            bmp.Save(filename, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static void SaveJpg100(this Bitmap bmp, Stream stream)
        {
            var encoderParameters = new EncoderParameters(1)
            {
                Param = {[0] = new EncoderParameter(Encoder.Quality, Form1.CompressionLevel)}
            };
            bmp.Save(stream, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();

            foreach (var codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;

            return null;
        }
    }
}