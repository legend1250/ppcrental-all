Feature: UC006_Register
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register success
	Given I am in homepage
	And Navigate to Register page
	When I input all fields
	And I click Create button
	Then Show message Please enter a valid email address. 

Scenario: Wrong email address
When I input wrong email address		
Then Show message "Please enter a valid email address."

Scenario: Wrong password
When I input wrong password
Then It show message"Minimum four characters and maximun twenty characters, at least one uppercase letter, one lowercase letter and one number."

Scenario:  Empty field
When I  don't input anything to any fields
Then I will see a message"Password must not be null"

Scenario: Wrong confirm password
When I input wrong current password
Then There will massage"Password Mismatched. Re-enter your password"