using System.Runtime.Serialization;

namespace Model.PetModule.Attribute
{
    [DataContract]
    public enum NeedType
    {
        [EnumMember] Bellyful,
        [EnumMember] Cleanliness
    }
}