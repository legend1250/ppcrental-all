#automated
Feature: UC001_Search
	As a potential customer i want search 
	I want to search for project by a simple phrase
	So that I can easily allocate project by something I remember from them.

Background: 
Given the following project
| PropertyName      | 
| ASA LightT        |     
| CALEDON Tan Phu   | 
| VINH LOC Central  | 
| SAIGONRESE Plaza  | 
| CAPSULE Residence | 
| FLORAL HOA BINH   |
| ORIENT Plaza      |
| RIVA Garden       |
| CITY Gate         |
| MY HUNG Prop 3    |

@web
Scenario: Space should be treated as multiple OR search
	When I search for project by the phrase 'CITY Gate'
	Then the list of found project should contain only: 'CITY Gate'

Scenario: itle should be matched
	When I search for project by the phrase 'gate'
	Then the list of found project should contain only: 'CITY Gate'

