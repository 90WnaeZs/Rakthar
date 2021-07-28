-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Már 22. 21:35
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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gepek`
--

CREATE TABLE `gepek` (
  `ID_Gép` bigint(20) NOT NULL,
  `Gépnév` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `Azonosítószám` varchar(20) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `mennyiseg`
--

CREATE TABLE `mennyiseg` (
  `ID_Mennyiség` bigint(20) NOT NULL,
  `Megnevezés` varchar(30) NOT NULL,
  `Egység` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  MODIFY `ID_Login` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `beszallito`
--
ALTER TABLE `beszallito`
  MODIFY `ID_Beszállító` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `cikk`
--
ALTER TABLE `cikk`
  MODIFY `ID_Cikk` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `ID_User` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `gepek`
--
ALTER TABLE `gepek`
  MODIFY `ID_Gép` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `hely`
--
ALTER TABLE `hely`
  MODIFY `ID_Hely` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `karbantartas`
--
ALTER TABLE `karbantartas`
  MODIFY `ID_Karbantartás` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `mennyiseg`
--
ALTER TABLE `mennyiseg`
  MODIFY `ID_Mennyiség` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `rendeles`
--
ALTER TABLE `rendeles`
  MODIFY `ID_Rendel` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `selejtezes`
--
ALTER TABLE `selejtezes`
  MODIFY `ID_Selejtezés` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `utemezes`
--
ALTER TABLE `utemezes`
  MODIFY `ID_Ütemezett` bigint(20) NOT NULL AUTO_INCREMENT;

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
