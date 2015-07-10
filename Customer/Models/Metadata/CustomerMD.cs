using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer.Models
{
    [MetadataType(typeof(CustomerMD))]
    public partial class 客戶資料
    {
        public class CustomerMD
        {
            [Required(ErrorMessage = "客戶名稱不可為空")]
            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 客戶名稱 { get; set; }

            [Required(ErrorMessage = "統一編號不可為空")]
            [StringLength(8, ErrorMessage = "長度為8個字", MinimumLength = 8)]
            public string 統一編號 { get; set; }

            [Required(ErrorMessage = "電話不可為空")]
            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 電話 { get; set; }

            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 傳真 { get; set; }

            [MaxLength(100, ErrorMessage = "不可超過100個字")]
            public string 地址 { get; set; }

            [MaxLength(250, ErrorMessage = "不可超過250個字")]
            [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress, ErrorMessage = "請輸入正確的Email")]
            public string Email { get; set; }
        }
    }
}