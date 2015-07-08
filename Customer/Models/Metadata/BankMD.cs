using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer.Models
{
    [MetadataType(typeof(BankMD))]
    public partial class 客戶銀行資訊
    {
        public class BankMD
        {
            [DisplayName("客戶")]
            [Required(ErrorMessage = "請選擇客戶")]
            public int 客戶Id { get; set; }

            [Required(ErrorMessage = "銀行名稱不可為空")]
            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 銀行名稱 { get; set; }

            [Required(ErrorMessage = "銀行代碼不可為空")]
            [MinLength(3, ErrorMessage = "長度為3個字")]
            [MaxLength(3, ErrorMessage = "長度為3個字")]
            public string 銀行代碼 { get; set; }

            [Required(ErrorMessage = "分行代碼不可為空")]
            [MinLength(4, ErrorMessage = "長度為4個字")]
            [MaxLength(4, ErrorMessage = "長度為4個字")]
            public string 分行代碼 { get; set; }

            [Required(ErrorMessage = "帳戶名稱不可為空")]
            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 帳戶名稱 { get; set; }

            [Required(ErrorMessage = "帳戶號碼不可為空")]
            [MaxLength(20, ErrorMessage = "不可超過20個字")]
            public string 帳戶號碼 { get; set; }
        }
    }
}