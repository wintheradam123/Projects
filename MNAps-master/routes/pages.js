//Denne fil bliver brugt til at route til de forskellige views. I de views kaldes routes/auth.js filen, som kalder controlleren.
const express = require('express');
// const upload = require('express-fileupload');

const router = express.Router();

router.get('/', (req, res)=>{
    res.render('index');
});

router.get('/register', (req, res)=>{
    res.render('register');
});

router.get('/login', (req, res)=>{
    res.render('login');
});

router.get('/files', (req, res) =>{
    res.render('files');
});

router.post('/',(req, res)=>{
    if (req.files){
        console.log(req.files)
        var file = req.files.file
        var filename = new Date().getTime() + '_' + file.name //Giver det et (næsten) unikt navn
        console.log(filename)
        
        file.mv('./uploads/'+filename, function(err){
            if(err){
                console.log(err)
            }else {
                res.render('files')
            }
        })
    }
})

module.exports = router;