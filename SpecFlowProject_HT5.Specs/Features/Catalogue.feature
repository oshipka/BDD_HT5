Feature: Catalogue
	A page to find the items that user wants to purchase

@mytag
Scenario Outline: Filter by price
	Given user is on <page>
	When <price range> is clicked 
	Then displayed item prices are within <price range>
	
	Examples: 
	  | page                                                                                                                                                                                                                    | price range  | 
	  | https://www.amazon.com/s?i=specialty-aps&bbn=16225009011&rh=n%3A%2116225009011%2Cn%3A172541&ref=nav_em__nav_desktop_sa_intl_headphones_0_2_5_8                                                                          | Up to $25    | 
	  | https://www.amazon.com/s?i=specialty-aps&bbn=4954955011&rh=n%3A4954955011%2Cn%3A%212617942011%2Cn%3A2237329011&ref=nav_em__nav_desktop_sa_intl_needlework_0_2_8_8                                                       | $25 to $50   | 
	  | https://www.amazon.com/s?i=arts-crafts-intl-ship&bbn=4954955011&rh=n%3A4954955011%2Cn%3A2237329011%2Cn%3A12897241&dc&ds=v1%3AS8eoIH1b2tYPJtbfo3Smp4MjJqey9h9ade%2FjPpuPgs8&qid=1663658193&rnid=2237329011&ref=sr_nr_n_1 | $50 to $100  | 
	  | https://www.amazon.com/s?i=specialty-aps&bbn=16225013011&rh=n%3A%2116225013011%2Cn%3A2975520011&ref=nav_em__nav_desktop_sa_intl_small_animals_0_2_21_8                                                                  | $100 to $200 | 
	  | https://www.amazon.com/s?k=essential+oils&crid=17BVK17PNZXBB&sprefix=essen%2Caps%2C190&ref=nb_sb_ss_ts-doa-p_5_5                                                                                                        | $200 & above | 

Scenario Outline: Search for item
	Given user is on home page
	When <query> is entered in search field
	Then items are shown on catalogue page
	And item names contain <query>

	Examples: 
| query                    |
| cat food                 |
| mug tree                 |
| lithops seeds            |
| candle making supplies   |
| scent diffusers for home |

	