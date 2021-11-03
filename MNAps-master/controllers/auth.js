const mysql = require("mysql");
const jwt = require('jsonwebtoken');
const bcrypt = require('bcryptjs');

const db = mysql.createConnection({ //Her connecter jeg til databasen, med de oplysninger givet i .env filen
    host: process.env.DATABASE_HOST,
    user: process.env.DATABASE_USER,
    password: process.env.DATABASE_PASSWORD,
    database: process.env.DATABASE
});

exports.login = async (req, res) =>{
    try {
        const {email, password} = req.body;
        if (!req.signed) //Tror dette er en leftover, fra da jeg prøvede at implementere signed cookies
        if(!email || !password){
            return res.status(400).render('login', {
                message: 'Email eller adgangskode må ikke være tom'
            })
        }
        db.query('SELECT * FROM users WHERE email = ?', [email], async (error, results)=>{ //Kører dette query
            //console.log(results);
            if(!results || !(await bcrypt.compare(password, results[0].password))){ //Første check, ser om der findes en email der matcher det indtastede. Andet check ser om adgangskoden matcher efter den er dehashed
                res.status(401).render('login', {
                    message: 'Email eller adgangskode er forkert'
                })
            } else {
                res.status(200).redirect("/files"); //Hvis ingen af de ovennævnte lykkes, bliver man redirected til files, og får en god status(200)
            }
        })
    } catch (error) {
        console.log(error);
    }
}

exports.register = (req, res) =>{
    console.log(req.body);

    const { name, email, password, passwordConfirm } = req.body;

    db.query('SELECT email FROM users WHERE email = ?', [email], async (error, results) => {
        //Kører flere ifs for at checke om fx mailen allerede er i brug
        if(error) {
            console.log(error);
        }
        
        if(results.length > 0){
            return res.render('register', { //Hvis emailen allerede findes i databasen, får man denne fejl
                message: 'Email allerede i brug'
            })
        } else if(password !== passwordConfirm) { //Hvis de to indtastede adgangskoder ikke er de samme, får man denne fejl
            return res.render('register', {
                message: 'Adgangskoderne matcher ikke'
            });
        }

        let hashedPassword = await bcrypt.hash(password, 8); //Her hasher jeg adgangskoden, for at øge sikkerheden, og mindske skaden ved sql injections
        //console.log(hashedPassword);

        db.query('INSERT INTO users SET ?', {name: name, email: email, password: hashedPassword}, (error, results) => { //Hvis programmet ikke har stoppet på nogle af de tidligere checks, kører den denne query
            if(error){
                console.log(error);
            }else{
                //console.log(results);
                return res.render('register', {
                    message: 'Bruger oprettet'
                });
            }
        })
    })
};