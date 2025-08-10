# About
The goal of this article is to provide you with the fundamental knowledge needed to start using ASP.NET. I will explain what ASP.NET, REST, and HTTP are. This article should give you enough theoretical knowledge to start working with ASP.NET.
# What is ASP.NET? 

So, what is ASP.NET? As stated on the official ASP.NET homepage: https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet.

> [!Quote]
> ASP.NET is an open source web framework, created by Microsoft, for building modern web apps and services with .NET.
> 
> ASP.NET is cross platform and runs on Windows, Linux, macOS, and Docker.

# ASP.NET WEB API

The **ASP.NET Web API** is a framework for building HTTP services that can be accessed from a wide range of clients. It integrates seamlessly with the ASP.NET Core pipeline, making it lightweight, fast, and easy to test.

Its key benefits include:
- Automatic routing based on URL patterns
- Built-in support for JSON and XML serialization
- Model binding and validation
- Flexible return type handling
## REST
**REST** (Representational State Transfer) is an architectural style for designing networked applications. It uses HTTP as the communication protocol and emphasizes a stateless, client-server model. REST APIs typically use standard HTTP verbs such as:
- **GET** – Retrieve data
- **POST** – Create new data
- **PUT/PATCH** – Update existing data
- **DELETE** – Remove data

A well-designed REST API is easy to understand, scalable, and can be consumed by any client capable of making HTTP requests.
## HTTP
**HTTP** (Hypertext Transfer Protocol) is the foundation of data communication on the web. In the context of ASP.NET Web API, HTTP provides:
- **Methods (verbs)** to define the action on resources
- **Headers** to send metadata
- **Status codes** to indicate the result of the request (e.g., `200 OK`, `404 Not Found`, `500 Internal Server Error`)
- **Body** to carry data in various formats such as JSON, XML, or plain text
### HTTP Methods and Request Body Usage

Different HTTP methods have different conventions regarding the use of the request body:

| Method     | Typical Use                 | Request Body Allowed?                                                                         | Notes                                                               |
| ---------- | --------------------------- | --------------------------------------------------------------------------------------------- | ------------------------------------------------------------------- |
| **GET**    | Retrieve data               | Not recommended (technically possible, but discouraged and often ignored by servers/browsers) | All data should be sent via query parameters.                       |
| **POST**   | Create new resource         | Yes                                                                                           | Commonly used for sending JSON, XML, or form data in the body.      |
| **PUT**    | Replace a resource entirely | Yes                                                                                           | The body usually contains the full updated resource representation. |
| **DELETE** | Remove a resource           | Rarely used                                                                                   | Spec says a body is allowed, but most implementations ignore it.    |
# Summary
In this article, we discussed what ASP.NET is, covered REST, and reviewed the basics of HTTP. I hope this will help you in working with ASP.NET. In the next article, I will show you how to perform a basic project setup.