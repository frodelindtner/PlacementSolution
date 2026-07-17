
The file sql-create-standing is a script to create tables within a database.

The database name must be StandingDB.db and be located in /storage/database

In db_result.py line 6 is an example of the connection string



-----------


FAILME 

CREATE TABLE Teams(
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	Season INTEGER,
	City VARCHAR(50),
	Name VARCHAR(50),
	League VARCHAR(20),
	Division VARCHAR(50)
);

CREATE TABLE Results(
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	TeamId INTEGER NOT NULL,
	Wins INTEGER, 
	Losses INTEGER,
	FOREIGN KEY (TeamId) REFERENCES Teams(Id)
);

