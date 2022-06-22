echo Check paths ...
set ABS_PATH=%~dp0%
set NSSM_REL_PATH=..\nssm-2.24\win64\nssm.exe
echo %NSSM_REL_PATH%
set NSSM_PATH="%ABS_PATH%%NSSM_REL_PATH%"
echo %NSM_PATH%
echo Start service starting ...

%NSSM_PATH% start ApiServer
pause