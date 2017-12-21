Feature: UC004_PostProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Post Project success
	Given Login successful
	And Navigate to Add Project page
	When I input information for a new project
	Then Show message "Success! Add Success,wait for appover."
