Feature: Addition
	In order to avoid silly mistakes
	As a math idiot
	I want to be able to sum numbers

Scenario: Add no Numbers
	Given I have a calculator
	When I sum an empty string
	Then the calculator should return 0

Scenario: Add a single number 
	Given I have a calculator
	When I sum the string '23'
	Then the calculator should return 23

Scenario: Add two numbers
	Given I have a calculator
	When I sum the string '23, 31'
	Then the calculator should return 54

Scenario: Add many numbers
	Given I have a calculator
	When I sum the string '1,2,3,4'
	Then the calculator should return 10

Scenario: Add many numbers with different separators
	Given I have a calculator
	When I sum the string
	 """ 
    1,2,3 
	4
    """ 
	Then the calculator should return 10

Scenario: Add numbers with invalid separator
	Given I have a calculator
	When I sum the invalid string '1,,2'
	Then an ArgumentException exception is thrown
