Feature: Checkout

A short summary of the feature

@tag1
Scenario: Verify that when user add to cart an item into cart they can chekout it
	When I login
		| username      | password     |
		| standard_user | secret_sauce |
	Then I should see the inventory page
	When I choose "Sauce Labs Backpack" product and add click Add to cart button
	Then The button Remove of "Sauce Labs Backpack" item is diplayed
	Then The cart item is displayed with number 1
	When I click on cart item
	Then I should see the Cart page
	Then I should see "Sauce Labs Backpack" in the cart
	When I click on Checkout button
	Then I should see the Checkout step one page
	When I input my infomation
		| First Name | Last Name | Postal Code |
		| Nam        | Tran      | 7000        |
	And I click on Continue button
	Then I should see the Checkout step two page
	Then the item in cart is "Sauce Labs Backpack"
	Then the price of item "Sauce Labs Backpack" is correct with the inventory page
	Then the total price is equal the sum of item total and tax
	When I click on Finish button
	Then I should see the Checkout complete page

@tag1
Scenario: Verify that user cannot checkout when cart is empty
	When I login
		| username      | password     |
		| standard_user | secret_sauce |
	Then I should see the inventory page
	When I click on cart item
	Then I should see the Cart page
	Then I cannot click Checkout button