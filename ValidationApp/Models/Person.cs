using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ValidationApp.Models
{
    public class Person
    {
        [Display(Name = "Имя и фамилия")]
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Некорректный электронный адрес")]
        public string Email { get; set; }
        
        [Display(Name = "Домашняя страница")]
        [UIHint("Url")]
        public string HomePage { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(1, 100)]
        public int Age { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}