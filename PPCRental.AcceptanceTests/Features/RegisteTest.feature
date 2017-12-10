Feature: RegisteTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register
	Given In HomePage
	And Navigate to Register Page
	When Input my information
	And Click Submit button
	Then Show successful message
