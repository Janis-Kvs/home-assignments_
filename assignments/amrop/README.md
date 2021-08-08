# Goal

To create a PHP API capable of generating PNG images with filled rectangles.

## Requirements

- API Responds to an HTTP request, registers a PNG image generation application, and returns its unique identifier.
If the request squares overlap, border on other squares or the edges of the image, and if the request sends data that is not executable in any way (negative, incorrect values, incorrect json structure, etc.), then error messages with data mismatch information should be returned. .

    - Request example:

        ```
        curl -X POST http://your-server/generate-rectangles -d '
        {
            width: 1024, // any positive number within [640, 1920]
            height: 1024, // any positive number within [480, 1080]
            color: '#fff', // any HEX color code
            rectangles: [
                { 
                    id: 'my-id' // any text or number that does not exceed 255 characters and is unique within the entire rectangles array
                    x: 10, // any positive number
                    y: 10, // any positive number
                    height: 100, // any positive number
                    width: 200, // any positive number
                    color: '#000' // any HEX color code
                },
                ...
            ]
        }'
        ```

    - Example of a successful processing response:

        ```
        {
            success: true,
            id: auto-generated-identifier
        }
        ```

    - Example of a failed response (error message structure is open for interpretation):

        ```
        {
            success: false,
            errors: {
                'rectangles_overlap': ['rectangle_id', ...],
                'rectangles_out_of_bounds': ['rectangle_id'],
                'image_doesnt_fit_constraints': ['width'],
                'malformatted_json': []
            }
        }
        ```

- After a manual file call (aka CRON), the oldest image generation application is generated

- Request `curl -X GET http://your-server/generation-status?id=auto-generated-identifier` returns the current state of image generation (pending, failed, in_progress, done)

    - Example "pending":

        ```
        {
            status: 'pending'
            queue_length: 5 // bilžu skaits, kas ir priekšā
        }
        ```

    - Example "failed":  

        ```
        {
            status: 'failed'
            reason: 'item_not_found' //notikusi kāda kļūme
        }
        ```

    - Example "in_progress":  

        ```
        {
            status: 'in_progress'
        }
        ```

    - Example "done":  

        ```
        {
            status: 'done'
            url: 'http://your-server/generated-image-location //bildes url, kurā to var saņemt kā (Content-Type: image/png)
        }
        ```