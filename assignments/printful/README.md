### Requirements

1. Create a persistent file caching mechanism which implements given interface:
https://gist.github.com/briedis/d14c4fd416bab8b8b8b873a8d677a0a6
2. Create a class that connects to Printful's Shipping Rate API
(https://www.printful.com/docs/shipping) and retrieves the list of available shipping
options for given values:
    - Address: 11025 Westlake Dr, Charlotte, North Carolina, 28273
    - Product variant id: 7679
    - Quantity: 2

- API authorization docs: https://www.printful.com/docs
- API Key: 77qn9aax-qrrm-idki:lnh0-fm2nhmp0yca7
3. API results should be cached for five minutes using the previously implemented cache.
4. Cache interface should be constructor-injected in to the service

## Other requirements
- Use Guzzle library for API requests.
- Use Composer for autoloading.
- Avoid using frameworks.
- Avoid using any other packages except Guzzle, PHPUnit

## Notes
- API key in authorization header should be base64 encoded (as stated in the API docs)
