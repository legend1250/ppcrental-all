Feature: UC008_ForgotPassword
	I have an account 
	I forgot my password
	I want a new password to login to my account

@mytag
Scenario: Success and get new password
	Given I am in Homepage
	And I go to Forgot password page
	When I input all the fields
	And I click Submit button
	Then Show message "Successful reset your password. Your new password is " and new password
