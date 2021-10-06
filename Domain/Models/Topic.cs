using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebForum.Models;

namespace WebForum.Domain.Models
{
    /// <summary>
    /// Тема
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Нова тема має містити заголовок")]
        [MaxLength(120, ErrorMessage = "Заголовок не може перевищувати 120 символів")]
        public string Title { get; set; }
        /// <summary>
        /// Текст теми
        /// </summary>
        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Тема має містити текст")]
        [MaxLength(1600, ErrorMessage = "Текс не може перевищувати 1600 символів")]
        [DataType(DataType.MultilineText)]
        public string TextOfTopic { get; set; }
        /// <summary>
        /// Ідентифікатор користувача
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Користувач
        /// </summary>
        public virtual ApplicationUser AuthorTopic { get; set; }
        /// <summary>
        /// Дата створення/редагування теми
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime TimeOfCreateOrLastUpdate { get; set; }
        /// <summary>
        /// Дописи
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }


        //Додаткові
        /// <summary>
        /// Кількість дописів
        /// </summary>
        [NotMapped]
        public int CountOfPosts => Posts.Any() ? Posts.Count() : 0;

        
        /// <summary>
        /// Конструктор
        /// </summary>
        public Topic()
        {
            Posts = new List<Post>();
        }
        
    }
}