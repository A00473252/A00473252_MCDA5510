# A00473252_MCDA5510

Hey! I'm Subhiksha, a computer science engineering graduate with 2 years of experience as a Data Warehouse Developer for a merchant banking client. My A# is A00473252 and you can reach me at Subhiksha.Ramasubramanian@smu.ca

-------------------------------------------------------------------------------------------------------------------------------------
#CSVFileParser - Assignment 1


This is a simple CSV parser program that traverses through a directory of CSV files, reads data, rejects invalid rows and combines valid rows in an output CSV file(generated into "..\\..\\..\\Output"). The rejected rows are logged in a log file(generated into "..\\..\\..\log") along with other details like total execution time, number of valid rows and number of skipped rows.

Components of the solution:


	DirWalker.cs 		Walks through the whole directory, file by file
	Validation.cs		Specifies the validation criteria for the records
	DataAttributes.cs	Specifies the columns present in the CSV file
	Program.cs		Program that determines the valid and invalid records and then writes them into Output.csv and log.txt files respectively


Variables and their	Purpose:


	inputPath		the directory to be traversed
	outputFile		the Output.csv file that combines all the valid records
	logFile			the log.txt file that combines all the skipped records


Validation Criteria:


I used regular expressions to do basic validity check for the columns in the CSV files as follows

	First Name should not be empty and contain only alphabets
	Last Name should not be empty and contain only alphabets
	Street Number should not be empty and contain only numerical
	Street should not be empty and contain only alphabets
	City should not be empty and contain only alphabets
	Province should not be empty and contain only alphabets
	Postal Code should not be empty and contain alphabets and numbers, 6 characters long.
	Country should not be empty and contain only alphabets
	Phone numbers should not be empty and contain only 10 digits
	Email Address should not be empty and be n the valid format of subhi@smu.ca
	
	
Assumptions:


	The Date column to be added in the output file is of type String.
	All the CSV files contain headers and are uniform across different files.