Feature: LoginPage

Scenario Outline: Login with valid credentials
	Given user is on Login
	When <valid email> is entered as username
	And <valid password> is entered as password
	Then login is Successful
	
Examples: 
	| valid email            | valid password     |
	| olenkashipka@gmail.com | VeryStrongPassword |
	
Scenario Outline: Login with invalid email
	Given user is on Login
	When <invalid email> is entered as username
	Then login is Unsuccessful
	
	Examples: 
	  | invalid email                | invalid password | valid email            | valid password     |
	  | jkgfztstvuopdqryjb@nthrl.com | tosrt            | olenkashipka@gmail.com | VeryStrongPassword |
	  | somenot.mail.com             | NormalPassword   | olenkashipka@gmail.com | VeryStrongPassword |
	  | notanemail@                  | tosrt            | olenkashipka@gmail.com | VeryStrongPassword |	
	
Scenario Outline: Login with invalid password
		Given user is on Login
		When <valid email> is entered as username
		And <invalid password> is entered as password
		Then login is Unsuccessful
	
	
Examples: 
	  | invalid email                | invalid password | valid email            | valid password     |
	  | jkgfztstvuopdqryjb@nthrl.com | tosrt            | olenkashipka@gmail.com | VeryStrongPassword |
	  | somenot.mail.com             | NormalPassword   | olenkashipka@gmail.com | VeryStrongPassword |
	  | notanemail@                  | tosrt            | olenkashipka@gmail.com | VeryStrongPassword |