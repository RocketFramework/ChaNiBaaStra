How to use the Sample Project

1. Open Nido.Common.Sln in Visual Studio
2. Verify that Nido.Common Project and three other projects inside Sample folder are loading successfully
3. Build Nido.Common Project and to see it compiles. The Libraries folder has all required DLLs for this project to run. 

Note: Please note that this version of the project uses EF 6.0 and you need to remove Entity Framework DLL VS 2010 added by default from your projects when creating web projects (ASP.NET or MVC).

4. Compile DemoTest.Bll and verify that it compiles
5. Compile DemoTestApplication, which is the ASP.NET sample project
6. Find the sample database inside DemoTestApplication\Db_Backup folder. You may restore that to your MS SQL database.
7. Change the connection string with the name "SchoolDBContext" to point it to your new DB
8. Run the DemoTestApplication and see whether that it loads the data and display them correctly. The project has many code samples showing you the different data loading options available in Nido.
9. Run the DemoMvc4Application to see if it builds
10. Change the connection strin