REM Create a 'GeneratedReports' folder if it does not exist
if not exist "C:\Work\Test Solutions\SolutionNotWorking" mkdir "C:\Work\Test Solutions\SolutionNotWorking"

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports" mkdir "C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports"

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports\test" mkdir "C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports\test"
  
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
"C:\Work\Test Solutions\TestCIGitHub\AutoBuild\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"C:\Work\Test Solutions\TestCIGitHub\AutoBuild\TestCI.Tests\bin\Debug\TestCI.Tests.dll\" /resultsfile:\"%~dp0TestCI.trx\"" ^
-filter:"+[TestCI*]* -[TestCI.Tests]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports\TestCI.xml"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"C:\Work\Test Solutions\TestCIGitHub\AutoBuild\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe" ^
-reports:"C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports\TestCI.xml" ^
-targetdir:"C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "C:\Work\Test Solutions\TestCIGitHub\AutoBuild\GeneratedReports\ReportGenerator Output\index.htm"
