# SurveyApp using WebApi Core 2.1, Entity Framework, Angular 7 and Twitter bootstrap
The Survey app allows anonymous user to register to the App by simply entering Nickname. The app allows registered user to answer a number of multiple choices questions of a pre-defined survey and submit answers to the server

This project was generated with following technologies and patterns
#### Technologies:
<li>Angular 7.3.8.</li>
<li>@ngRx store for state management at client side.</li>
<li>Twitter Bootstrap 4.3.1.</li>
<li>Webapi Core 2.1.0</li>
<li>Newtonsoft.Json 12.0.1 for JSON object Serialization</li>
<li>.NET Reflection</li>
<li>EntityFramework Core 2.1.0</li>
<li>EntityFramework Core Data migration</li>

#### Patterns:
<li>Generic Repository</li>
<li>Dependency Injection using .NET Core built-in DI (Microsoft.Extensions.DependencyInjection) </li>
<li>Modular programming using Angular components, directives, services and modules </li>
<li>Angular Reactive Forms </li>


## Development server
<li>Open Command prompt</li>
<li>Navigate to >> root folder (CINSW.SurveyApp)>>AppAngular7</li>
<li>Run `npm Install</li>
<li>Run ng build</li>
<li>Open CINSW.SurveyApp.sln (solution file) in Visual studio</li>
<li>Build Solution</li>
<li>Select IIS Express as a Webserver</li>
<li>Click Run Icon</li>
<li>This will automatically open the url(<a href="http://localhost:53304">http://localhost:53304</a>) with defualt port(53304)</li>
<li>This will render Angular App and navigate dafulat router customer registration view</li>

### Changing Port number:
<li>Select the project(CINSW.SurveyApp) from solution explorer</li>
<li>Right click on the project</li>
<li>Select Properties</li>
<li>Navigate to Debug menu from left side panel</li>
<li>Change the port number in Launch browser section</li>
<li>Change the port number in App Url section</li>
