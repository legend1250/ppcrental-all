Feature: UC011_ChangePassword
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Change Password
	Given I login success with the given username and password
	| Title    |  Value		 |
	| username |   qqqq      |
	| password |   123456    |
	And I go to Change Password page 
	When I input all the following fields
	| Title				| Value     |
	| Password			| 123456    |
	| New Password      | ppc123    |
	| Cofirm Password   | ppc123    |
	And I click Set new Password button
	Then I see a message "Your password has been changed successfully"


Scenario: Input wrong current Password on Change Password page
	Given I Login successfully 
	| Title    |  Value		 |
	| username |   md5       |
	| password |   123456    |
	And I Navigate to Change Pasword page 
	When I input wrong current password
	| Title				| Value     |
	| Password			| 111111    |
	| New Password      | ppc123    |
	| Cofirm Password   | ppc123    |
	And I click Set new Password button
	Then Show a message "Your current password not match with the password you gave"

Scenario: New password does not meet the requirements
Given I login success with my account
	| Title    |  Value		 |
	| username |   md5       |
	| password |   123456    |
	And Go to change password page 
	When I Input a new wrong password 
	| Title				| Value     |
	| Your answer		| 123456789 |
	| Password			| 123456    |
	| New Password      | ad	    |
	| Cofirm Password   | ad		|
	And Click Set new Password button
	Then There will show a message "New Password must be at least 6 characters"

Scenario: Confirm password does not match the new one
	Given I login to my account
	| Title    |  Value		 |
	| username |   md5       |
	| password |   123456    |
	And I navigate to page Change Password
	When I input a wrong cofirm password 
	| Title				| Value     |
	| Your answer		| 123456789 |
	| Password			| 123456    |
	| New Password      | ppc123    |
	| Cofirm Password   | ppp123	|
	And I choose the Set new Password button
	Then It will show a message "RePassword does not match the new password"

Scenario: Current password form is empty
	Given Login success to my account
	| Title    |  Value		 |
	| username |   md5       |
	| password |   123456    |
	And Go to page Change Password
	When I forgot to input current password form
	| Title				| Value     |
	| Your answer		| 123456789 |
	| Password			|		    |
	| New Password      | ppc123    |
	| Cofirm Password   | ppp123	|
	And I click the Set new password button
	Then It show message "Password must not be at least empty"