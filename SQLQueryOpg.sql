CREATE TABLE BorgerOpgaver (
    BorgerOpgID  INT  IDENTITY (1, 1) NOT NULL,
    ArbejdsOpgave VARCHAR (255) NOT NULL,
    OpgaveBeskrivelse VARCHAR (255) NOT NULL,
    OpgStart  DATE,
    OpgSlut  DATE,
    ID           INT           NULL,
    FOREIGN KEY (ID) REFERENCES Borgere (ID)
); 