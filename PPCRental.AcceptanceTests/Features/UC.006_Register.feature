Feature: UC.006_Register
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register
	Given I'm in HomePage
	And I choose Register button
	When I input my information and click Submit
	Then the result is successfull and send you back to HomePage
