using System.Runtime.Serialization;

namespace polymer.concepts.Computers.Storage
{
    [DataContract(Namespace = "http://schemas.mosaic.co.za/types")]
    public enum ComputerSpaceMeasurement
    {
        [EnumMember]
        Bits,
        [EnumMember]
        Bytes,
        [EnumMember]
        KiloBytes,
        [EnumMember]
        MegaBytes,
        [EnumMember]
        GigaBytes,
        [EnumMember]
        TerraBytes,
        [EnumMember]
        PetaBytes,
    }
}