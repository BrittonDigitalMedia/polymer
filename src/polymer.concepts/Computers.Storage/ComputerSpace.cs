using System.ComponentModel;
using System.Runtime.Serialization;

namespace polymer.concepts.Computers.Storage
{
    [DataContract(Namespace = "http://schemas.mosaic.co.za/types"), KnownType(typeof(ComputerSpace))]
    [Description("a value object used to express space on a computer or the size of a file")]
    public class ComputerSpace
    {
        [Description("the quantity of the specified unit of measurement representing a size or space value")]
        [DataMember(Order=0)]
        public int Value { get; set; }
        [Description("the unit of measurement specific to space on a computer")]
        [DataMember(Order = 1)]
        public ComputerSpaceMeasurement Measurement { get; set; }
    }
}