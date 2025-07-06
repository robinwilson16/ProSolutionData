@echo off
echo ******************************************************************************
echo * GIT Upload to https://github.com/robinwilson16/PSWebAPI-AskhamBryanCollege *
echo ******************************************************************************
echo .
echo Adding files to repository...
git add .
set /p changes="Enter Brief Details of Change: "
git commit -m "%changes%"
git pull
git push
pause