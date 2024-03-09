using System.ComponentModel;

namespace FORCEGET.Domain.Enums;

public enum CurrencyType
{
    [Description("USD - US Dollar")]
    USD = 1,
    [Description("CNY - Chinese Yuan")]
    CNY,
    [Description("TRY - Turkish Lira")]
    TRY
}