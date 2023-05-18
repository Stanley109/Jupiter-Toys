# Jupiter-Toys
Steps to run the code in the local computer.
Provided that .net framework or .net core is installed as this is coded in C# language:

Step 1: In the command prompt, navigate to this directory.
Step 2: Run the command "dotnet test" or "dotnet test --filter TestCategory=all" to run all 3 test cases.
Step 3: If you want to run individual test case, you can change the filter accordingly "dotnet test --filter TestCategory=tc1" (change filter to tc1,tc2, or tc3 )
Step 4: Once the test run is complete, an HTML report file will be generated under the 'Test Reports' folder.


Tools used in the created framework:
1. Specflow - To use the feature file with the gherkin syntax to make code readable (similar to cucumber in Java)
2. Extent Reports - Reporting tool used to generate a report file under the 'Test Reports'
3. Selenium WebDriver - Library used to automate the test cases by using chromedriver to run the chrome browser
