@echo OFF
echo Check paths ...
set ABS_PATH=%~dp0%
set SERV_PATH=..\..\ProgrammingLanguageWebService\ProgrammingLanguageWebService\bin\Release\netcoreapp3.1\win-x64\ProgrammingLanguageWebService.exe
set SERV_PATH="%ABS_PATH%%SERV_PATH%"
echo %SERV_PATH%
set NSSM_PATH=..\nssm-2.24\win64\nssm.exe
set NSSM_PATH="%ABS_PATH%%NSSM_PATH%"
echo %NSSM_PATH%
echo Start service installation ...

%NSSM_PATH% install ApiServer %SERV_PATH%
%NSSM_PATH% set ApiServer Description Api Server https://localhost:5000/ProgrammingLanguage

pause



























































