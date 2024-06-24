Feature: Login
As a user, login to ConceptEvolution

@login
Scenario Outline: Login to ConceptEvolution
	Given I have navigated to the Concept Evolution wesbite
	Then the "<Username>" enters a email and password on the Signin page
	Then the user should be signedin to the application

Examples:
	| Username      |
	| WPS TEST TEAM |


