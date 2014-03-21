IF  NOT EXISTS(SELECT *  FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ReschedulingOfALoanEvents'  AND COLUMN_NAME = 'previous_interest_rate') 
BEGIN
ALTER TABLE  ReschedulingOfALoanEvents ADD  previous_interest_rate DECIMAL(25,15) NOT NULL DEFAULT 0
END
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.4.0.0'
WHERE   [name] = 'VERSION'
GO
