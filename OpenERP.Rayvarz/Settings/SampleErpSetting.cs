using AbrPlus.Integration.OpenERP.Service.Configuration;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Settings
{
    [Serializable]
    public class RayvarzSetting : IFinancialSystemSetting
    {
        [Display(GroupName = "گروه فرضی", Name = "نام تنشیمات تیکی", Description = "توضیحات تنشیمات تیکی")]
        [UIHint("Checkbox")]
        public bool CheckBoxSetting { get; set; }

        [Display(GroupName = "گروه فرضی 2", Name = "نام تنشیمات لیستی", Description = "توضیحات تنشیمات لیستی")]
        [UIHint("Select")]
        public string DropdownSetting { get; set; }

        [Display(GroupName = "گروه فرضی 2", Name = "نام تنشیمات متنی", Description = "توضیحات تنشیمات متنی")]
        [UIHint("Text")]
        public string StringSetting { get; set; }
    }
}
