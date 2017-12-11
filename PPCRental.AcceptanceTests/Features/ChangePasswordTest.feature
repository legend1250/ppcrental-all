Feature: ChangePasswordTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Change Password
	Given I'm in Home Page
	And Navigate to Login Page
	And I input UserName and Password
	When I click Log In button
	Then I click  Change Password button
	And I input my answer for security question
	And I click Submit button
	Then Navigate to Set New Password Page
	When I input my current Password, my new Password and Confirm it 
	And I Click Set New Password button
	Then Show "Your password has been changed successfully" message
