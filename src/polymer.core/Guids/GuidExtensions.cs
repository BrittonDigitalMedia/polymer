using System;

namespace polymer.core.Guids
{
    public static class GuidExtensions
    {
        public static Guid TransfromToGuidWithProperSorting(this byte[] bytes)
        {
            return new Guid(new[]
        {
            bytes[10],
            bytes[11],
            bytes[12],
            bytes[13],
            bytes[14],
            bytes[15],
            bytes[8],
            bytes[9],
            bytes[6],
            bytes[7],
            bytes[4],
            bytes[5],
            bytes[0],
            bytes[1],
            bytes[2],
            bytes[3],
        });
        }
    }
}