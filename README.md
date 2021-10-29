# Vence_Garage


The project is a simulation of a Garage required in Vence city.

Requirements:
A Vehicle ( Car/MotorBike) can enter the Garage if there is a free spot , if not , the Garage rejects the Vehicle.
The Garage has at least 1 level , and 1 spot , and it's configured using app.config file. To be added later on to AWS Parameter Store.

<b>Backlog ( steps to be done if I have more time )</b>:
- Add CI/CD using GitLab CI/CD.
- Store the configurations in AWS Parameter Store.
- Add ElasticSearch logging combined with Kibana to come up with statistics about the vehicles usually enter the Garage.
- Add filesystem logging feature to investigate any error on production.
- Instead of using In-Memory Database,  we can use a real DB ( DynamoDB , SQL server, PostgresDB...etc )
- Instead of using Console app, I could have implemented a single HTML Page using ( reactJS )  to simulate the car statses in and out of the Garage.
- Containerize the application, to be easily deployable and machine independent.
- Apply CQRS to make entering the Vehile in an API and reading the current vehicles in another API. To enhance performance.


<b>Prerequesits to run the application</b>: 
- OS : Windows 64-bit ( the program is not self-contained )
- .NET Core 3.1 runtime installed 

<b>Deployment Steps</b>:
- Clone the solution to your machine using this command 
git clone https://github.com/shadyyehia/Vence_Garage.git
- open command prompt in the solution folder
- run this command <b> dotnet run </b>, and simulation started. 
- to configure the Garage , please adjust the keys in ConsoleClient.dll.config :  "Garage_Levels" ,  "Garage_Spots_Per_Level" 


<b>To publish the solution</b>
- run this command <b>dotnet publish -o [specific folder]

  
