CREATE TABLE GENEROS (
    ID NUMBER GENERATED BY DEFAULT AS IDENTITY,
    DENOMINACION VARCHAR2(200),
    DESCRIPCIÓN VARCHAR2(200)
);

CREATE TABLE PACIENTES (
    ID NUMBER GENERATED BY DEFAULT AS IDENTITY,
    NOMBRE VARCHAR2(200) NOT NULL,
    FEC_NAC DATE NOT NULL,
    EMAIL VARCHAR2(200),
    GENERO NUMBER,
    DIRECCION VARCHAR2(200),
    TELEFONO VARCHAR(10),
    FEC_ADM DATE,
	CONSTRAINT fk_pacientes_generos FOREIGN KEY (GENERO) REFERENCES GENEROS (ID)
);

ALTER TABLE PACIENTES
ADD CONSTRAINT fk_pacientes_generos
FOREIGN KEY (GENERO)
REFERENCES GENEROS (ID);