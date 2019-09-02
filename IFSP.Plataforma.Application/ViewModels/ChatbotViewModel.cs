using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IFSP.Plataforma.Application.ViewModels
{
    public class ChatbotViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(20)]
        [DisplayName("Name")]
        public string Name { get; set; }
        
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        public bool DiscordExported { get; set; }

        public bool MessengerExported { get; set; }

        public string DiscordBotSecret { get; set; }        

        [DisplayName("Chatbot Dialogue")]
        public List<DialogueViewModel> Dialogues { get; set; }

        [DisplayName("User")]
        public UserViewModel User { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
