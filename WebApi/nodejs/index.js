const express = require("express");
const app = express();
const cors = require("cors");
const todos = ["Work1","Work2","Work3"];

app.use(express.json());
app.use(cors());

app.get("/api", (req,res)=> {
    res.json({message:"Valla çalışıyorum"});
});

app.get("/api/GetTodos", (req,res)=> {
    res.json(todos);
});

app.listen(5000, ()=> {console.log("Uygulama 5000 portundan çalışıyor")});