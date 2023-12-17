Feature: Calculator

@mytag
Scenario: Calculator Result 
	Given the Systolic number is <Systolic>
	And the Diastolic number is <Diastolic>
	Then the result should be <ExpectedResult>

	Examples: 
		| Systolic | Diastolic | ExpectedResult |
        | 80       | 50        | Low            |
        | 100      | 60        | Ideal          |
        | 120      | 80        | PreHigh        |
		| 160      | 90        | High           |