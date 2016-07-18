REM Create a 'GeneratedReports' folder if it does not exist 
if not exist "%WORKSPACE%\GeneratedReports" mkdir "%WORKSPACE%\GeneratedReports" 
    
REM Remove any previous test execution files to prevent issues overwriting 
IF EXIST "%~dp0TestCI.trx" del "%~dp0TestCI.trx%" 
 
 
   
REM Run the tests against the targeted output 
call :RunOpenCoverUnitTestMetrics 
   
REM Generate the report output based on the test results 
if %errorlevel% equ 0 ( 
call :RunReportGeneratorOutput 
) 
   
REM Launch the report 
if %errorlevel% equ 0 ( 
call :RunLaunchReport 
) 
exit /b %errorlevel% 
   
:RunOpenCoverUnitTestMetrics 
del /q "%WORKSPACE%\AutoBuildTest\"  
mkdir "%WORKSPACE%\AutoBuildTest\"  
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe" /resultsfile:"%WORKSPACE%\AutoBuildTest\Results.trx" /testcontainer:"%WORKSPACE%\TestCI.Tests\bin\Debug\TestCI.Tests.dll" /nologo 
"%WORKSPACE%\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" -register:"%WORKSPACE%\packages\OpenCover.4.6.519\tools\x64\OpenCover.Profiler.dll" -target:"%WORKSPACE%\packages\NUnit.ConsoleRunner.3.4.1\tools\nunit3-console.exe"  -targetargs:"""%WORKSPACE%\NUnit\bin\Debug\NUnit.dll""" -output:"TestCIOpenCover.xml" 
exit /b %errorlevel% 
   
:RunReportGeneratorOutput 
"%WORKSPACE%\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe" -reports:"%WORKSPACE%\TestCIOpenCover.xml" -targetdir:"%WORKSPACE%\GeneratedReports\ReportGenerator Output" 
exit /b %errorlevel% 
   
:RunLaunchReport 
start "report" "%WORKSPACE%\GeneratedReports\ReportGenerator Output\index.htm" 
