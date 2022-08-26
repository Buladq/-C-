using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CasesView.Models
{
    public class Case
    {
      
        public int Id { get; set; }
        
        
        
        [StringLength(15,MinimumLength = 3,ErrorMessage = "Название менее 3 и не более 15")] //StringLength - длина строки
        [Required(ErrorMessage = "Пустое поле Название")]
        [Display(Name = "Название дела")]
        public string Name { get; set; } 
        
        
      
        [Display(Name = "Описание дела")]
        [Required(ErrorMessage = "Пустое поле имя")]
        [StringLength(50,MinimumLength = 1,ErrorMessage = "Описание менее 5 и не более 30")] //StringLength - длина строки
        public string Description { get; set; } 
      
        
        
        [Required(ErrorMessage = "Не указана ничего")]
        [Display(Name = "Важность дела")]
        [Range(1,10,ErrorMessage = "Важность дела должна быть от 1 до 10")] // диапозон и ошибка при другом диапозоне
        public int? Importance { get; set; } 
    }
}
