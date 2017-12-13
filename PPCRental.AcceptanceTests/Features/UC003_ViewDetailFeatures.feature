Feature: UC003_ViewDetailFeatures
	As a potential customer 
	I want to see the details of a project
	So that I can better decide to buy/ rent it.

@mytag
Scenario: Detail of project can be seen
	Given the following appartment
	When I open the details of CITY Gate
	Then the appartment details should show detail
	
