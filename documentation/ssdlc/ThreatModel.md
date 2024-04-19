

# Threat Model

## Threat Model Information
- **Application Name** : Comic Book Store
- **Application Version** : 1.0
- **Description** : The design application is going to serve as a tool for the users of the Comic Book Store, enabling them to carry their normal activity, like browse the catalog and make orders (for its final consumers), and manage the books and orders (for clerks), as well as manage accounts (for admin). The application will be divided into 3 parts.
	- UI - Built with JavaScript and React.
	- API - Mainly using C# and its entity framework to manage the database.
	- Database - An SQL Server datastore.
- **Document Owner** : M1C_1 Team
- **Participants** :  M1C_1 Team
- **Reviewer** :  M1C_1 Team

## External Dependencies
|ID|Description|
|--|--|
|1|Auth0 - The application relies on the Auth0 API for account management and authentication.|
|2|sanitize-html _ The application relies on the sanitize-html API for HTML input sanitization.| 
|3|SQL Server| The application relies on the SQl Server to store its data.

## Trust Levels

Trust levels represent the access rights that the application will grant to external entities

|ID|Name|Description|
|--|--|--|
|1|Anonymous Web User|A user who has connected to the website but has not provided valid credentials.|
|2|Authenticate User|A user who has connected to the website and has provided valid credentials.|
|3|Store Clerk| Store Clerks can manage comic books as well as view customer orders
|4|Store Manager| The highest level of privilege. Store Managers can do what normal Store Clerks do and manage admin accounts.


## Entry Points

|ID|Name|Description|Trust Level|
|--|--|--|--|
|1|HTTP/S Port|The application will expose an http/s port in order to its users to access it.|Anyone
|2|Login Page|Every user must be loged in order to access the application and carry on with their use cases.|Anyone
|3|SQL Server| If anything, the credentials could be stolen and the data erased or tampered.

## Exit Points

|ID|Name|Description|Trust Level|
|--|--|--|--|
|1|Login errors|The application will throw errors when invalid user credentials are used|Anyone
|2|Data management and use case errors|The application will throw errors when something goes wrong|Authenticated user, store clerk/manager

## Assets

Assets are essentially targets for attackers, i.e. they are the
reason threats will exist.

|ID|Name|Description|Trust Level|
|--|--|--|--|
|1|User Login Details|The login credentials that a user will use to log into the  website|Anyone
|2|Personal User Data|Sensible user data like address or credit/payment informations|?
