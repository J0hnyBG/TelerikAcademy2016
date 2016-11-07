CREATE TABLE PerformanceLogs(
  Id int NOT NULL AUTO_INCREMENT,
  Content nvarchar(300),
  Date datetime,
  PRIMARY KEY (Id, Date)
) PARTITION BY RANGE(YEAR(Date)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (1995),
    PARTITION p2 VALUES LESS THAN (2000),
    PARTITION p3 VALUES LESS THAN (2005),
    PARTITION p4 VALUES LESS THAN MAXVALUE
);

INSERT INTO PerformanceLogs(Content, Date) VALUES
  ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24'),
  ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24'),
    ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24'),
    ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24'),
    ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24'),
    ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24');

SELECT
	COUNT(*)
FROM PerformanceLogs;

SELECT * FROM PerformanceLogs PARTITION (p0);
SELECT * FROM PerformanceLogs PARTITION (p1);
SELECT * FROM PerformanceLogs PARTITION (p2);
SELECT * FROM PerformanceLogs PARTITION (p3);
SELECT * FROM PerformanceLogs PARTITION (p4);

-- Select from all partitions
SELECT * FROM PerformanceLogs;

-- Select from a single partition
SELECT * FROM PerformanceLogs WHERE YEAR(Date) > 2005;
