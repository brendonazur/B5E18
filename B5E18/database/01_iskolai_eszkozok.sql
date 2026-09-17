-- Iskolai eszközök - egyszerű MariaDB gyakorló adatbázis
-- A script többször is lefuttatható.

DROP DATABASE IF EXISTS iskolai_eszkozok;

CREATE DATABASE iskolai_eszkozok;

USE iskolai_eszkozok;

CREATE TABLE eszkozok (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(100),
    leltari_szam VARCHAR(30),
    kategoria VARCHAR(50),
    gyarto VARCHAR(50),
    modell VARCHAR(50),
    terem VARCHAR(20),
    allapot VARCHAR(20),
    hasznalatban_van BOOLEAN,
    kolcsonozheto BOOLEAN,
    beszerzesi_ar INT,
    beszerzes_datuma DATE
);

INSERT INTO eszkozok
(nev, leltari_szam, kategoria, gyarto, modell, terem, allapot, hasznalatban_van, kolcsonozheto, beszerzesi_ar, beszerzes_datuma)
VALUES
('Tanári laptop', 'IT-001', 'Laptop', 'Dell', 'Latitude 5420', 'A304', 'Jó', TRUE, TRUE, 280000, '2022-09-01'),
('Diák laptop 1', 'IT-002', 'Laptop', 'Lenovo', 'ThinkPad E14', 'A304', 'Jó', TRUE, TRUE, 250000, '2023-08-15'),
('Diák laptop 2', 'IT-003', 'Laptop', 'Lenovo', 'ThinkPad E14', 'A304', 'Közepes', TRUE, TRUE, 250000, '2023-08-15'),
('Fejlesztői laptop', 'IT-004', 'Laptop', 'HP', 'ProBook 450', 'A315', 'Új', TRUE, TRUE, 330000, '2026-02-10'),

('Asztali gép 1', 'PC-001', 'Asztali gép', 'Dell', 'OptiPlex 7090', 'A304', 'Jó', TRUE, FALSE, 320000, '2021-09-01'),
('Asztali gép 2', 'PC-002', 'Asztali gép', 'Dell', 'OptiPlex 7090', 'A315', 'Közepes', TRUE, FALSE, 320000, '2021-09-01'),
('Régi számítógép', 'PC-003', 'Asztali gép', 'HP', 'EliteDesk 800', 'Raktár', 'Hibás', FALSE, FALSE, 180000, '2018-09-01'),

('Monitor 1', 'MON-001', 'Monitor', 'Samsung', 'S24R350', 'A304', 'Jó', TRUE, FALSE, 55000, '2022-01-20'),
('Monitor 2', 'MON-002', 'Monitor', 'Samsung', 'S24R350', 'A304', 'Hibás', FALSE, FALSE, 55000, '2022-01-20'),
('Monitor 3', 'MON-003', 'Monitor', 'LG', '27MP400', 'A315', 'Új', TRUE, FALSE, 70000, '2026-01-15'),

('Projektor 1', 'PROJ-001', 'Projektor', 'Epson', 'EB-X49', 'A022', 'Jó', TRUE, FALSE, 220000, '2021-10-11'),
('Projektor 2', 'PROJ-002', 'Projektor', 'BenQ', 'MW560', 'A304', 'Jó', TRUE, TRUE, 240000, '2024-03-04'),

('Router 1', 'NET-001', 'Hálózati eszköz', 'MikroTik', 'hAP ax2', 'A315', 'Jó', TRUE, TRUE, 50000, '2024-09-05'),
('Router 2', 'NET-002', 'Hálózati eszköz', 'TP-Link', 'Archer C6', 'Raktár', 'Hibás', FALSE, FALSE, 20000, '2019-09-10'),
('Switch', 'NET-003', 'Hálózati eszköz', 'Cisco', 'CBS250', 'A315', 'Jó', TRUE, FALSE, 170000, '2023-02-01'),

('Raspberry Pi 5', 'DEV-001', 'Fejlesztői eszköz', 'Raspberry Pi', 'Pi 5', 'A304', 'Új', TRUE, TRUE, 43000, '2026-04-12'),
('Arduino Uno', 'DEV-002', 'Fejlesztői eszköz', 'Arduino', 'Uno R4', 'A304', 'Jó', TRUE, TRUE, 12000, '2025-02-20'),

('Nyomtató', 'PRN-001', 'Nyomtató', 'Brother', 'HL-L2442DW', 'A304', 'Jó', TRUE, FALSE, 70000, '2024-01-08'),
('Külső SSD', 'STO-001', 'Adattároló', 'Samsung', 'T7 1TB', 'A304', 'Jó', TRUE, TRUE, 46000, '2024-06-14'),
('Tablet', 'TAB-001', 'Tablet', 'Apple', 'iPad 10', 'A304', 'Új', TRUE, TRUE, 180000, '2026-06-01');

SELECT * FROM eszkozok;
