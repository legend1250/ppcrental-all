Feature: UC06-Register
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register
	Given In HomePage
	And Navigate to Register Page
	When Input my information
	| Name     | Input              |
	| Username | MR.Hero             |
	| Email    | Hero@gmail.com    |
	| password | 123456             |
	| confirm  | 123456             |
	| address  | 20 Nguyen Khac Nhu |
	| phone    | 0982817690         |
	| answer   | I'm MR.H                 |
	
	And Click Submit button
	Then Show successful message
