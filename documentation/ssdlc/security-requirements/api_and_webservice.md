<h1>Api and WebService<h1>

## Objective

This section serves to verify that any use of trusted service layer APIs such as JSON or XML have adequate authentication and have secured parameters.

Beyond that, it looks for security when interacting with any type of API.


## 1. Generic Web Service Security

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **13.1.1** | Verify that all application components use the same encodings and parsers to avoid parsing attacks that exploit different URI or file parsing behavior that could be used in SSRF and RFI attacks. | 1 | 116 | Valid |
| **13.1.2** | [DELETED, DUPLICATE OF 4.3.1] |  |   | Not Valid |
| **13.1.3** | Verify API URLs do not expose sensitive information, such as the API key, session tokens etc. | 1 |  598 | Valid |
| **13.1.4** | Verify that authorization decisions are made at both the URI, enforced by programmatic or declarative security at the controller or router, and at the resource level, enforced by model-based permissions. | 2 |  285 |  Valid |
| **13.1.5** | Verify that requests containing unexpected or missing content types are rejected with appropriate headers (HTTP response status 406 Unacceptable or 415 Unsupported Media Type). | 2 |  434 | Not Valid |

## Analysis

- 13.1.1: This requirements serves to prevent errors in encoding and parsing to avoid attacks where the user can input special characters in a field to create a structure message and make the system mistankingly show or give important information. See for example Cross-site Scripting.
This requirement is valid for our application and will be implemented by having a robust validation of any input upon arrival.
- 13.1.3: This requirements is to avoid query strings in GET request methods that contains sensitive information and be accessed by the user. This is valid for our application and will be verified by avoiding using sensitive data in URLs
- 13.1.4: This refers to authorization is being applied at the correct times, to avoid users taking actions that they do not have permission to do. This is valid for our application and will be implemented by guaranteeing that authorization occurs at the correct times, such as a SQL query request or a function call.
- 13.1.5: This requirement refers to security problems when there is no verification on the file type that is being uploaded, allowing users to upload malicious contect to gain access to private data, or to run commands in the application server. This is not valid to our application, as the application will never allow the user to upload a file of any type.

## 2. RESTful Web Service

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **13.2.1** | Verify that enabled RESTful HTTP methods are a valid choice for the user or action, such as preventing normal users using DELETE or PUT on protected API or resources. | 1 | 650 | Valid |
| **13.2.2** | Verify that JSON schema validation is in place and verified before accepting input. | 1 | 20 | Valid |
| **13.2.3** | Verify that RESTful web services that utilize cookies are protected from Cross-Site Request Forgery via the use of at least one or more of the following: double submit cookie pattern, CSRF nonces, or Origin request header checks. | 1 |  352 | Valid |
| **13.2.4** | [DELETED, DUPLICATE OF 11.1.4] |  |   | Not Valid |
| **13.2.5** | Verify that REST services explicitly check the incoming Content-Type to be the expected one, such as application/xml or application/json. | 2 |  436 | Valid |
| **13.2.6** | Verify that the message headers and payload are trustworthy and not modified in transit. Requiring strong encryption for transport (TLS only) may be sufficient in many cases as it provides both confidentiality and integrity protection. Per-message digital signatures can provide additional assurance on top of the transport protections for high-security applications but bring with them additional complexity and risks to weigh against the benefits. | 2 |  345 | Not Valid |

## Analysis
- 13.2.1: Besides disabling PUT, POST and DEL requests from the user, the application should also have a protection mechanism that verifies GET requests that might potentially contain ways of creating/deleting sensitive data. This is valid for our application and should be applied by verifying user privilage and blocking GET requests to alter data.
- 13.2.2: Guaranteeing that data input such as JSON schema is valid before accepting the input to protect the application against unintended behaviour. This is valid for our applciation and should be implemented with a JSON Schema validation before accepting the input.
- 13.2.3: If the application does not guarantee that a request is intentially sent, then it opens the possibility for a user to trick the client into treating the request as valid, and providing secretive data to them. See Cross-Site Request Forgery. This is valid for our application, and will be applied by the use of a "double submitted cookie" method that generates a random value as a cookie in the user machine and requires that value to validate any request made by it.
- 13.2.5: Makes sure that the type of the content is the same as expected, to avoid unintended behaviour. Is valid to the application, should be implemented with a content-type validation.
- 13.2.6: This requirement happens when the data is not authenticated, and therefore the system might be prone to accept invalid data. This is not valid to our application, as most data retrieved will be user specific, and will not communicate with the rest of the data of the application.

## 3. SOAP Web Service

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **13.3.1** | Verify that XSD schema validation takes place to ensure a properly formed XML document, followed by validation of each input field before any processing of that data takes place. | 1 | 20 | Valid |
| **13.3.2** | Verify that the message payload is signed using WS-Security to ensure reliable transport between client and service. | 2 | 345 | Not Valid |

## Analysis
- 13.3.1: This requirement specifies that all properties in a XML input should be validated before any process with that data takes place. This is valid for our application and should be applied by validating each property based on the business rules defined in the project before using the data.
- 13.3.2: When the origin of the data is not validated beforehand, the application can accept invalid data. This does not seem necessary for our application considering the scope of the aggregated data that will be retrieved from users.

## 4. GraphQL

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **13.4.1** | Verify that a query allow list or a combination of depth limiting and amount limiting is used to prevent GraphQL or data layer expression Denial of Service (DoS) as a result of expensive, nested queries. For more advanced scenarios, query cost analysis should be used. | 1 | 770 | Valid |
| **13.4.2** | Verify that GraphQL or other data layer authorization logic should be implemented at the business logic layer instead of the GraphQL layer. | 2 | 285 | Valid |

## Analysis
- 13.4.1: When no limit is applied to a query, that query can be used in an DDoS attack to throttle the system. This is valid to our application, and will be implemented by adding a limit to the minimum and maximum expected load for the system, as well as specific behaviour to allow the system to deal with situations where resources are near it's limits.
- 13.4.2: For this, authorization not done in logic and instead applied at the data layer can cause malicious attacks to reach sensitive data. This applies to our application, where the authorization for data requests will be done at business logic level.