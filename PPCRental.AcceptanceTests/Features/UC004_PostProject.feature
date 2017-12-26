Feature: UC004_PostProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Post Project failed
	Given Login successful
	And Navigate to Add Project page
	When I input information for a new project
	Then Show message "Avatar is required"
