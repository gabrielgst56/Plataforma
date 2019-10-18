using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Domain.Interfaces;
using IFSP.Plataforma.Infra.Data.Context;
using Npgsql;
using System;
using System.Collections.Generic;

namespace IFSP.Plataforma.Infra.Data.Repository
{
    public class ChatbotRepository : Repository<Chatbot>, IChatbotRepository
    {
        public ChatbotRepository(DataContext context)
            : base(context) {}

        public virtual void Adicionar(Chatbot obj)
        {
            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Db.GetConnectionString()))
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();

                    var a = obj.UserId == null ? "NULL" : $"'{obj.UserId.ToString()}'";

                    string cmdInserir = "INSERT INTO \"Chatbot\" (id,name,description, discordexported," +
                        $"messengerexported, discordbotsecret, userid, createddate) VALUES('{obj.Id.ToString()}','{obj.Name}','{obj.Description}'" +
                        $",{obj.DiscordExported}, {obj.MessengerExported}, '{obj.DiscordBotSecret}', {a}, '{obj.CreatedDate}' )";

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarDialogues(List<Dialogue> dialogues, Guid id, Guid? fatherId)
        {
            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Db.GetConnectionString()))
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();

                    foreach (var obj in dialogues)
                    {
                        obj.ChatbotId = id;

                        var a = fatherId == null ? "NULL" : $"'{fatherId.ToString()}'";

                        if (obj.Childrens.Count == 0)
                        {
                            obj.IsLastChildren = true;
                        }

                        string cmdInserir = "INSERT INTO \"Dialogue\" (id, userinput, chatbotoutput, fatherid," +
                            $"chatbotid, islastchildren) VALUES('{obj.Id.ToString()}','{obj.UserInput}','{obj.ChatbotOutput}'" +
                            $",{a}, '{obj.ChatbotId.ToString()}', {obj.IsLastChildren.ToString()})";

                        using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, pgsqlConnection))
                        {
                            pgsqlcommand.ExecuteNonQuery();
                        }


                        AdicionarDialogues(obj.Childrens, id, obj.Id);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
