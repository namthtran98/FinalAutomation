Feature: Add to cart

A short summary of the feature

@tag1
Scenario: Verify that user can remove item after add it into cart
	When I login
		| username      | password     |
		| standard_user | secret_sauce |
	Then I should see the inventory page
	When I choose "Sauce Labs Backpack" product and add click Add to cart button
	Then The button Remove of "Sauce Labs Backpack" item is diplayed
	Then The cart item is displayed with number 1
	When I click on Remove button of item "Sauce Labs Backpack"
	Then The cart item is displayed without number
