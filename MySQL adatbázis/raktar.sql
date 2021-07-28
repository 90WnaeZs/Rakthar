-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Már 22. 22:51
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `raktar`
--
CREATE DATABASE IF NOT EXISTS `raktar` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `raktar`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bejelentkezes`
--

CREATE TABLE `bejelentkezes` (
  `ID_Login` bigint(20) NOT NULL,
  `User_ID` bigint(20) NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `bejelentkezes`
--

INSERT INTO `bejelentkezes` (`ID_Login`, `User_ID`, `Date`) VALUES
(1, 3, '2021-03-22 21:52:59'),
(2, 1, '2021-03-22 21:53:01'),
(3, 2, '2021-03-22 21:53:05'),
(4, 1, '2021-03-22 21:53:21'),
(5, 1, '2021-03-22 21:53:51'),
(6, 1, '2021-03-22 21:55:03'),
(7, 2, '2021-03-22 21:58:08'),
(8, 3, '2021-03-22 22:00:27'),
(9, 3, '2021-03-22 22:01:25'),
(10, 3, '2021-03-22 22:03:12'),
(11, 3, '2021-03-22 22:04:09'),
(12, 3, '2021-03-22 22:04:40'),
(13, 1, '2021-03-22 22:05:46'),
(14, 1, '2021-03-22 22:07:33'),
(15, 1, '2021-03-22 22:09:30'),
(16, 1, '2021-03-22 22:10:52'),
(17, 1, '2021-03-22 22:17:40'),
(18, 1, '2021-03-22 22:18:11'),
(19, 1, '2021-03-22 22:21:25'),
(20, 3, '2021-03-22 22:30:22'),
(21, 1, '2021-03-22 22:40:05'),
(22, 3, '2021-03-22 22:49:30');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `beszallito`
--

CREATE TABLE `beszallito` (
  `ID_Beszállító` bigint(20) NOT NULL,
  `Beszállító_név` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `Szállítási_idő` tinyint(2) NOT NULL,
  `Város` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `Cím` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `Telefonszám` varchar(11) COLLATE utf8_hungarian_ci NOT NULL,
  `Emailcím` varchar(30) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `beszallito`
--

INSERT INTO `beszallito` (`ID_Beszállító`, `Beszállító_név`, `Szállítási_idő`, `Város`, `Cím`, `Telefonszám`, `Emailcím`) VALUES
(1, 'Mihályi Kft.', 3, 'Budapest', 'Abádi utca 5.', '01203405600', 'mihalyi@mail.huhu'),
(2, 'Daniella', 3, 'Budapest', 'Adony utca 10.', '01003505200', 'daniella@mail.huhu'),
(3, 'Stralala', 2, 'Debrecen', 'Kossuth utca 1.', '02104305600', 'stralala@mail.huhu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cikk`
--

