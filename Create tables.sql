

CREATE TABLE "User"(
   Id UUID PRIMARY KEY,
   Name VARCHAR (100) NOT NULL,
   Password VARCHAR (16) NOT NULL,
   Email VARCHAR (100) UNIQUE NOT NULL,
   BirthDate TIMESTAMP NOT NULL
);

INSERT INTO "User"(
	id, name, password, email, birthdate)
	VALUES ('72eb138b-ffc4-4482-98e1-f971743200cf', 'Gabriel Augusto', '123456', 'gabrielgst56@hotmail.com', NOW());

CREATE TABLE "Chatbot"(
   Id UUID PRIMARY KEY,
   Name VARCHAR (20) NOT NULL,
   Description VARCHAR (200) NOT NULL,
   DiscordExported BOOLEAN NOT NULL,
   MessengerExported BOOLEAN NOT NULL,
   DiscordBotSecret VARCHAR(100) NOT NULL,
   UserId UUID REFERENCES "User"(Id),
   CreatedDate TIMESTAMP NOT NULL
);

CREATE TABLE "Dialogue"(
   Id UUID PRIMARY KEY,
   UserInput VARCHAR (50) NOT NULL,
   ChatbotOutput VARCHAR (200) NOT NULL,
   FatherId UUID References "Dialogue"(Id),
   ChatbotId UUID NOT NULL References "Chatbot"(Id),
   IsLastChildren BOOLEAN 
);
	