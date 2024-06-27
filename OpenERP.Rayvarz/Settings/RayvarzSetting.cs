using AbrPlus.Integration.OpenERP.Service.Configuration;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Settings
{
    [Serializable]
    public class RayvarzSetting : IFinancialSystemSetting
    {
        [Display(GroupName = "گروه فرضی", Name = "نام تنظیمات تیکی", Description = "توضیحات تنظیمات تیکی")]
        [UIHint("Checkbox")]
        public bool CheckBoxSetting { get; set; }

        [Display(GroupName = "گروه فرضی 2", Name = "نام تنظیمات لیستی", Description = "توضیحات تنظیمات لیستی")]
        [UIHint("Select")]
        public string DropdownSetting { get; set; }

        [Display(GroupName = "گروه فرضی 2", Name = "نام تنظیمات متنی", Description = "توضیحات تنظیمات متنی")]
        [UIHint("Text")]
        public string StringSetting { get; set; }
    }
}
