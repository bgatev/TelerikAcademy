//create table
Use test;
CREATE TABLE logs(
  id int NOT NULL AUTO_INCREMENT,
  date datetime, 
  text nvarchar(255),
  PRIMARY KEY (id, date)
) PARTITION BY RANGE(YEAR(date)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

//insert values
DELIMITER $$
CREATE PROCEDURE InsertRandomLogs(IN NumRows INT)
BEGIN
DECLARE i INT;
SET i = 1;
START TRANSACTION;
WHILE i <= NumRows DO
INSERT INTO logs(date,text)
VALUES (FROM_UNIXTIME(RAND() * 2147483647), conv(floor(rand() * 99999999999999), 20, 36));
SET i = i + 1;
END WHILE;
COMMIT;
END$$
DELIMITER ;
CALL InsertRandomLogs(1000000);

//select time = 0.4 seconds - all partitions involved
select * 
from logs
where date > '1981-03-01 21:07:42' and date < '5555-03-01 21:07:42'
limit 300000

//select time = 0.12 seconds - one partition involved
select * 
from logs
where date > '1991-03-01 21:07:42' and date < '1999-03-01 21:07:42'
limit 300000