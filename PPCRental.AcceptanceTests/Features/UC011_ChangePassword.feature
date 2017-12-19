Feature: UC011_ChangePassword
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Change Password
	Given I login success with the given username and password
	| Title    |  Value		 |
	| username |   md5       |
	| password |   123456    |
	And I go to Change Password page 
	When I input all the following fields
	| Title				| Value     |
	| Your answer		| 123456789 |
	| Password			| 123456    |
	| New Password      | 123456    |
	| Cofirm Password   | 123456    |
	And I click Set new Password button
	Then I see a message "Your password has been changed successfully"

#Scenario: Change Password failed with wrong answer for security question
#	Given I login success with the given username and password
#	| Title    |  Value		 |
#	| username |   md5       |
#	| password |   123456    |
#	And I go to Change Password page
#	When I input wrong answer for security question
#	| Title				| Value     |
#	| Your answer		| abcd	    |
#	Then I will see a message "Error! Your answer not match with the answer in database."