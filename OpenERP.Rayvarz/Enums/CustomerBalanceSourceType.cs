using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Enums
{
    public enum CustomerBalanceSourceType
    {
        [Description("مرور حساب")]
        Vouchers = 0,
        [Description("مرور فروش بدون احتساب اعتبار")]
        SalesWithoutCredit = 1,
    }
}
