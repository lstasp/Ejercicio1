# Ejercicio1
Repo test

***Design:

Visual studio .net 2017 class library framework 4.6.1

***Test Framework

NUnit 3

***Problems

1) Several platform issues before using visual studio 2012, by this reason finally was built using vs 2017
2) Since vs 2012 or later NUnit tests needs specify a solution xmlfile called "CodeCoverage.runsettings", however this file cannot gather results in orderto run "code coverage analysis" tool, because we need use visual studio enterprise version in order to use code coverage tool, see this document confirm: https://msdn.microsoft.com/es-cl/library/jj159523.aspx

Without codecoverage analysis is difficult to me know exactly if test coverage is 80% or more, however i have tried to cover almost all functions in the source code by hand.

You can see codecoverage window using this menu: test -> windows -> code coverage results

***How to run the test

1) Download (clone) this repo, and visualstudio solution file is inside ClassLibDemoTest folder, open the solution in visual studio 2017, add nuget packagesrelated with NUnit (NUnit 3, NUnit Adapter), please change the follwing line in the file called "CodeCoverage.runsettings":

  <SymbolSearchPaths>                
      <Path>C:\VSTest\ClassLibDemoTest\ClassLibDemoTest\bin\Debug</Path> 
      <Path>C:\VSTest\ClassLibDemoTest\ClassLibDemoTestTests\bin\Debug</Path>   
      <!--More paths if required-->
</SymbolSearchPaths> 

Write your own paths in the lines above, the path is almost always bin\debug path in your porject folder under vs solution, follow the steps in this document if you have more questions about this:

https://msdn.microsoft.com/es-cl/library/jj159523.aspx

If you see the xml file lines above you will see my own paths forclass library and test project, but apparently you only need the path of test project.

2) Remember clean and compile solution before run tests in order to discover tests automatically, you can see tests in test explorer window: test -> windows -> test explorer
