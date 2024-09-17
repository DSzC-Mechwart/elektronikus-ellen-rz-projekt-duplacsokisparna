CREATE DATABASE rotring DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;

CREATE TABLE tanulo (
    nev VARCHAR(50),
    szulHely VARCHAR(50),
    szulIdo DATE,
    anyjanev VARCHAR(50),
    lakcim VARCHAR(50),
    beirIdo DATE,
    szak VARCHAR(50),
    osztaly VARCHAR(10),
    kolise BOOLEAN,
    koli VARCHAR(50),
    naploszam INT(8),
    torzsszam INT(8),
    matek VARCHAR(100),
    irodalom VARCHAR(100),
    nyelvtan VARCHAR(100),
    idegennyelv VARCHAR(100),
    tesi VARCHAR(100),
    fizika VARCHAR(100),
    szakma VARCHAR(100);
    );
    
CREATE Table tantargyak (
    tantargy VARCHAR(50),
    évfolyam INT(5),
    koz-szak VARCHAR(50),
    hetiora INT(8),
    evesora INT(10);
);