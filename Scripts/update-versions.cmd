@echo off
setlocal
set return=goto :eof
set checkError=if errorlevel 1 goto :error

cd /d "%~dp0"

echo Getting the version number from version.txt
call :getNewVersion newVersion
%checkError%

echo New Version: %newVersion%

set newVersionCommas=%newVersion:.=,%

rem Non-optimal regexes: useful characters for OR, lookbehind and " are troublesome in batch scripting
set versionNumberRegex=\d+(?:\.\d+){2,3}
set assemblyVersionRegex=(Assembly(?:File)?Version(?:Attribute)?\(.)%versionNumberRegex%
set assemblyVersionReplacement=${1}%newVersion%

set csprojAssemblyVersionRegex=(\u003CAssemblyVersion\u003E)%versionNumberRegex%(\u003C/AssemblyVersion\u003E)
set csprojFileVersionRegex=(\u003CFileVersion\u003E)%versionNumberRegex%(\u003C/FileVersion\u003E)
set csprojProductVersionRegex=(\u003CVersion\u003E)%versionNumberRegex%(\u003C/Version\u003E)
set csprojVersionReplacement=${1}%newVersion%${2}

set wixVersionRegex=(.\?define\s+VERSION\s*=\s*.)%versionNumberRegex%(.\s*\?.)
set wixVersionReplacement=${1}%newVersion%${2}

set txd=Trixter.XDream

echo Updating API
call :updatecsproj "..\%txd%.API\%txd%.API.csproj"
%checkError%

echo Updating Diagnostics
call :updatecsproj "..\%txd%.Diagnostics\%txd%.Diagnostics.csproj"
%checkError%

echo Updating Test Controller
call :updatecsproj "..\%txd%.TestController\%txd%.TestController.csproj"
%checkError%

echo Updating installer project
call :regexReplace "..\%txd%.Installer\Version.wxi" "%wixVersionRegex%" "%wixVersionReplacement%" utf8
%checkError%

echo Done.

%return%

:updatecsproj

rem %1 is the file path of the .csproj file

call :regexReplace "%~1" "%csprojAssemblyVersionRegex%" "%csprojVersionReplacement%" utf8
%checkError%

call :regexReplace "%~1" "%csprojFileVersionRegex%" "%csprojVersionReplacement%" utf8
%checkError%

call :regexReplace "%~1" "%csprojProductVersionRegex%" "%csprojVersionReplacement%" utf8
%checkError%

%return%

:getNewVersion
rem sets the environment variable specified by the first argument to the last value found in the version.txt file
for /f "tokens=*" %%f in ('type %~dp0\version.txt') do set %1=%%f
if "%newVersion%"=="" exit /b 1
%return%


:regexReplace
rem %1 input file path
rem %2 search pattern
rem %3 replacement pattern
rem %4 output encoding
set tempFile=%temp%\bhcvbhcvlhb.tmp
powershell (Get-Content -path "%~1" -Raw -Encoding utf8) -replace '%~2','%~3' ^| out-file "%tempFile%" -encoding %~4 -NoNewline
if errorlevel 1 exit /b 1

copy "%tempFile%" "%~1" > nul
if errorlevel 1 exit /b 1

%return%

:error
echo ERROR
exit /b 1

