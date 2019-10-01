

CREATE TABLE "User"(
   Id UUID PRIMARY KEY,
   Name VARCHAR (100) NOT NULL,
   Password VARCHAR (16) NOT NULL,
   Email VARCHAR (100) UNIQUE NOT NULL,
   BirthDate TIMESTAMP NOT NULL
);

INSERT INTO public."User"(
	id, name, password, email, birthdate)
	VALUES ('72eb138b-ffc4-4482-98e1-f971743200cf', 'Gabriel Augusto', '123456', 'gabrielgst56@hotmail.com', NOW());