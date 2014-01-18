@setlocal enableextensions
@cd /d "%~dp0"

copy "AutoLangDetect\bin\Debug\AutoLangDetect.dll" "%programfiles%\Notepad++\plugins\AutoLangDetect.dll"
copy "AutoLangDetect\bin\Debug\AutoLangDetect.dll" "%programfiles(x86)%\Notepad++\plugins\AutoLangDetect.dll"
