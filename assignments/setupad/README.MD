# Task 1

Convert prices in https://reklama.setupad.com to dollars using the current exchange rate from https://exchangeratesapi.io/ API. The script has to work just pasting it to the Dev Tools console. Please upload the script to https://gist.github.com/

# Task 2 

Create Node Expesss API (https://expressjs.com), which would:
1. Have single get route (endoint) with two required parameters (startDate and endDate) and would be accessed via: ```/api/getPriceHistory/{startDate}/{endDate}```
2. getPriceHistory route would use node-fetch to get data from ```https://api.coindesk.com/v1/bpi/historical/close.json?start={startDate}&end={endDate}``` with end/start data from received parameters (example: https://api.coindesk.com/v1/bpi/historical/close.json?start=2020-02-16&end=2020-02-17)
3. Loop through every "bpi" value in CoinDesk response and multiply it by a thousand
4. Return JSON, catch and return errors if there are any

Optional for more points if you could:
1. Write middleware for this route to allow calls from certain IP address only
2. Enable GZIP compression in Express
3. Rate limit endpoint
4. Use async/await instead of callbacks

Upload project to bitbucket or github, make it public and send us a link. We should be able to clone project, install dependencies, call ```/api/getPriceHistory/{startDate}/{endDate}``` to get CoinDesk answer. If you did optional tasks, let us know in project description what to edit to change allowed IP or rate limit.
