# About
The purpose of this article is to provide you with **practical, hands-on knowledge** for building a REST API.  
We will walk through the **essential components** required for creating API endpoints, covering both **data input** and **data output** techniques.
## Attributes
In ASP.NET Core, **attributes** define and control API behavior. They are placed above controller methods and provide metadata about how each endpoint should handle requests.

Commonly used attributes include:
- `[HttpGet]`, `[HttpPost]`, `[HttpPut]`, `[HttpDelete]` – Specify the HTTP method for an endpoint
- `[Route("path")]` – Define a custom URL route
- `[FromBody]`, `[FromQuery]`, `[FromForm]` – Control how parameters are bound
- `[Produces("application/json")]` – Specify the response format
## Input Methods
In this section, we explore **how to receive data** in a REST API.  
Different HTTP methods and scenarios require different binding techniques.  
Some inputs can be combined; others are specific to certain request types.
### Form Query
**Query parameters** are appended to the URL and are useful for simple key-value data, especially for GET requests.

``` c#
[HttpGet("FormQuery")]
public string FormQuery([FromQuery] string text)
{
	return $"Your text form Query -> {text}";
}
```
#### Example request (cURL)
``` bash
curl -X 'GET' \
  'https://localhost:7291/api/MyBestApp/QueryExample?text=You_Are_Great' \
  -H 'accept: text/plain'
```
You can also paste  `{Your_URL}/api/MyBestApp/QueryExample?text=You_Are_Great`  
directly into your browser’s address bar.
### From Body
For sending **complex or large amounts of data** (e.g., objects, arrays), we use the request **body**—primarily with POST or PUT methods.
``` c#
[HttpPost("FormBody")]
public string FormBody([FromBody] ExampleRequest request)
{
	return String.Concat(Enumerable.Repeat(request.Text, request.Amount));
}
```
#### Example request (cURL)
```bash
curl -X 'POST' \
  'https://localhost:7291/api/MyBestApp/BodyExample' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "ASP.NET",
  "amount": 5
}'
```
### From Route
Route parameters are **embedded directly in the URL path**.
``` c#
[HttpGet("FormRoute/{text}")]
public string FormRoute(string text)
{
	return $"Your text form Query -> {text}";
}
```
#### Example request (cURL)
```bash
curl -X 'GET' \
  'https://localhost:7291/api/MyBestApp/RouteExample/What%27s_up%3F' \
  -H 'accept: text/plain'
```
As with query parameters, you can also call this endpoint directly in your browser.
## Return types
So far, our examples have returned simple strings. However, **return type choice affects control over HTTP status codes and response formatting**.

Common return patterns:
- **Direct type** (e.g., `string`) – Simple, but limited HTTP status control.
- **`ActionResult<T>`** – Strongly typed response with full HTTP status control.    
- **`IActionResult`** – Flexible return type for varied responses.

``` c#
[HttpPost("FormBodyActionResult")]
public ActionResult<string> FormBodyActionResult([FromBody] ExampleRequest request)
{
	if (request.Amount < 0)
		return new BadRequestObjectResult("Amount must be bigger that 0");

	return Ok(String.Concat(Enumerable.Repeat(request.Text, request.Amount)));
}

[HttpPost("FormBodyIActionResult")]
public IActionResult FormBodyIActionResult([FromBody] ExampleRequest request)
{
	if (request.Amount < 0)
		return new BadRequestObjectResult("Amount must be bigger that 0");

	return Ok(String.Concat(Enumerable.Repeat(request.Text, request.Amount)));
}
```

### !Bonus!: How to upload file
ASP.NET Core supports file uploads using the `[FromForm]` attribute with `IFormFile`.
``` c#
[HttpPost("FileUploadExample")]
public string FromForm(IFormFile file)
{
	return $"Received: {file.FileName}, {file.ContentType}";
}
```
# Summary
We explored the key elements of building a REST API in ASP.NET Core, including defining endpoints with attributes, receiving input from different sources, and returning structured responses. You also learned how to handle files through API endpoints. With these fundamentals, you can start creating functional, flexible, and well-structured APIs.