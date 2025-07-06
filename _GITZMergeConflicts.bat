@echo off
echo *****************************************************************************************
echo * GIT Merge Conflicts from https://github.com/robinwilson16/PSWebAPI-AskhamBryanCollege *
echo *****************************************************************************************
echo .
echo .
echo Current conflicts to be merged:
git checkout
echo .
echo What would you like to do?
echo K=Keep existing changes to above files
echo X=Overwrite existing changes with your changes
echo C=Cancel and do not resolve the issue.
SET /P M=Please select an option: 
IF %M%==K GOTO KEEP
IF %M%==X GOTO OVERWRITE
IF %M%==C GOTO EOF

:KEEP
echo Keeping changes...
git checkout --theirs
GOTO EOF
:OVERWRITE
echo Overwriting changes...
git checkout --ours
GOTO EOF
:EOF
echo Exiting...
pause