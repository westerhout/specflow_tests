Feature: Searching
	In order to find the things I need
	As an entrepeneur
	I want to be able to search on the KvK website


Scenario: Search for company information 
	Given I am on the KvK search page
	When I search for "Westerhout IT"
	Then I should see the trade name "Westerhout IT" displayed


Scenario Outline: Search using a filter
	Given I am on the KvK search page
	When I search for "Ondernemer"
	And I apply filter "<filter>"
	Then I should see "<results>" results
	Examples: 
	| filter                       | results |
	| Handelsregister              | 8800    |
	| Informatie & advies          | 1420    |
	| Bijeenkomsten en groeikansen | 18      |
	| Documenten en formulieren    | 129     |
