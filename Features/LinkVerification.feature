@link
Feature: Verify Link funtionality

in this feature we are going to execute all link verification

Background: user navigates to Amazon Dashboard

@regression
Scenario: Verify Amazon icon has link
	Given User sees Amazon icon on dahsboard
	Then Amazon icon has link


@regression
Scenario:Verify selected link is opened on the same window
Given User clicks on Clinic tab
And User navigates Clinic page on the same window
Then User sees AmazonClinic icon and "https://clinic.amazon.com/?nodl=0&ref_=nav_cs_clinics"
