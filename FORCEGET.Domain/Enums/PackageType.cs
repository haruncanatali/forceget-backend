using System.ComponentModel;

namespace FORCEGET.Domain.Enums;

public enum PackageType
{
    [Description("Pallets")]
    Pallets = 1,
    [Description("Boxes")]
    Boxes,
    [Description("Cartons")]
    Cartons
}