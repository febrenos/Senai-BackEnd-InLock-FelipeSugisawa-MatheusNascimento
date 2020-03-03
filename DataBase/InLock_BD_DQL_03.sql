--DQL

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

--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
--todos os estúdios mesmo que eles não contenham nenhum jogo de referência
SELECT Jogos.IdJogo, Jogos.NomeJogos, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudio.IdEstudio, Estudio.NomeEstudio FROM Jogos
INNER JOIN Estudio 
ON Estudio.IdEstudio = Jogos.IdEstudio

--Buscar um usuário por email e senha;
SELECT Usuario.IdUsuario, Usuario.Email, Usuario.Senha, TipoUsuario.Titulo FROM Usuario 
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
WHERE Usuario.Email = 'admin@admin.com' AND Usuario.Senha = 'admin'

SELECT * FROM Usuario

--Buscar um jogo por IdJogo;
SELECT IdJogo, NomeJogos FROM Jogos WHERE IdJogo = 1;

--Buscar um estúdio por IdEstudio;
SELECT IdEstudio, NomeEstudio FROM Estudio WHERE IdEstudio = 1;

SELECT * FROM TipoUsuario;
SELECT * FROM Estudio;
SELECT * FROM Usuario;

TRUNCATE TABLE Estudio

