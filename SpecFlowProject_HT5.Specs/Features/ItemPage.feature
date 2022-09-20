Feature: ItemPage
	

@mytag
Scenario Outline: Add item to cart
	Given user is on <item page>
	And delivering to United Kingdom
	And item is in stock
	When add to cart is clicked
	Then item is added to cart
	And cart subtotal is shown
	
	Examples: 
	  | item page                                                                                                                                                                                                                                                                                           |
	  | https://www.amazon.com/RESPAWN-110-Racing-Style-Gaming-Chair/dp/B076HTJRMZ/ref=sr_1_4?keywords=gaming+chairs&pd_rd_r=dd0f43fa-773e-4055-8192-02b9cdf642de&pd_rd_w=sJBci&pd_rd_wg=KxAX6&pf_rd_p=12129333-2117-4490-9c17-6d31baf0582a&pf_rd_r=BNAEY3TD59R3V68A2RRQ&qid=1663657908&refresh=1&sr=8-4    |
	  | https://www.amazon.com/JBL-Tune-510BT-Ear-Headphones/dp/B08WM3LMJF/ref=sr_1_10?qid=1663657939&s=electronics&sr=1-10                                                                                                                                                                                 |
	  | https://www.amazon.com/Beginners-Embroidery-Practice-Different-Techniques/dp/B09PH1C3W9/ref=sr_1_7?qid=1663657956&s=arts-crafts-intl-ship&sr=1-7                                                                                                                                                    |
	  | https://www.amazon.com/MMO-Mug-Legendary-Coffee-Ceramic/dp/B07TJZJ996/ref=sr_1_9?keywords=gaming+mugs&pd_rd_r=ff33fe6c-4667-4773-b2e3-20bf0102f71b&pd_rd_w=GmPuq&pd_rd_wg=q1668&pf_rd_p=09483392-9ac6-434a-a3d7-39d83662f54a&pf_rd_r=VX6T3N373KMYE7CZXHHB&qid=1663658033&s=kitchen-intl-ship&sr=1-9 |
	  | https://www.amazon.com/RawChemistry-Pheromone-Cologne-Gift-Set/dp/B07VWKKBPY/ref=sr_1_22?qid=1663657987&s=beauty-intl-ship&sr=1-22                                                                                                                                                                  |

Scenario Outline: Add item to list
	Given user is on <item page>
	And delivering to United Kingdom
	And user is logged in
	And user has shopping list
	When add to list is clicked
	Then item is added to list	
	
	Examples: 
	  | item page                                                                                                                                                                                                                                                                                           |
	  | https://www.amazon.com/RESPAWN-110-Racing-Style-Gaming-Chair/dp/B076HTJRMZ/ref=sr_1_4?keywords=gaming+chairs&pd_rd_r=dd0f43fa-773e-4055-8192-02b9cdf642de&pd_rd_w=sJBci&pd_rd_wg=KxAX6&pf_rd_p=12129333-2117-4490-9c17-6d31baf0582a&pf_rd_r=BNAEY3TD59R3V68A2RRQ&qid=1663657908&refresh=1&sr=8-4    |
	  | https://www.amazon.com/JBL-Tune-510BT-Ear-Headphones/dp/B08WM3LMJF/ref=sr_1_10?qid=1663657939&s=electronics&sr=1-10                                                                                                                                                                                 |
	  | https://www.amazon.com/Beginners-Embroidery-Practice-Different-Techniques/dp/B09PH1C3W9/ref=sr_1_7?qid=1663657956&s=arts-crafts-intl-ship&sr=1-7                                                                                                                                                    |
	  | https://www.amazon.com/MMO-Mug-Legendary-Coffee-Ceramic/dp/B07TJZJ996/ref=sr_1_9?keywords=gaming+mugs&pd_rd_r=ff33fe6c-4667-4773-b2e3-20bf0102f71b&pd_rd_w=GmPuq&pd_rd_wg=q1668&pf_rd_p=09483392-9ac6-434a-a3d7-39d83662f54a&pf_rd_r=VX6T3N373KMYE7CZXHHB&qid=1663658033&s=kitchen-intl-ship&sr=1-9 |
	  | https://www.amazon.com/RawChemistry-Pheromone-Cologne-Gift-Set/dp/B07VWKKBPY/ref=sr_1_22?qid=1663657987&s=beauty-intl-ship&sr=1-22                                                                                                                                                                  |

Scenario Outline: Buy item immediately
	Given user is on <item page>
	And user is logged in
	And item is in stock
	When buy now is clicked
	Then user is redirected to order processing
	
	Examples: 
	| item page                                                                                                                                                                                                                                                                                           |
	| https://www.amazon.com/RESPAWN-110-Racing-Style-Gaming-Chair/dp/B076HTJRMZ/ref=sr_1_4?keywords=gaming+chairs&pd_rd_r=dd0f43fa-773e-4055-8192-02b9cdf642de&pd_rd_w=sJBci&pd_rd_wg=KxAX6&pf_rd_p=12129333-2117-4490-9c17-6d31baf0582a&pf_rd_r=BNAEY3TD59R3V68A2RRQ&qid=1663657908&refresh=1&sr=8-4    |
	| https://www.amazon.com/JBL-Tune-510BT-Ear-Headphones/dp/B08WM3LMJF/ref=sr_1_10?qid=1663657939&s=electronics&sr=1-10                                                                                                                                                                                 |
	| https://www.amazon.com/Beginners-Embroidery-Practice-Different-Techniques/dp/B09PH1C3W9/ref=sr_1_7?qid=1663657956&s=arts-crafts-intl-ship&sr=1-7                                                                                                                                                    |
	| https://www.amazon.com/MMO-Mug-Legendary-Coffee-Ceramic/dp/B07TJZJ996/ref=sr_1_9?keywords=gaming+mugs&pd_rd_r=ff33fe6c-4667-4773-b2e3-20bf0102f71b&pd_rd_w=GmPuq&pd_rd_wg=q1668&pf_rd_p=09483392-9ac6-434a-a3d7-39d83662f54a&pf_rd_r=VX6T3N373KMYE7CZXHHB&qid=1663658033&s=kitchen-intl-ship&sr=1-9 |
	| https://www.amazon.com/RawChemistry-Pheromone-Cologne-Gift-Set/dp/B07VWKKBPY/ref=sr_1_22?qid=1663657987&s=beauty-intl-ship&sr=1-22                                                                                                                                                                  |
 