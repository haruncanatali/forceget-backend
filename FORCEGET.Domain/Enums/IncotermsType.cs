using System.ComponentModel;

namespace FORCEGET.Domain.Enums;

public enum IncotermsType
{
    [Description("Delivered Duty Paid (DDP)")]
    DDP = 1,
    [Description("Delivered At Place")]
    DAT
}