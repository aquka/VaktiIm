ALTER TABLE AspNetUsers 
ADD emri nvarchar (128);

ALTER TABLE AspNetUsers 
ADD mbiemri nvarchar (128);

ALTER TABLE AspNetUsers 
ADD aktiv bit default((1));

ALTER TABLE AspNetUsers 
ADD krijimPerdorues datetime;

ALTER TABLE AspNetUsers 
ADD modifikimPerdoruesi datetime;

CREATE TABLE [dbo].[ROLI] (
    [rol_id] INT          IDENTITY (1, 1) NOT NULL,
    [emri]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([rol_id] ASC),
    UNIQUE NONCLUSTERED ([emri] ASC)
);

ALTER TABLE AspNetUsers 
ADD rol_id int;

ALTER TABLE AspNetUsers
ADD FOREIGN KEY (rol_id) REFERENCES Roli(rol_id);
