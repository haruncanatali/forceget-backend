using System.ComponentModel;

namespace FORCEGET.Domain.Enums;

public enum ModeType
{
    [Description("LCL")]
    LCL = 1,
    [Description("FCL")]
    FCL,
    [Description("Air")]
    Air
}