# C-Sharp-Folder-Transfer
Console application for transferring folders.  There is a class for manual transfers and a class for automatic transfers.  
The automatic transfer is currently hardcoded to paths on my desktop and is executed when the program is run.  
The automatic transfer runs and then begins the manual transfer.  The navigation process uses the windows "cd DIRECTORY" notation and 
provides a "-s" command for selecting the current directory for transfer and an "-r" command to restart the process.
An error may be thrown due to the hardcoded automatic transfer(autopathy.cs) being called by program.cs
