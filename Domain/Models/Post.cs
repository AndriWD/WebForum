using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebForum.Models;

namespace WebForum.Domain.Models
{
    /// <summary>
    /// Допис
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        /// <summary>
        /// Текст
        /// </summary>
        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Повідомлення не можна опублікувати пустим")]
        [MaxLength(350, ErrorMessage = "Розмір повідомлення не може перевищувати 350 знаків")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        /// <summary>
        /// Ідентифікатор Теми
        /// </summary>
        public int TopicId { get; set; }
        /// <summary>
        /// Тема
        /// </summary>
        public virtual Topic Topic { get; set; }
        /// <summary>
        /// Ідентифікатор Користувача
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Користувач
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        /// <summary>
        /// Дата створення/редагування дописа
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime TimeOfCreateOrLastUpdate { get; set; }
    }
}