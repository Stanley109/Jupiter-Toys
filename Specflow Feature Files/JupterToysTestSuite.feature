Feature: Jupiter Toys Tests
Background: Background name

Scenario: TC01: Verify that error messages is displayed
    Given I am in the Jupiter Toys home page
	When I visit the contact page and click the submit button
	Then I should be able to see the error messages in each missing mandatory fields
	When I populate the mandatory fields and click the submit button
	|Forename	|Email				|Message				|
	|Test		|Test@planit.com	|Hello World!			|
	Then the error message in the contact page form should disappear
	And a confirmation message should display

# 1.	From the home page go to contact page
# 2.	Click submit button
# 3.	Verify error messages
# 4.	Populate mandatory fields
# 5.	Validate errors are gone

# Test case 2:

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




