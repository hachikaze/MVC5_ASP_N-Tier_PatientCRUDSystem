CREATE SCHEMA `patient_crud` ;

USE patient_crud;

CREATE TABLE Medication (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Dosage DECIMAL(7,4) NOT NULL,
    Drug VARCHAR(50) NOT NULL,
    Patient VARCHAR(50) NOT NULL,
    ModifiedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- STORED PROCEDURE FOR ADDNING NEW RECORDS
DELIMITER //

CREATE PROCEDURE AddMedication(
    IN Dosage DECIMAL(7,4),
    IN Drug VARCHAR(50),
    IN Patient VARCHAR(50)
)
BEGIN
    INSERT INTO Medication (Dosage, Drug, Patient)
    VALUES (Dosage, Drug, Patient);
END //

DELIMITER ;

-- TEST THE ADD PROCEDURE
CALL AddMedication(2.5, 'Shabu', 'Jane Doe');

select * from medication;

-- STORED PROCEDURE FOR UPDATING RECORDS
DELIMITER //

CREATE PROCEDURE UpdateMedication (
    IN medicationId INT,
    IN NewDosage DECIMAL(7,4),
    IN NewDrug VARCHAR(50),
    IN NewPatient VARCHAR(50)
)
BEGIN
    UPDATE Medication
    SET Dosage = NewDosage, Drug = NewDrug, Patient = NewPatient WHERE Id = medicationId;
END //

DELIMITER ;

DROP procedure UpdateMedication;

-- TEST THE UPDATE PROCEDURE
CALL UpdateMedication(1, 3.5, 'brr', 'John Labadan');

DELIMITER //

-- STORED PROCEDURE FOR DELETING RECORDS
CREATE PROCEDURE DeleteMedication
(
	IN medicationId INT
)
BEGIN
	DELETE FROM medication WHERE Id = medicationId;
END //

DELIMITER ;

-- TEST THE DELETE PROCEDURE
CALL DeleteMedication(2);

INSERT INTO Medication (Dosage, Drug, Patient, ModifiedDate)
VALUES 
(0.2500, 'Amoxicillin', 'John Doe', '2025-03-23 11:00:00'),
(1.5000, 'Ibuprofen', 'Jane Smith', '2025-03-22 15:34:00'),
(0.7500, 'Metformin', 'Emily Johnson', '2025-03-21 09:12:00'),
(2.0000, 'Paracetamol', 'Michael Brown', '2025-03-20 18:45:00'),
(0.1250, 'Alprazolam', 'Sarah Davis', '2025-03-19 14:30:00'),
(1.0000, 'Simvastatin', 'David Wilson', '2025-03-18 08:05:00'),
(3.5000, 'Levothyroxine', 'Alice Cooper', '2025-03-17 12:25:00'),
(0.6250, 'Citalopram', 'Mark Taylor', '2025-03-16 20:00:00'),
(2.7500, 'Losartan', 'Anna Moore', '2025-03-15 16:55:00'),
(0.3750, 'Warfarin', 'Peter Parker', '2025-03-14 10:30:00');