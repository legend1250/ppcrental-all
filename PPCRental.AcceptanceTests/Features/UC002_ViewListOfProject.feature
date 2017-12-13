Feature: UC002_ViewListOfProject
	As a potential customer 
	I want to see list of a project
	So that I can better decide project.
@mytag
Scenario: View List of Project Success
	Given I am in homepage
	When I press property button
	Then I see list of project 
