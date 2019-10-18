// Postgres and server configs.
const express = require('express')
const bodyParser = require('body-parser')
const app = express()
const port = 3000
const stringSimilarity = require('string-similarity');

app.use(bodyParser.json())
app.use(
  bodyParser.urlencoded({
    extended: true,
  })
)

app.listen(port, () => {
  console.log(`App running on port ${port}.`)
})

//Chatbot and Discord configs
const Discord = require('discord.js')
const client = new Discord.Client();
const token = "NTYyMzUyMzA5OTE3NzEyMzky.XZuAfg.nO5Cw_XWR3WGyIIa5003kMkVvHc";
const chatbotId = "10320fde-bf5f-42f6-b243-d902ab415a7f";
var conversation = '';

client.on('ready', () => {
  console.log("Olá, meu nome é: " + client.user.username);
});

client.on('message', msg => {
  if (msg.author.id != client.user.id) {

    var sended = false;
    var sendEmail = false;

    cliente.query('SELECT D.* FROM "Dialogue" AS D INNER JOIN "Chatbot" AS C ON C."id" = D."chatbotid" WHERE C."id" = $1', [chatbotId], (err, res) => {
      if (err) throw err

      for (index in res.rows) {
        var row = res.rows[index]

        var similarity = stringSimilarity.compareTwoStrings(msg.content, row['userinput']);

        if (!sended && (similarity >= 0.5 || msg.content.toUpperCase().includes(row['userinput'].toUpperCase()))) {
          conversation = conversation + "\nUser: " + row['userinput'] + "\n";
          conversation = conversation + "\nChatbot: " + row['chatbotoutput'] + "\n";
          sended = true;
          msg.channel.send(row['chatbotoutput']);

          if(row['islastchildren'] == true){
            sendEmail = true;
          }
        }
      }

      if (!sended) {
        conversation = conversation + "\nUser: " + msg.content + "\n";
        conversation = conversation + "\nChatbot: Desculpe, não consegui identificar sua mensagem. Poderia tentar de outra forma?\n";
        msg.channel.send("Desculpe, não consegui identificar sua mensagem. Poderia tentar de outra forma?");
      }
      
      mailOptions.text = conversation.toString();

      if (sendEmail) {
        transporter.sendMail(mailOptions, function (error, info) {
          if (error) {
            console.log(error);
          } else {
            console.log('Email sent: ' + info.response);
          }
        });
      }
    });
  }
});

client.login(token)

//Postgres
const { Client } = require('pg')
const cliente = new Client({
  user: 'postgres',
  host: 'localhost',
  database: 'plataforma',
  password: 'ga310303',
  port: 5432,
})

cliente.connect(err => {
  if (err) {
  } else {
    console.log('Postgres Connected')
  }
});

//Email
var nodemailer = require('nodemailer');
var transporter = nodemailer.createTransport({
  service: 'gmail',
  auth: {
    user: 'gabrielgst5673@gmail.com',
    pass: 'winteriscomming11'
  }
});

var mailOptions = {
  from: 'gabrielgst5673@gmail.com',
  to: 'gabrielgst56@hotmail.com',
  subject: 'Sending Email using Node.js',
  text: 'That was easy!'
};

