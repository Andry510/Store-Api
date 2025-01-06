using System.Runtime.Serialization;

namespace store.Enums;

public enum Role
{
    [EnumMember(Value = "admin")]
    Admin,

    [EnumMember(Value = "supplier")]
    Supplier,

    [EnumMember(Value = "supplier")]
    Customer,
}
