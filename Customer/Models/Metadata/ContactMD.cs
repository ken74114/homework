using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Customer.Attributes;
using System.Web.Mvc;

namespace Customer.Models
{
    [MetadataType(typeof(ContactMD))]
    public partial class 客戶聯絡人
    {
        public class ContactMD
        {
            [DisplayName("客戶")]
            [Required(ErrorMessage="請選擇客戶")]
            public int 客戶Id { get; set; }

            [Required(ErrorMessage="職稱不可為空")]
            [MaxLength(50, ErrorMessage="不可超過50個字")]
            public string 職稱 { get; set; }
            
            [Required(ErrorMessage="姓名不可為空")]
            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 姓名 { get; set; }

            [Required(ErrorMessage = "Email不可為空")]
            [MaxLength(250, ErrorMessage = "不可超過250個字")]
            [DataType( System.ComponentModel.DataAnnotations.DataType.EmailAddress, ErrorMessage="請輸入正確的Email")]
            [Remote("CheckEmail", "Validate", AdditionalFields = "客戶Id", ErrorMessage = "Email不可重複")]
            public string Email { get; set; }

            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            //[CellPhone(ErrorMessage="手機格式不正確")]
            [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "手機格式不正確")]
            public string 手機 { get; set; }

            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 電話 { get; set; }
        }
    }
}