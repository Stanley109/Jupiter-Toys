@all
Feature: Jupiter Toys Tests
Background: Jupiter Toys verification tests for multiple pages

@tc1
Scenario: TC01: Verify that error messages for the mandatory fields in the cart page are displayed
    Given I am in the Jupiter Toys home page
	When I visit the contact page 
	And I click the submit button
	Then I should be able to see the error messages in each missing mandatory fields
	When I populate the mandatory fields
	|Forename	|Email				|Message				|
	|Test		|Test@planit.com	|Hello World!			|
	Then the error message in the contact page form should disappear
@tc2
Scenario Outline: TC02: Verify that a successful message is displayed upon correct submission of the form in the cart page

	Given I am in the Jupiter Toys home page
	When I visit the contact page
	And I populate all the mandatory fields with <Forename>, <Email>, and <Message>
	When I click the submit button
	Then a submit feedback alert message should display
	And a confirmation message should display with the Forename '<Forename>' after the feedback alert message disappears

	Examples:
		| Forename | Email 				  | Message  |
		| Tester1  | Tester1@jupiter.com  | Hello 1!  |
		| Tester2  | Tester2@jupiter.com  | Hello 2!  |
		| Tester3  | Tester3@jupiter.com  | Hello 3!  |
		| Tester4  | Tester4@jupiter.com  | Hello 4!  |
		| Tester5  | Tester5@jupiter.com  | Hello 5!  |

# 1.	From the home page go to contact page
# 2.	Populate mandatory fields
# 3.	Click submit button
# 4.	Validate successful submission message

# Note: Run this test 5 times to ensure 100% pass rate

# Test case 3: 

# 1.	Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
# 2.	Go to the cart page
# 3.	Verify the subtotal for each product is correct
# 4.	Verify the price for each product
# 5.	Verify that total = sum(sub totals)




