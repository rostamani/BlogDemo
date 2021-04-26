using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDemo.Application.Contracts.Article
{
    public class CreateArticle
    {
        public int CategoryId { get; set; }

        [DisplayName("عنوان مقاله")]
        [Required(ErrorMessage = "عنوان مقاله نمیتواند خالی باشد.")]
        public string Title { get; set; }

        [DisplayName("توضیح مختصر")]
        [Required(ErrorMessage = "توضیح مختصر نمیتواند خالی باشد.")]
        public string ShortDescription { get; set; }

        [DisplayName("عکس")]
        public string Picture { get; set; }

        [DisplayName("متن جایگزین عکس")]
        public string PictureAlt { get; set; }

        [DisplayName("متن مقاله")]
        [Required(ErrorMessage = "متن مقاله نمیتواند خالی باشد.")]
        public string Body { get; set; }

    }
}
