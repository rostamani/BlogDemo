using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDemo.Application.Contracts.Article
{
    public class EditArticle
    {
        public int ArticleId { get; set; }

        [Display(Name = "عنوان مقاله")]
        [MaxLength(250, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر مقاله")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد.")]
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }

        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public string Body { get; set; }

        [Display(Name = "گروه مقاله")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد.")]
        public int CategoryId { get; set; }
    }
}
