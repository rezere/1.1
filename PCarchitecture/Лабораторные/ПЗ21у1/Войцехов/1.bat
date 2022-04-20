@echo off
setlocal EnableDelayedExpansion
set "attrib_1=%"
set "date_creation=29-03-2003 21:03:03"
set "date_modification=09-01-2001 00:00:00"
for /f "delims=" %%a in ('dir /a-d/b/s "E:\1.1\Web\Lab 1\Lab1.1\*."') do (
    call :step_1 "%%a"
)
pause
exit
:step1
for /f "tokens=* delims=" %%a in ('powershell -executionpolicy bypass -command "(Get-ItemProperty -Path '%~1').Attributes | ForEach-Object {$string+=$}; $array=$string.tostring().split(" "); foreach ($a in $array) {$string_2+=$a.Chars(0) + ' '}; $string_2"') do (
    set "attrib_2=%%a"
    for %%b in (!attrib_2!) do (
        for %%c in (%attrib_1%) do (
            if /i %%b==%%c (
                nircmd.exe setfiletime "%~1" "%date_creation%" "%date_modification%"
                exit /b
            )
        )
    )
)
exit /b