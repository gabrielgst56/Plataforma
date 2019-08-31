using IFSP.Plataforma.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IFSP.Plataforma.Domain.Entities
{
    public class Dialogue : Entity
    {
        public Dialogue(Guid id, string userInput, string chatbotOutput, List<Dialogue> childrens, Chatbot chatbot)
        {
            Id = id;
            UserInput = userInput;
            ChatbotOutput = chatbotOutput;
            Childrens = childrens;
            Chatbot = chatbot;
            ChatbotId = chatbot?.Id;
        }

        // Empty constructor for EF
        protected Dialogue() { }

        public string UserInput { get; set; }

        public string ChatbotOutput { get; set; }

        public List<Dialogue> Childrens { get; set; }

        public Guid? ChatbotId { get; set; }
        public Chatbot Chatbot { get; set; }
    }
}
