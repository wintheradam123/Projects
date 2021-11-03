const express = require('express');
const authController = require('../controllers/auth');

const router = express.Router();

router.post('/register', authController.register )

router.post('/login', authController.login)

module.exports = router;

//Dette er alle routes. Routes bliver brugt til at forwarde de to understøttede requests, til controllers/auth.js