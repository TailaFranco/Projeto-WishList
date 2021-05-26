SELECT * FROM Usuarios;
SELECT * FROM Desejos;

SELECT descricao, email, senha FROM Usuarios
FULL OUTER JOIN Desejos
ON Usuarios.idDesejo = Desejos.idDesejo;