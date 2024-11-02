﻿using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Request
{
    public class SaveAccount
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(FieldsSizeConst.Account.NameMax, MinimumLength = FieldsSizeConst.Account.NameMin, ErrorMessage = FieldsSizeConst.Account.NameMessage)]
        public string Name { get; set; }
        [StringLength(FieldsSizeConst.Account.FullNameMax, ErrorMessage = FieldsSizeConst.Account.FullNameMessage)]
        public string FullName { get; set; }
        [StringLength(FieldsSizeCommonConst.Mobile.Len, MinimumLength = FieldsSizeCommonConst.Mobile.Len, ErrorMessage = FieldsSizeCommonConst.Mobile.Message)]
        [RegularExpression(FieldsSizeCommonConst.Mobile.RegEx, ErrorMessage = FieldsSizeCommonConst.Mobile.RegExMessage)]
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
    }
}