Feature: ProjectRegister
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register
	Given I'm in HomePage
	And I click Register button
	When I input my information
	And I click Submit button
	Then Show successful message
