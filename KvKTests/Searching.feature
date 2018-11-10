Feature: Searching
	In order to find the things I need
	As an entrepeneur
	I want to be able to search on the KvK website

@desktop @mobile
Scenario: Search for company information 
	Given I am on the KvK search page
	When I search for company "Westerhout IT"
	Then I should see the trade name "Westerhout IT" displayed



	
