using System;
using System.IO;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int piecesCount = 4;
            using (FileStream stream = new FileStream("../../../slice.txt",FileMode.Open))
            {
                long size = stream.Length / piecesCount;

                for (int i = 0; i < piecesCount; i++)
                {
                    using (var pieceStream = new FileStream($"../../../part-{i+1}.txt",FileMode.Create))
                    {
                        byte[] buffer = new byte[1];
                        int count = 0;
                        while (count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            pieceStream.Write(buffer, 0, buffer.Length);
                            count+=buffer.Length;
                        }
                    }
                }
            }
        }
    }
}
