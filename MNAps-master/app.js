const express = require("express");
const path = require('path');
const mysql = require("mysql");
const { rootCertificates } = require("tls");
const dotenv = require("dotenv");
const upload = require('express-fileupload');

dotenv.config({path: './.env'});

const app = express();

const db = mysql.createConnection({
    host: process.env.DATABASE_HOST,
    user: process.env.DATABASE_USER,
    password: process.env.DATABASE_PASSWORD,
    database: process.env.DATABASE
});

const publicDirectory = path.join(__dirname, './public');
app.use(express.static(publicDirectory));

//Hjælper til at bruge data fra forms
app.use(express.urlencoded({ extended: false }));
//Sikrer at værdierne vi får fra forms kommer i json format
app.use(express.json());
app.use(upload());

app.set('view engine', 'hbs');

db.connect( (error)=>{
if(error){
        console.log(error)
    } else {
        console.log("MySQL connected")
    }
})

//definerer vores routes til linkene på siden
app.use('/', require('./routes/pages'));
app.use('/auth', require('./routes/auth'));



app.listen(5001, ()=>{
    console.log("Server started on port 5001");
})
