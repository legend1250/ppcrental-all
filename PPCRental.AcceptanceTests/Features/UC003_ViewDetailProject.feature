Feature: UC003_ViewDetailProject
	As a potential customer
	I want to see the details of a project
	So that I can better decide to buy it.
Background: 
Given the following project
        | PropertyName      | Price  | Area | Bedroom | Bathroom | ParkingPlace |
        | ASA LightT        | 71000  | 150  | 3       | 3        | 1            |
        | CALEDON Tan Phu   | 55000  | 130  | 2       | 2        | 1            |
        | VINH LOC Central  | 70000  | 120  | 3       | 2        | 1            |
        | SAIGONRESE Plaza  | 90000  | 200  | 3       | 3        | 1            |
        | CAPSULE Residence | 49500  | 130  | 2       | 2        | 1            |
        | FLORAL HOA BINH   | 79000  | 180  | 4       | 4        | 1            |
        | ORIENT Plaza      | 42200  | 100  | 2       | 2        | 1            |
        | RIVA Garden       | 78400  | 168  | 3       | 4        | 1            |
        | CITY Gate         | 120000 | 250  | 4       | 4        | 1            |
        | MY HUNG Prop 3    | 115000 | 280  | 4       | 4        | 1            |

@mytag
Scenario: detail project can be seen
	When I open the details of 'CITY Gate'
	Then the project details should show detail
		