CREATE TABLE ADRESA (
    adrese_id  INT           IDENTITY (1, 1) NOT NULL,
    rruga      VARCHAR (100) NOT NULL,
    pershkrimi VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([adrese_id] ASC)
);

CREATE TABLE POROSI (
    porosi_id        INT      IDENTITY (1, 1) NOT NULL,
    adresa_id        INT      NOT NULL,
    datetime_Porosi  DATETIME NOT NULL,
    status_porosie   BIT      NOT NULL,
    klient_id        nvarchar (128)      NOT NULL,
    pergjegjes_id    nvarchar (128)      NOT NULL,
    data_Modifikimit DATETIME NULL,
    PRIMARY KEY CLUSTERED ([porosi_id] ASC),
    CONSTRAINT [POROSI_fk0] FOREIGN KEY ([adresa_id]) REFERENCES [ADRESA] ([adrese_id]),
    CONSTRAINT [POROSI_fk1] FOREIGN KEY ([klient_id]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [POROSI_fk2] FOREIGN KEY ([pergjegjes_id]) REFERENCES [AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[KATEGORI] (
    [kategori_id] INT           IDENTITY (1, 1) NOT NULL,
    [emri]        VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([kategori_id] ASC)
);

CREATE TABLE [dbo].[GATIM] (
    [gatim_id]        INT           IDENTITY (1, 1) NOT NULL,
    [emriGatimit]            VARCHAR (100) NOT NULL,
    [pershkrimi]      TEXT          NOT NULL,
    [cmimi]           MONEY         NOT NULL,
    [disponueshmeria] BIT           NOT NULL,
    [foto]            VARCHAR (100) NULL,
    [datakrijimit]    DATETIME      NOT NULL,
    [datamodifikimit] DATETIME      NULL,
    [createdBy]       nvarchar (128)           NOT NULL,
    [modifiedBy]      nvarchar (128)          NULL,
    [kategori_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([gatim_id] ASC),
    CONSTRAINT [GATIM_fk0] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [GATIM_fk1] FOREIGN KEY ([modifiedBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [GATIM_fk2] FOREIGN KEY ([kategori_id]) REFERENCES [dbo].[KATEGORI] ([kategori_id])
);

CREATE TABLE [dbo].[POROSI_ITEM] (
    [porosi_id] INT NOT NULL,
    [sasia]     INT NOT NULL,
    [gatim_id]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([porosi_id] ASC, [gatim_id] ASC),
    CONSTRAINT [POROSI_ITEM_fk0] FOREIGN KEY ([porosi_id]) REFERENCES [dbo].[POROSI] ([porosi_id]),
    CONSTRAINT [POROSI_ITEM_fk1] FOREIGN KEY ([gatim_id]) REFERENCES [dbo].[GATIM] ([gatim_id])
);


CREATE PROCEDURE [dbo].[GatimeAktive]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	Select * from Gatim
	where disponueshmeria = 1;
END

CREATE PROCEDURE [dbo].[Porosit_e_bera]
@id int	
AS
BEGIN

select g.emriGatimit, pt.sasia,p.status_porosie,a.pershkrimi,s.Email as emailiKlientit,k.Email 
from POROSI as p inner join POROSI_ITEM as pt on p.porosi_id= pt.porosi_id
inner join GATIM as g  ON pt.gatim_id = g.gatim_id
INNER JOIN ADRESA AS a ON p.adresa_id= a.adrese_id
INNER JOIN AspNetUsers AS s  ON p.klient_id = s.Id 
INNER JOIN AspNetUsers AS k ON p.pergjegjes_id = k.Id
WHERE p.porosi_id = @id

END

CREATE PROCEDURE [dbo].[Procedure1]
AS
BEGIN

select g.emriGatimit, pt.sasia,p.datetime_Porosi,p.adresa_id,p.klient_id,p.pergjegjes_id,p.porosi_id,p.status_porosie
from POROSI as p inner join POROSI_ITEM as pt
on p.porosi_id= pt.porosi_id
inner join GATIM as g 
on pt.gatim_id = g.gatim_id

END


CREATE PROCEDURE [dbo].[ShfaqPorosi1]
	
AS
	SELECT * from POROSI
	WHERE status_porosie= 1 


CREATE PROCEDURE [dbo].[ShfaqPorosit0]

AS
	SELECT * FROM POROSI
	WHERE status_porosie= 0

CREATE PROCEDURE Porosite_e_mia 
@id nvarchar (128)
AS
BEGIN
select p.porosi_id,p.datetime_Porosi,p.status_porosie,sum(pi.sasia*g.cmimi) as Vlera
from POROSI p inner join POROSI_ITEM pi 
on p.porosi_id=pi.porosi_id
inner join GATIM g
on pi.gatim_id=g.gatim_id
where p.klient_id=@id
GROUP BY p.porosi_id, p.datetime_Porosi,p.status_porosie

END

CREATE PROCEDURE Detaje_porosie 
@id int
AS
BEGIN
SELECT g.emriGatimit,g.cmimi,pi.sasia
FROM GATIM g inner join POROSI_ITEM pi
on g.gatim_id=pi.gatim_id
where pi.porosi_id=@id 
END

