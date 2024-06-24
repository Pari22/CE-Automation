Feature: CreateWorkOrder

A short summary of the feature

@tag1
Scenario: Create a reactive WO for the appropriate ASCM
	Given I have navigated to the Concept Evolution wesbite
	Then the "<Username>" enters a email and password on the Signin page
	Then the user should be signedin to the application
	Then the user selects "<MenuItem>" to create work order
	Then the user enters "<ReporterFirstPart>""<Reporter>""<Postcode>""<Building>""<LocationFirstPart>""<Location>""<ContractFirstPart>""<Contract>""<ProblemFirstPart>""<ProblemType>""<SourceFirstPart>""<Source>" information
	Then the user clicks save and notes the WOID

Examples:
	| Username      | MenuItem              | ReporterFirstPart | Reporter   | Postcode | Building                        | LocationFirstPart | Location                       | ContractFirstPart | Contract                | ProblemFirstPart | ProblemType                   | SourceFirstPart | Source      |
	| WPS TEST TEAM | Work Order Management | Joe               | Joe Bloggs | 620009   | 620009 - Watford Exchange House | 1                 | 1 - Main Corridor - 620009-018 | MFR               | MFR - MITIE FM Reactive | Clock            | Clock \| HS- Change battery - | Email           | Email - DWP |
