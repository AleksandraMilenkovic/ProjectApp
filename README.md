The assignment was:
Create an ASP.NET Web Application using MVC and SQL Server. 
This application should be able to manage projects (you should be able to insert/update/delete projects) via a website. A project has the following properties:
* A name
* A client name
* A location
* A short description
* Public or Private - these are the only 2 states

* Comments - users should be able to leave comments against the project
* A "nice to have" feature would be for the user to be able to upload a picture of the project
The system should manage authentication. There are 3 levels of user with 3 different levels of authorisation: 
* GUEST - can see all public projects and details but cannot see or leave comments
* EMPLOYEE - can see all projects and can add comments
* ADMIN - can create/edit/delete users AND projects
I would suggest that you use ASP.NET MVC 5 or above. We will be testing this against a SQL Server 2014 database - so please use this version if possible. Please remember to provide a backup of your database that we can restore here to check the project runs. Ideally, create the database with the admin user having the following details:
Username: sqladmin
Password: Password1
(If for some reason, you can't do this, please attach some instructions on how you created your database so we can log in and check it).
Create a separate document detailing your thought process
I would also like you to document in a separate file how you approached the task, and why you made certain design or coding decisions.


From the text of the assignment, I decided to sketch the original layout of the Application according to what the application 
should do. I decided on an entity framework because the application is small and EF is more practical. The default user is: 
Username: sqladmin, Password: Password1@. The application was written in C # and Vanilla JS because I am most familiar with these languages. I used MVC Identity for authentication. I decided to use user together with Roles from Identity for saving users in the application since I already have them. I first created a page for admin. I divided it into two tabs, one for editing projects and the other for editing users. Due to good practice, admin cannot register a user and give him a password but just change his username and role. Upon registration, all users receive a GUEST role, and then the admin can transfer them to another role. I did not have enough time to finish deleting functions for projects and users. On the projects page, Guest can view visible projects, while the other two roles can add comments. The only thing left is to do the form validation when saving / editing and security (hiding the link on admin page and admin actions), also I should add username unique validation because the email unique check was removed together with email property.
