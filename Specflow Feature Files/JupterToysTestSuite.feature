@all
Feature: Jupiter Toys Tests
Background: Jupiter Toys verification tests for multiple pages

@tc1
Scenario: TC01: Verify that error messages for the mandatory fields in the cart page are displayed
    Given I visit the Home page
	When I visit the Contact page 
	And I click the Contact page submit button
	Then I should be able to see the error messages in each missing mandatory fields
	When I populate the mandatory fields
	|Forename	|Email				|Message		|
	|Test		|Test@planit.com	|Hello World!	|
	Then the error message in the contact page form should disappear

@tc2
Scenario Outline: TC02: Verify that a successful message is displayed upon correct submission of the form in the cart page

	Given I visit the Home page
	When I visit the Contact page
	And I populate all the mandatory fields with <Forename>, <Email>, and <Message>
	When I click the Contact page submit button
	Then a submit feedback alert message should display
	And a confirmation message should display with the Forename '<Forename>' after the feedback alert message disappears

	Examples:
		| Forename | Email 				  | Message		|
		| Tester1  | Tester1@jupiter.com  | Hello 1!	|
		| Tester2  | Tester2@jupiter.com  | Hello 2!	|
		| Tester3  | Tester3@jupiter.com  | Hello 3!	|
		| Tester4  | Tester4@jupiter.com  | Hello 4!	|
		| Tester5  | Tester5@jupiter.com  | Hello 5!	|

@tc3
Scenario: TC03: Verify that the price of each product, subtotal price of each product and total price are displaying correctly

	Given I visit the Home page
	When I visit the Shop page
	And I add the following products
	|Product		|Price	|Quantity	|
	|Stuffed Frog	|10.99	|2			|
	|Fluffy Bunny	|9.99	|5			|
	|Valentine Bear	|14.99	|3			|
	And I visit the Cart page
	Then I should be able to verify the price of each product
	And I should be able to verify the subtotal price of each product
	And I should be able to verify the total price


