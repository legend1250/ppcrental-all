Feature: Project Search
	As a  visistor
	I want to search for project by a name
	So that I can easily allocate project by something I remember from them.

Background:
	Given the following Project
	| ID | Project Name                                 |
	| 1  | PIS Top Apartment                            |
	| 2  | ICON 56 – Modern Style Apartment             |
	| 3  | PIS Serviced Apartment – Boho Style          |
	| 4  | Bigroom with Riverview                       |
	| 5  | PIS Serviced Apartment – Style 3             |
	| 6  | Vinhomes Central Park L2 – Duong’s Apartment |
	| 7  | Saigon Pearl Ruby Block                      |
	
@mytag
Scenario:Name project should be matched
	When I search for books by the phrase 'ICON'
	Then the list of found project should contain only: 'ICON 56 – Modern Style Apartment'