CREATE TABLE `cikk` (
  `ID_Cikk` bigint(20) NOT NULL,
  `Cikknév` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `Gyártói` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `Típus` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `Beszállító_ID` bigint(20) NOT NULL,
  `Ár` mediumint(7) NOT NULL,
  `Mennyiség_ID` bigint(20) NOT NULL,
  `Minimum` smallint(6) NOT NULL,
  `Maximum` smallint(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `cikk`
--

INSERT INTO `cikk` (`ID_Cikk`, `Cikknév`, `Gyártói`, `Típus`, `Beszállító_ID`, `Ár`, `Mennyiség_ID`, `Minimum`, `Maximum`) VALUES
(7, '5x15 munkahenger', 'M125', 'mechanikus', 1, 1000, 1, 5, 15),
(8, 'ASMOTEK 2C kontrolpanel', 'ASM-2C', 'elektromos', 2, 450250, 1, 1, 5),
(9, 'olajozó spray', '2145', 'rezsi', 3, 500, 3, 5, 20),
(10, 'B15 2x4 szűrő', 'B15', 'mechanikus', 1, 5400, 3, 5, 10),
(11, '10x20x2 rugó', 'm', 'elektromos', 2, 100, 3, 100, 200);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `ID_User` bigint(20) NOT NULL,
  `Username` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `Password` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `Munkakör` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `Email` varchar(30) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`ID_User`, `Username`, `Password`, `Munkakör`, `Email`) VALUES
(1, 'a', '49', 'raktáros', 'a@mail.huhu'),
(2, 'b', '50', 'műszerész', 'b@mail.huhu'),
(3, 'c', '51', 'gazdálkodó', 'c@mail.huhu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gepek`
--

CREATE TABLE `gepek` (
  `ID_Gép` bigint(20) NOT NULL,
  `Gépnév` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `Azonosítószám` varchar(20) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `gepek`
--

INSERT INTO `gepek` (`ID_Gép`, `Gépnév`, `Azonosítószám`) VALUES
(1, 'Bliszterező', 'A123'),
(2, 'Kartonozó', 'B123'),
(3, 'Drazsírozó', 'C123');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hely`
--

CREATE TABLE `hely` (
  `ID_Hely` bigint(20) NOT NULL,
  `Cikk_ID` bigint(20) NOT NULL,
  `Mennyiség` smallint(6) NOT NULL,
  `Épület` tinyint(4) NOT NULL,
  `Raktár` tinyint(4) NOT NULL,
  `Oszlop` tinyint(4) NOT NULL,
  `Polc` tinyint(4) NOT NULL,
  `Box` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `hely`
--

INSERT INTO `hely` (`ID_Hely`, `Cikk_ID`, `Mennyiség`, `Épület`, `Raktár`, `Oszlop`, `Polc`, `Box`) VALUES
(3, 7, 10, 1, 1, 1, 1, 1),
(4, 8, 1, 2, 2, 2, 2, 2),
(5, 9, 9, 3, 3, 3, 3, 3),
(6, 7, 5, 1, 1, 2, 2, 2),
(7, 8, 1, 2, 2, 1, 1, 1),
(8, 9, 10, 1, 1, 1, 1, 1),
(9, 10, 0, 2, 2, 2, 2, 2),
(10, 10, 1, 3, 2, 2, 2, 2),
(11, 11, 43, 1, 1, 1, 1, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `karbantartas`
--

CREATE TABLE `karbantartas` (
  `ID_Karbantartás` bigint(20) NOT NULL,
  `Gép_ID` bigint(20) NOT NULL,
  `Cikk_ID` bigint(20) NOT NULL,
  `Mennyiség` smallint(6) NOT NULL,
  `Karbantartva` date NOT NULL,
  `Karbantartó` varchar(30) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `karbantartas`
--

INSERT INTO `karbantartas` (`ID_Karbantartás`, `Gép_ID`, `Cikk_ID`, `Mennyiség`, `Karbantartva`, `Karbantartó`) VALUES
(2, 1, 9, 1, '2021-03-22', NULL),
(3, 1, 11, 3, '2021-03-03', 'Kis Oszkár');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `mennyiseg`
--

CREATE TABLE `mennyiseg` (
  `ID_Mennyiség` bigint(20) NOT NULL,
  `Megnevezés` varchar(30) NOT NULL,
  `Egység` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `mennyiseg`
--

INSERT INTO `mennyiseg` (`ID_Mennyiség`, `Megnevezés`, `Egység`) VALUES
(1, 'darab', 'db'),
(2, 'kilogramm', 'kg'),
(3, 'készlet', 'klt');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendeles`
--

CREATE TABLE `rendeles` (
  `ID_Rendel` bigint(20) NOT NULL,
  `Cikk_ID` bigint(20) NOT NULL,
  `Beszállító_ID` bigint(20) NOT NULL,
  `Mennyiség` int(11) NOT NULL,
  `Rendelve` date NOT NULL,
  `Érkezés` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `rendeles`
--

INSERT INTO `rendeles` (`ID_Rendel`, `Cikk_ID`, `Beszállító_ID`, `Mennyiség`, `Rendelve`, `Érkezés`) VALUES
(2, 8, 2, 3, '2021-03-22', '2021-03-31'),
(3, 9, 3, 50, '2021-03-22', '2021-04-06'),
(4, 7, 1, 5, '2021-03-22', '2021-03-24'),
(5, 9, 3, 20, '2021-03-01', '2021-03-05');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `selejtezes`
--

CREATE TABLE `selejtezes` (
  `ID_Selejtezés` bigint(20) NOT NULL,
  `Cikk_ID` bigint(20) NOT NULL,
  `Hely_ID` bigint(20) NOT NULL,
  `Mennyiség` tinyint(3) NOT NULL,
  `Dátum` date NOT NULL,
  `Indok` varchar(20) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `selejtezes`
--

INSERT INTO `selejtezes` (`ID_Selejtezés`, `Cikk_ID`, `Hely_ID`, `Mennyiség`, `Dátum`, `Indok`) VALUES
(2, 8, 4, 1, '2021-03-22', 'Selejt'),
(3, 10, 9, 2, '2021-03-22', 'Selejt'),
(4, 7, 3, 2, '2021-03-04', 'Selejt');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `utemezes`
--

CREATE TABLE `utemezes` (
  `ID_Ütemezett` bigint(20) NOT NULL,
  `Gép_ID` bigint(20) NOT NULL,
  `Dátum` date NOT NULL,
  `Óra` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `utemezes`
--

INSERT INTO `utemezes` (`ID_Ütemezett`, `Gép_ID`, `Dátum`, `Óra`) VALUES
(1, 1, '2021-03-31', '10:00:09');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `bejelentkezes`
--
ALTER TABLE `bejelentkezes`
  ADD PRIMARY KEY (`ID_Login`),
  ADD KEY `UserID_reláció` (`User_ID`);

--
-- A tábla indexei `beszallito`
--
ALTER TABLE `beszallito`
  ADD PRIMARY KEY (`ID_Beszállító`);

--
-- A tábla indexei `cikk`
--
ALTER TABLE `cikk`
  ADD PRIMARY KEY (`ID_Cikk`),
  ADD KEY `cikk_beszallito` (`Beszállító_ID`),
  ADD KEY `cikk_mennyiseg` (`Mennyiség_ID`);

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`ID_User`);

--
-- A tábla indexei `gepek`
--
ALTER TABLE `gepek`
  ADD PRIMARY KEY (`ID_Gép`);

--
-- A tábla indexei `hely`
--
ALTER TABLE `hely`
  ADD PRIMARY KEY (`ID_Hely`),
  ADD KEY `hely_cikk` (`Cikk_ID`);

--
-- A tábla indexei `karbantartas`
--
ALTER TABLE `karbantartas`
  ADD PRIMARY KEY (`ID_Karbantartás`),
  ADD KEY `karb_cikk_relacio` (`Cikk_ID`),
  ADD KEY `karb_gep_relacio` (`Gép_ID`);

--
-- A tábla indexei `mennyiseg`
--
ALTER TABLE `mennyiseg`
  ADD PRIMARY KEY (`ID_Mennyiség`);

--
-- A tábla indexei `rendeles`
--
ALTER TABLE `rendeles`
  ADD PRIMARY KEY (`ID_Rendel`),
  ADD KEY `rendeles_cikk` (`Cikk_ID`),
  ADD KEY `rendeles_beszallito` (`Beszállító_ID`);

--
-- A tábla indexei `selejtezes`
--
ALTER TABLE `selejtezes`
  ADD PRIMARY KEY (`ID_Selejtezés`),
  ADD KEY `selejt_cikk` (`Cikk_ID`),
  ADD KEY `selejt_hely` (`Hely_ID`);

--
-- A tábla indexei `utemezes`
--
ALTER TABLE `utemezes`
  ADD PRIMARY KEY (`ID_Ütemezett`),
  ADD KEY `utem_gep_relacio` (`Gép_ID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `bejelentkezes`
--
ALTER TABLE `bejelentkezes`
  MODIFY `ID_Login` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT a táblához `beszallito`
--
ALTER TABLE `beszallito`
  MODIFY `ID_Beszállító` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `cikk`
--
ALTER TABLE `cikk`
  MODIFY `ID_Cikk` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `ID_User` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `gepek`
--
ALTER TABLE `gepek`
  MODIFY `ID_Gép` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `hely`
--
ALTER TABLE `hely`
  MODIFY `ID_Hely` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `karbantartas`
--
ALTER TABLE `karbantartas`
  MODIFY `ID_Karbantartás` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `mennyiseg`
--
ALTER TABLE `mennyiseg`
  MODIFY `ID_Mennyiség` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `rendeles`
--
ALTER TABLE `rendeles`
  MODIFY `ID_Rendel` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `selejtezes`
--
ALTER TABLE `selejtezes`
  MODIFY `ID_Selejtezés` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `utemezes`
--
ALTER TABLE `utemezes`
  MODIFY `ID_Ütemezett` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `bejelentkezes`
--
ALTER TABLE `bejelentkezes`
  ADD CONSTRAINT `UserID_reláció` FOREIGN KEY (`User_ID`) REFERENCES `felhasznalok` (`ID_User`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `cikk`
--
ALTER TABLE `cikk`
  ADD CONSTRAINT `cikk_beszallito` FOREIGN KEY (`Beszállító_ID`) REFERENCES `beszallito` (`ID_Beszállító`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `cikk_mennyiseg` FOREIGN KEY (`Mennyiség_ID`) REFERENCES `mennyiseg` (`ID_Mennyiség`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `hely`
--
ALTER TABLE `hely`
  ADD CONSTRAINT `hely_cikk` FOREIGN KEY (`Cikk_ID`) REFERENCES `cikk` (`ID_Cikk`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `karbantartas`
--
ALTER TABLE `karbantartas`
  ADD CONSTRAINT `karb_cikk_relacio` FOREIGN KEY (`Cikk_ID`) REFERENCES `cikk` (`ID_Cikk`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `karb_gep_relacio` FOREIGN KEY (`Gép_ID`) REFERENCES `gepek` (`ID_Gép`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `rendeles`
--
ALTER TABLE `rendeles`
  ADD CONSTRAINT `rendeles_beszallito` FOREIGN KEY (`Beszállító_ID`) REFERENCES `beszallito` (`ID_Beszállító`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rendeles_cikk` FOREIGN KEY (`Cikk_ID`) REFERENCES `cikk` (`ID_Cikk`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `selejtezes`
--
ALTER TABLE `selejtezes`
  ADD CONSTRAINT `selejt_cikk` FOREIGN KEY (`Cikk_ID`) REFERENCES `cikk` (`ID_Cikk`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `selejt_hely` FOREIGN KEY (`Hely_ID`) REFERENCES `hely` (`ID_Hely`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `utemezes`
--
ALTER TABLE `utemezes`
  ADD CONSTRAINT `utem_gep_relacio` FOREIGN KEY (`Gép_ID`) REFERENCES `gepek` (`ID_Gép`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
