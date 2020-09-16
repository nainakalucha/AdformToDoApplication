# AdformAssessment
    
Name: ToDoApplication

Description:
A rest api project to do CRUD operations for todoitems and  todolists. It includes functionality to create labels which can be assigned to
items or lists. It also includes user management which only allows registered users to acess or create the respective entities. The database connection string is mentioned in appsettings.json.
It also logs each and every request/response or error if any. It has an added support for GraphQL and unit test cases.

Instructions for use:
1. End user should have a valid username/password in [User] table.
2. User should create labels so that it can associate the same with items and lists.
3. After that user can create item or list and associate labels to the same.
4. Navigate to http://localhost:53089/swagger in a browser to play with the Swagger UI.
5. Navigate to http://localhost:53089/playground in browser to play wit graphQL playground
