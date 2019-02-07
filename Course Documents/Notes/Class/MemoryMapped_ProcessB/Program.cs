using System;
using System.Threading.Tasks;
using System.IO.MemoryMappedFiles;

namespace MemoryMapped_ProcessB
{
    class Program
    {
        static void Main(string[] args)
        {
            using(MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile(
                @"memory.txt",
                Filemode.OpenOrCreate, 
                "Memory-Map",
                100000)); {
                    using (MemoryMappedViewAccessor viewAccessor = mappedFile.CreateViewAccessor())
                    {
                        byte[] textBytes = Encoding.UTF8.GetBytes("Here comes some log message.");
                        viewAccessor.WriteArray(0,textBytes,0,textBytes.Length);
                    }
                }
        }
    }
}
