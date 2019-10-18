const { Client } = require('pg')
const client = new Client({
    user: 'postgres',
    host: 'localhost',
    database: 'plataforma',
    password: 'ga310303',
    port: 5432,
})

client.connect(err => {
    if (err) {
        console.error('connection error', err.stack)
    } else {
        console.log('connected')
    }
});

const chatbotId = "10320fde-bf5f-42f6-b243-d902ab415a7f";

const getChatbot = (request, response) => {
    pool.query('SELECT * FROM "Chatbot"', (error, results) => {
        if (error) {
            throw error
        }
        response.status(200).json(results.rows)
    })
}

const getDialoguesByChatbotId = () => {
    client.query('SELECT D.* FROM "Dialogue" AS D INNER JOIN "Chatbot" AS C ON C."id" = D."chatbotid" WHERE C."id" = $1', [chatbotId], (err, res) => {
        if (err) throw err
        client.end()
        console.log(res);
        return res
    });
}
const teste = client.query('SELECT D.* FROM "Dialogue" AS D INNER JOIN "Chatbot" AS C ON C."id" = D."chatbotid" WHERE C."id" = $1', [chatbotId], (err, res) => {
    if (err) throw err
    client.end()
    console.log(res.rows);
    return res.rows
});

console.log(teste);

module.exports = {
    getDialoguesByChatbotId
}