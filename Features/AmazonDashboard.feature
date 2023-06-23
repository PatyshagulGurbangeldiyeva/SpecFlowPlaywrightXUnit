Feature: Dashboard functionality

Background:  user navigates to Amazon Dashboard

@smoke
Scenario: Amazon Dashboard
	
	Given user sees tabs
	| tabs             |
	| Clinic           |
	| Best Sellers     |
	| Customer Service |
	#When the two numbers are added
	#Then the result should be 120