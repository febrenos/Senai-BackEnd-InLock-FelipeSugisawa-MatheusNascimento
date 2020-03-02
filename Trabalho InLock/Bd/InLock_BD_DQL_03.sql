--DQL
--InLock_BD_DQL_03

USE Inlock_Games_Tarde;
GO

--Listar todos os usuários
SELECT * FROM Usuario;
GO
--Listar todos os estúdios
SELECT * FROM Estudio;
GO
--Listar todos os jogos;
SELECT * FROM Jogos;
GO
--Listar todos os jogos e seus respectivos estúdios;
SELECT Jogos.NomeJogos, Jogos.Descricao,Jogos.DataLancamento, Jogos.Valor, Estudio.NomeEstudio FROM Jogos 
INNER JOIN Estudio ON Estudio.IdEstudio = Jogos.IdEstudio
