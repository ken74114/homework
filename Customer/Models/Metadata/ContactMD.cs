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
    public partial class 客戶聯絡人 : IValidatableObject
    {
        private 客戶聯絡人Repository contactRepository = RepositoryHelper.Get客戶聯絡人Repository();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool isValidate = false;
            isValidate = this.contactRepository.IsRepeatForEmail(客戶Id, this.Email, this.Id);
            if (isValidate)
                yield return new ValidationResult("Email不可重複", new[] { "Email" });
        }

        public class ContactMD
        {
            [DisplayName("客戶")]
            [Required(ErrorMessage="請選擇客戶")]
            public int 客戶Id { get; set; }

            public int Id { get; set; }

            [Required(ErrorMessage="職稱不可為空")]
            [MaxLength(50, ErrorMessage="不可超過50個字")]
            public string 職稱 { get; set; }
            
            [Required(ErrorMessage="姓名不可為空")]
            [MaxLength(50, ErrorMessage = "不可超過50個字")]
            public string 姓名 { get; set; }

            [Required(ErrorMessage = "Email不可為空")]
            [MaxLength(250, ErrorMessage = "不可超過250個字")]
            [DataType( System.ComponentModel.DataAnnotations.DataType.EmailAddress, ErrorMessage="請輸入正確的Email")]
            //[Remote("CheckEmail", "Validate", AdditionalFields = "客戶Id,Id", ErrorMessage = "Email不可重複")]
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