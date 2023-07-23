CREATE DATABASE StudentskeBaze;

CREATE TABLE StudentskeBaze.dbo.Databases (
	Id int IDENTITY(0,1) NOT NULL,
	TeamNumber varchar(50) NOT NULL,
	Name varchar(50) NOT NULL,
	CreationDate datetime NOT NULL,
	Username varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Note text NULL,
	ContactEmail varchar(200) NULL,
	EmailSent int DEFAULT 0 NOT NULL,
	Archived int DEFAULT 0 NOT NULL
);

CREATE TABLE StudentskeBaze.dbo.MailSettings(
	Lock char(1) NOT NULL CONSTRAINT DF_MailSettings_Lock DEFAULT 'X',
	Sender varchar(70) NOT NULL DEFAULT 'noreply_pi@foi.hr',
	BccRecepients varchar(200) NOT NULL DEFAULT 'mmijac@foi.hr',
	Subject varchar(70) NOT NULL DEFAULT 'Baza podataka za projekt iz Programskog inzenjerstva',
	CONSTRAINT PK_MailSettings PRIMARY KEY (Lock),
	CONSTRAINT CK_MailSettings_Locked CHECK (Lock='X')
);

INSERT INTO StudentskeBaze.dbo.MailSettings DEFAULT VALUES;

CREATE LOGIN [tin] WITH PASSWORD = 'n3pr0b0jn0-wxhz-xycz';
