using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IFSP.Plataforma.Application.ViewModels
{
    public class DialogueViewModel
    {

        //ToDo na entidade padrão do dialogue vamos ter que ter o Chatbot e o ChatbotId
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The User Input is Required")]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("User Input")]
        public string UserInput { get; set; }

        [Required(ErrorMessage = "The Chatbot Output is Required")]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Chatbot Output")]
        public string ChatbotOutput { get; set; }

        [DisplayName("Dialogue Childrens")]
        public List<DialogueViewModel> Childrens { get; set; }

    }
}
