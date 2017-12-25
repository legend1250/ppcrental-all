Feature: UC007_Login-Logout
	I have a account 
	I want to login with my account for see news in my ward
	When i don not use i logout my account

@mytag
Scenario: Login  success user
	Given I am in home page
	And Navigate to login page
	When I enter username and password of user
	| username          | password  |
	| SaleNo1@gmail.com | sale123   |
	| Agency@gmail.com  | agency123 |
	| admin@gmail.com   | admin123  |
	| user@gmail.com    | user123   |
	And Click on login button
	Then I could see logout button

Scenario: Login  success sale
	Given I am in home page
	And Navigate to login page
	When I enter username and password of sale
	| username          | password  |
	| SaleNo1@gmail.com | sale123   |
	| Agency@gmail.com  | agency123 |
	| admin@gmail.com   | admin123  |
	| user@gmail.com    | user123   |
	And Click on login button
	Then I could see logout button

Scenario: Login  success agency
	Given I am in home page
	And Navigate to login page
	When I enter username and password of agency
	| username          | password  |
	| SaleNo1@gmail.com | sale123   |
	| Agency@gmail.com  | agency123 |
	| admin@gmail.com   | admin123  |
	| user@gmail.com    | user123   |
	And Click on login button
	Then I could see logout button

Scenario: Login  success admin
	Given I am in home page
	And Navigate to login page
	When I enter username and password of admin
	| username          | password  |
	| SaleNo1@gmail.com | sale123   |
	| Agency@gmail.com  | agency123 |
	| admin@gmail.com   | admin123  |
	| user@gmail.com    | user123   |
	And Click on login button
	Then I could see logout button

Scenario: Logout success
	Given I were login 
	When Click on logout button
	Then I could see login button

Scenario: Login wrong password
	Given I am in home page 
	And Navigate to login page
	When I enter right username and wrong password
	And Click on login button
	Then I could see message wrong password or username

Scenario: Login wrong username
	Given I am in home page 
	And Navigate to login page
	When I enter wrong username and right password
	And Click on login button
	Then I could see message wrong password or username

Scenario: Login wrong username and p
	Given I am in home page 
	And Navigate to login page
	When I enter wrong username and password
	And Click on login button
	Then I could see message wrong password or username