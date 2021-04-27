using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDemo.Application.Contracts.Category
{
    public class EditCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام گروه نمیتواند خالی باشد.")]
        [MaxLength(250,ErrorMessage = "نام گروه نمیتواند بیشتر از 250 کاراکتر باشد.")]
        public string Name { get; set; }

    }
}
