Feature: Cart
	

@mytag
Scenario: Change quantity of items
	Given user is on cart
	And user is logged in
	And items are in cart
	When quantity dropdown is clicked
	And value from dropdown is selected
	Then selected item quantity is changed
	And subtotal is recalculated

Scenario: Remove item from cart
	Given user is on cart
	And user is logged in
	And items are in cart
	When delete is clicked
	Then item is removed from cart
	And subtotal is recalculated
		
Scenario: Proceed to checkout from cart
	Given user is on cart
	And user is logged in
	And items are in cart
	When proceed to checkout is clicked
	Then user is redirected to order processing
