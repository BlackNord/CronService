using System;
using System.IO;
using System.Text;

namespace CronService.Utils.Extensions
{
    public static class TimeSpanParsingExtension
    {
        public static TimeSpan ToTimeSpan(this long source)
        {
            var result = TimeSpan.FromTicks(source);
            return result;

        }

        public static string ReadLastLine(string path)
        {
            return ReadLastLine(path, Encoding.ASCII, Environment.NewLine);
        }

        public static string ReadLastLine(string path, Encoding encoding, string newline)
        {
            var charsize = encoding.GetByteCount(newline);
            var buffer = encoding.GetBytes(newline);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var endpos = stream.Length / charsize;
                for (long pos = charsize; pos < endpos; pos += charsize)
                {
                    stream.Seek(-pos, SeekOrigin.End);
                    stream.Read(buffer, 0, buffer.Length);
                    if (encoding.GetString(buffer) == newline)
                    {
                        buffer = new byte[stream.Length - stream.Position];
                        stream.Read(buffer, 0, buffer.Length);
                        return encoding.GetString(buffer);
                    }
                }
            }

            return null;
        }
    }
}