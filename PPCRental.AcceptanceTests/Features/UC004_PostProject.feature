﻿Feature: UC004_PostProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add Project Success
	Given I login role Agency
	When I press add project button
	And Navigate to add project page
	When I fill in all the fields 
	And I press submit button
	Then I could see message add success  