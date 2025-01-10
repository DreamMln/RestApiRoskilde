CREATE TABLE Noter (
    NoteID  INT  IDENTITY (1, 1) NOT NULL,
    NoteOmBorger VARCHAR (255) NOT NULL,
    DatoTid  DATE,
    ID           INT           NULL,
    FOREIGN KEY (ID) REFERENCES Borgere (ID)
);