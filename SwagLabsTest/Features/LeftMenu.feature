Feature: LeftMenu

A short summary of the feature

@tag1
Scenario: Verify that when user add an item into cart and then they click on Reset App State the item will be deleted from the cart
	When I login
		| username      | password     |
		| standard_user | secret_sauce |
	Then I should see the inventory page
	When I choose "Sauce Labs Backpack" product and add click Add to cart button
	Then The button Remove of "Sauce Labs Backpack" item is diplayed
	Then The cart item is displayed with number 1
	When I click on Reset App State
	Then The cart item is displayed without number
	Then The button Remove of "Sauce Labs Backpack" item is change to Add to cart
