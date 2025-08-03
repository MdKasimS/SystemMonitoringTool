Hi Folks!

This is a cross - platform system resources monitoring console application. It uses plugin system that follows event-drive architeture.

Resource status pacakges are published and queued to be consumed by logging systems, console, REST API and saving it into database.
Database, REST API, log file is configurable in appsettings.json

Configurable arrangement is created using ConfigurationBuilder from package Microsoft.Extensions.Configuration.

Overview of classes, interfaces interaction is show below

<img width="1387" height="668" alt="image" src="https://github.com/user-attachments/assets/1cf5cc34-2fc2-4002-ac88-eccd4f7b16e5" />



Sample output:

<img width="976" height="515" alt="image" src="https://github.com/user-attachments/assets/a39a99d6-a17b-4312-add8-f9cf4e52d858" />


To run this project
1. Clone the project
2. Install required packages
3. Build the project using  -       dotnet build
4. Run the project using command-   dotnet run
