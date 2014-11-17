using System;
using System.Threading;

namespace polymer.core.Guids
{
    public class SequentialGuid
    {
        public static Guid Create()
        {
            var ticksAsBytes = BitConverter.GetBytes(DateTime.Now.Ticks);
            Array.Reverse(ticksAsBytes);
            var increment = Interlocked.Increment(ref _sequentialUuidCounter);
            var currentAsBytes = BitConverter.GetBytes(increment);
            Array.Reverse(currentAsBytes);
            var bytes = new byte[16];
            Array.Copy(ticksAsBytes, 0, bytes, 0, ticksAsBytes.Length);
            Array.Copy(currentAsBytes, 0, bytes, 12, currentAsBytes.Length);
            return bytes.TransfromToGuidWithProperSorting();
        }

        
        private static int _sequentialUuidCounter;
    }
}