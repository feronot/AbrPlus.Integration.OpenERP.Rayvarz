using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Enums
{
    public enum CustomerNumberSourceType
    {
        [Description("کد تفضیلی")]
        DLCode = 0,
        [Description("کد طرف حساب")]
        PartyNumber = 1,
        [Description("کد مشتری")]
        CustomerNumber = 2,
    }
}
