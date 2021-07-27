[![Build Status](https://dev.azure.com/danishnaglekar/GitHub-CI/_apis/build/status/Power-Maverick.DependencyIdentifier?branchName=main)](https://dev.azure.com/danishnaglekar/GitHub-CI/_build/latest?definitionId=1&branchName=master) [![Nuget](https://img.shields.io/nuget/v/Maverick.Xrm.DependencyIdentifier)](https://www.nuget.org/packages/Maverick.Xrm.DependencyIdentifier/)

[![GitHub issues](https://img.shields.io/github/issues/Power-maveRICK/DependencyIdentifier)](https://github.com/Power-maveRICK/DependencyIdentifier/issues) [![GitHub forks](https://img.shields.io/github/forks/Power-maveRICK/DependencyIdentifier)](https://github.com/Power-maveRICK/DependencyIdentifier/network) [![GitHub stars](https://img.shields.io/github/stars/Power-maveRICK/DependencyIdentifier)](https://github.com/Power-maveRICK/DependencyIdentifier/stargazers) [![GitHub license](https://img.shields.io/github/license/Power-maveRICK/DependencyIdentifier)](https://github.com/Power-maveRICK/DependencyIdentifier/blob/master/LICENSE) [![Nuget](https://img.shields.io/nuget/dt/Maverick.Xrm.DependencyIdentifier)](https://www.nuget.org/packages/Maverick.Xrm.DependencyIdentifier/)

[![Sponsor](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub)](https://github.com/sponsors/Power-Maverick)

[![Twitter Follow](https://img.shields.io/twitter/follow/DanzMaverick?style=social)](https://twitter.com/Danzmaverick) [![Twitter Follow](https://img.shields.io/twitter/follow/LinnZawWin?style=social)](https://twitter.com/LinnZawWin) [![Twitter Follow](https://img.shields.io/twitter/follow/arunvinoth?style=social)](https://twitter.com/arunvinoth)

# Dependency Identifier
An XrmToolBox tool to generate the list of dependent components for multiple tables and export it to an Excel/.CSV file

## Overview
This XrmToolBox tool allows you to generate the list of dependent components for multiple tables and export it to an Excel/.CSV file. Initial idea was coined by [Arun Vinoth](https://twitter.com/arunvinoth) when he approached [Danish N.](https://twitter.com/DanzMaverick); later [Linn Zaw Win](https://twitter.com/LinnZawWin) joined and helped guide the UI/UX design features from a business user perspective.

Checking dependent components using out-of-the-box functionality in the solution explorer can only show dependencies for one table at a time and the list cannot be exported.
To find out the dependent components for multiple tables at one go, you can use this tool to select multiple tables to generate dependencies and export the result to an Excel file.

For more information on the tool [read the blog](https://linnzawwin.blogspot.com/p/dependency-identifier.html) from Linn.

> As more and more component types are getting added to Dataverse; this tool will come in handy when more features will be added to it. Few features are planned to simplify the identification of dependencies in Dataverse.

## Usage
1. Load Entities to view the list of all entities in the connected environment.
2. Select the entities to generate dependencies
3. Choose the Dependency Type (All Dependencies or Dependencies for Delete)
4. Generate Dependencies
5. Export to Excel/CSV if required

## Screenshots
##### Generating Dependencies
![Dependency Identifier](docs/DependencyIdentifier.png)

## Initial Contributors

Name | Function
------------ | -------------
Arun Vinoth | the idea brain 💡
Danish N. | the creator 👩‍💻
Linn Zaw Win | the designer 🔥

