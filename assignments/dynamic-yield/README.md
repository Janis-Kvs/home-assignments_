This technical challenge is representative of work a Frontend Developer would perform.

In this role, you will be asked to work on custom projects from our existing clients and we believe the scenario below is indicative of what you will be asked to do.

In general, this is a simple chat client using JavaScript and inter-iframe communication.

## Goal

Build a chrome extension that will track a user’s affinity\* as they browse a website (Urban Outfitters US for this challenge) and save the values to local storage.

- User Affinity: this is basically a score that a user has for different keywords on site. So if a user views 2 womens jackets, they’ll have a score for womens and score for jackets. If that user adds something to cart or purchases, they’ll have higher scores for the keywords associated with that product

## Details:

For the sake of this challenge, affinity will only include the 5 values included on this page: https://www.urbanoutfitters.com/new-arrivals

- Womens
- Mens
- Home
- Lifestyle
- Beauty

## Part One:

As a user browses the site, they should build a score for each of these values
Different interactions should hold different weights
Product page view: increment score by 1
Product added to cart: increment score by 3

Example flow:

- User visits 7 product pages under the category beauty
- User adds one beauty product to cart
- Their score for beauty is now 10
