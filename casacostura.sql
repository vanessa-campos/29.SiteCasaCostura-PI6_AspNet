-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 26-Fev-2022 às 15:19
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `casacostura`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `atendimento`
--

CREATE TABLE `atendimento` (
  `Id` int(11) NOT NULL,
  `Nome` longtext DEFAULT NULL,
  `Email` longtext DEFAULT NULL,
  `Telefone` longtext DEFAULT NULL,
  `Mensagem` longtext DEFAULT NULL,
  `Atendido` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `carrinho`
--

CREATE TABLE `carrinho` (
  `Id` int(11) NOT NULL,
  `Usuario` int(11) NOT NULL,
  `ProdutoNome` longtext DEFAULT NULL,
  `ProdutoDescricao` longtext DEFAULT NULL,
  `ProdutoTamanho` longtext DEFAULT NULL,
  `Quantidade` int(11) NOT NULL,
  `Concluido` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `Id` int(11) NOT NULL,
  `Nome` longtext DEFAULT NULL,
  `Descricao` longtext DEFAULT NULL,
  `Tamanho` longtext DEFAULT NULL,
  `Quantidade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `Nome`, `Descricao`, `Tamanho`, `Quantidade`) VALUES
(1, 'Tecido Tricoline Liso', 'Azul Claro', '1,00m X 1,50m ', 5),
(2, 'Tecido Jacquard Floral', 'Preto e Branco', '1,00m X 1,40m ', 5),
(3, 'Plástico Térmico 10', 'Xadrez Vermelho', '1,00m X 1,50m ', 10),
(4, 'Botão 2 Furos', 'Diversas Cores', '18mm', 144),
(5, 'Botão 4 Furos', 'Transparente', '25mm', 144),
(6, 'Botão 4 Furos', 'Perolado', '10mm', 144),
(7, 'Linha de Costura', 'Diversas Cores', 'Tubo 100m', 10),
(8, 'Linha Pesponto', 'Diversas Cores', 'Tubo 30m', 10),
(9, 'Linha de Croche Clea', 'Diversas Cores', 'Novelo 1.000m', 3),
(10, 'Cortina Lisa', 'Branco', '2,00m X 3,00m', 3),
(11, 'Kit Capas para Cadeiras', 'Contém 6 unidades', '0,45m X 1,50m', 3),
(12, 'Pano de Prato', 'Pintado a Mão', '0,45m X 0,70m', 5),
(13, 'Toalha de Rosto', 'Bordada a Mão', '0,30m X 0,60m', 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Tipo` int(11) NOT NULL,
  `Nome` longtext DEFAULT NULL,
  `Login` longtext DEFAULT NULL,
  `Senha` longtext DEFAULT NULL,
  `DataNascimento` datetime(6) NOT NULL,
  `Telefone` longtext DEFAULT NULL,
  `Cep` longtext DEFAULT NULL,
  `Endereco` longtext DEFAULT NULL,
  `Deletado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220225230038_casacostura', '3.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `atendimento`
--
ALTER TABLE `atendimento`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `carrinho`
--
ALTER TABLE `carrinho`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `atendimento`
--
ALTER TABLE `atendimento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `carrinho`
--
ALTER TABLE `carrinho`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
