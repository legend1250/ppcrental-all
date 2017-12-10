Feature: UC007_Login-Logout
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: LoginAndLogout
	Given I am in homepage.
	And Navigate to login page.
	When I enter username and password.
	And  Click on login button.
	Then I could see logout button.
	When Click on logout button.
	Then I could see login button.
