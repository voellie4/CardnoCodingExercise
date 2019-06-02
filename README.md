# CardnoCodingExercise

Requirement:
Visual Studio 2017

Instructions: 
SQL Management Studio:
	1) Edit in DbCandidate.sql the directory paths for data and log files then run the script.

Visual Studio:
	2) Open CandidateApplication.sln on VS 2017.
	3) Edit Web.config file/connectionstring/data source to have your server name. 
	4) Server Explorer panel: Refresh Data Connection.
	5) Clean Solution, Build solution and Run.

Note:
	- If a part of the path ...bin\roslyn\csc.exe could not be found, please clean and build solution then run again.
	- The program supports wildcard search by adding "\*" to the search string of first name, last name, phone number, email 	and zip code. For example, '\*70\*' is for searching all zip codes that contain 70.
