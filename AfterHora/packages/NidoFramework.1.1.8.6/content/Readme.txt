Nido Framework Version 1.1.8


1. Before you being, you need to read the "Gain Coding Speed with Nido (FREE) Framework .NET/ C#" @http://www.codeproject.com/Articles/698486/Introduction-to-Nido-FREE-Framework-NET-Csharp with special focus on "How can I configure ‘Nido’?"

2. Once you have the basic understanding create a Bll project and use Nuget to install 'NidoFramework'. Then Create a UI project and add reference to NidoFramework.Dll and all other dependancy dlls. 

Note: Visual Studio may add reference to older version of EntityFramework however you may need to manually delete that and add reference to the latest version of EntityFramework which will be installed with NidoFramework.

3. How to use 'tt' files

The nuget installation should have the following main references. 

•EntityFramework.dll (v 6.1)
•EntityFramework.Extended.dll
•EntityFramework.BulkInsert-ef.dll
•RefactorThis.GraphDiff.dll
•EntityFramework.MappingAPI.dll
•CompareNETObjects.dll
•Log4Net.dll

Addtionally, nuget installation will add the following .NET library references

•Microsoft.CSharp
•System.Configuration 
•System.Data.Entity
•System.Data.Entity.Design
•System.Data.Linq
•System.Security
•System.Runtime.Serialization
•System.Web.Extensions
•System.ComponentModel.DataAnnotations

In Solution Explorer, right-click each tt file and choose "Run Custom Tool" to generate the Models, Handlers and DbContext classes. Visual Studio runs the text transformation code of those tt files to produce a set of cs files.

You need to copy those created classes to folders with the name ‘Models’, 'Handlers' and'DB' respectivel. Then delete the file references from each tt file.

4. Nuget will install a 'App.Config' file and you may use those configuration as guide lines to configure Nido Framework for the UI projecct.





