Feature: GameOfLife
	In order to play the game of life
	As a player
	I want to watch the world progress

Scenario: An empty world stays empty
	Given I have an empty world
	When The clock ticks 1 time(s)
	Then the world stays empty

Scenario: A cell with one adjacent cells that cell dies when the clock ticks
	Given I have a cell with 1 adjacent cells
	When The clock ticks 1 time(s)
	Then the cell dies

Scenario: A cell with four adjacent cells that cell dies when the clock ticks
	Given I have a cell with 4 adjacent cells
	When The clock ticks 1 time(s)
	Then the cell dies

Scenario: A cell with two adjacent cells that cell lives when the clock ticks
	Given I have a cell with 2 adjacent cells
	When The clock ticks 1 time(s)
	Then the cell lives

Scenario: A cell with three adjacent cells that cell lives when the clock ticks
	Given I have a cell with 3 adjacent cells
	When The clock ticks 1 time(s)
	Then the cell lives

Scenario: An empty cell with three adjacent cells that cell comes alive when the clock ticks
	Given I have an empty cell with 3 adjacent cells
	When The clock ticks 1 time(s)
	Then the cell lives

Scenario: A Blinker returns to it's original state after two ticks
	Given I have a blinker
	When The clock ticks 2 time(s)
	Then the blinker returns to its original shapre

Scenario: A Toad returns to it's original state after two ticks
	Given I have a toad
	When The clock ticks 2 time(s)
	Then the toad returns to its original shapre
