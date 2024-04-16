<h1>Configuration<h1>

## Objective

This section serves to guarantee that the application has an automated build environment and that dependencies are kept in check for deprecation or security problems.

## 1. Build and Deploy

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **14.1.1** | Verify that the application build and deployment processes are performed in a secure and repeatable way, such as CI / CD automation, automated configuration management, and automated deployment scripts. | 2 |  | Valid |
| **14.1.2** | Verify that compiler flags are configured to enable all available buffer overflow protections and warnings, including stack randomization, data execution prevention, and to break the build if an unsafe pointer, memory, format string, integer, or string operations are found. | 2 | 120  | Valid |
| **14.1.3** | Verify that server configuration is hardened as per the recommendations of the application server and frameworks in use. | 2 |  16 | Valid |
| **14.1.4** | Verify that the application, configuration, and all dependencies can be re-deployed using automated deployment scripts, built from a documented and tested runbook in a reasonable time, or restored from backups in a timely fashion. | 2 |   |  Valid |
| **14.1.5** | Verify that authorized administrators can verify the integrity of all security-relevant configurations to detect tampering. | 3 |   | Not Valid |

## Analysis

- 14.1.1: To guarantee that any deployment work done to the application is consistent and repeatable, an automation should be created. This is valid for our application and will be applied with the creation of a github actions.
- 14.1.2: When a input such as a character string does not contain a limitation on length, an user can input more data than the maximum, causing an buffer overflow. This is applicable to our application, the chosen language in which the application will be developed already has built in protection against this happening due to their own memory management.
- 14.1.3: This requirement is valid to our application, it will be followed during the configuration of the application.
- 14.1.4: This criteria serves to guarantee that an application can have it's dependecies reimplemented during deployment and that the time for restoration or runs is reasonable. This is valid for our application and will be guaranteed by having steps in the pipeline to build the application and a backup mechanism in case something goes wrong.
- 14.1.5: Although important in a real case scenario for an e-commerce application, this does not apply to our use case, as all members of the project will have full permissions.

## 2. Dependency

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **14.2.1** | Verify that all components are up to date, preferably using a dependency checker during build or compile time.  | 1 | 1026 | Valid |
| **14.2.2** | Verify that all unneeded features, documentation, sample applications and configurations are removed. | 1 | 1002  | Valid |
| **14.2.3** | Verify that if application assets, such as JavaScript libraries, CSS or web fonts, are hosted externally on a Content Delivery Network (CDN) or external provider, Subresource Integrity (SRI) is used to validate the integrity of the asset. | 1 |  829 | Valid |
| **14.2.4** | Verify that third party components come from pre-defined, trusted and continually maintained repositories. | 2 |  829 |  Valid |
| **14.2.5** | Verify that a Software Bill of Materials (SBOM) is maintained of all third party libraries in use.  | 2 |   | Not Valid |
| **14.2.6** | Verify that the attack surface is reduced by sandboxing or encapsulating third party libraries to expose only the required behaviour into the application.  | 2 | 265  | Valid |

## Analysis

- 14.2.1: To avoid situations where a dependency becomes deprecated and unsafe, it's necessary to always have the dependencies be up to date. This is valid and will be applied by a step in the pipeline that builds the project with the lastest version of any dependency when available.
- 14.2.2: Leaving unneded features or documentations can create unnexpeded entry points into sensitive information. Our project will apply this section, and will comply with it during the development of the project, eliminating any unecessary files.
- 14.2.3: Validation for third party assets such as libraries needs to be validated with SRI. This will be applied in the application by adding a cryptographic hash and the location of the resource so that browsers can compare it with the hash found locally, if they are different, then the resource is ignored.
- 14.2.4: It's important to verify that third party components will have up to date repositories, to avoid the possibility of security risks. This is valid and will be applied to our development throughout the design of the system.
- 14.2.5: This requirement does not seem necessary for our application, so the lack of a SBOM will not define if the library will be used or not.
- 14.2.6: Valid to the application. To avoid sandboxing, our application will only implement functions/behaviour from libraries that will be used.

## 3. Unintended Security Disclosure

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **14.3.1** | [DELETED, DUPLICATE OF 7.4.1]  |  |  | Not Valid |
| **14.3.2** | Verify that web or application server and application framework debug modes are disabled in production to eliminate debug features, developer consoles, and unintended security disclosures. | 1 | 497  | Valid |
| **14.3.3** | Verify that the HTTP headers or any part of the HTTP response do not expose detailed version information of system components. | 1 |  200 | Valid |

## Analysis

- 14.3.2: To avoid the unwanted access of feautures from a debugger, it needs to be disabled for Production environments, this will be  guaranteed by the use of environments variables that define what environment the code is working against, and disable any debugging feature depending if it's on a higher tier environment such as production.
- 14.3.3: To avoid sensitive data to be exposed by a HTTP header, the application should avoid containing more than necessary information. This is valid and will be applied to the application.

## 4. HTTP Security Headers

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **14.4.1** | Verify that every HTTP response contains a Content-Type header. Also specify a safe character set (e.g., UTF-8, ISO-8859-1) if the content types are text/*, /+xml and application/xml. Content must match with the provided Content-Type header.  | 1 | 173 | Valid |
| **14.4.2** | Verify that all API responses contain a Content-Disposition: attachment; filename="api.json" header (or other appropriate filename for the content type). | 1 | 116  | Valid |
| **14.4.3** | Verify that a Content Security Policy (CSP) response header is in place that helps mitigate impact for XSS attacks like HTML, DOM, JSON, and JavaScript injection vulnerabilities. | 1 |  1021 | Valid |
| **14.4.4** | Verify that all responses contain a X-Content-Type-Options: nosniff header.  | 1 | 116 | Valid |
| **14.4.5** | Verify that a Strict-Transport-Security header is included on all responses and for all subdomains, such as Strict-Transport-Security: max-age=15724800; includeSubdomains. | 1 | 523  | Valid |
| **14.4.6** | Verify that a suitable Referrer-Policy header is included to avoid exposing sensitive information in the URL through the Referer header to untrusted parties. | 1 |  116 | Valid |
| **14.4.7** | Verify that the content of a web application cannot be embedded in a third-party site by default and that embedding of the exact resources is only allowed where necessary by using suitable Content-Security-Policy: frame-ancestors and X-Frame-Options response headers. | 1 |  1021 | Valid |

## Analysis

- 14.4.1: This is applicable to our application, a content-type header will be implemented in all HTTP responses.
- 14.4.2: This is applicable to the application, a header with content disposition will be included when applicable.
- 14.4.3: Injection attacks can happen if the application is not restricting what can be rendered in the page, and this may cause users to interact with the application in unintended ways. This is valid to the application, X-Frame-Options will be used in frames to guarantee that injection attacks won't happen.
- 14.4.4: if X-Content-Type-Options: nosniff is not set, then browsers can override content-type headers with MIME sniffing, creating possible vulnerabilities. This is applicable to our application, and will be included as a header in any HTTP response.
- 14.4.5: To inform the browser that the endpoint should only be accessed with HTTPS, the Strict-Transport-Security should be added as a header. This is applicable by the application and will be apply to any HTTP response.
- 14.4.6: A Referrer-Policy defines how much referrer information is sent with the request. This is valid to the application, and every HTTP response will have a Referrer-Policy header that limits the information shown.
- 14.4.7: This requirement is similar to 14.4.3., it will be implemented with a X-Frame-Options that limits what can be rendered inside any given frame.

## 5. HTTP Request Header Validation

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **14.5.1** | Verify that the application server only accepts the HTTP methods in use by the application/API, including pre-flight OPTIONS, and logs/alerts on any requests that are not valid for the application context.  | 1 | 749 |  Valid |
| **14.5.2** | Verify that the supplied Origin header is not used for authentication or access control decisions, as the Origin header can easily be changed by an attacker. | 1 | 346  | Valid |
| **14.5.3** | Verify that the Cross-Origin Resource Sharing (CORS) Access-Control-Allow-Origin header uses a strict allow list of trusted domains and subdomains to match against and does not support the "null" origin. | 1 |  346 | Valid |
| **14.5.4** | Verify that HTTP headers added by a trusted proxy or SSO devices, such as a bearer token, are authenticated by the application.  | 2 | 306 | Valid |

## Analysis

- 14.5.1: To comply with this requirements, and avoid users accessing endpoints that they should not have access to, the only endpoints that will be exposed will be the necessary ones, and they will offer input validation that uninteded access.
- 14.5.2: This will be applied in the application, and Origin header will not be used as a form of authentication in any HTTP request.
- 14.5.3: To restrict the domains in which an application is executed, CORS should be used. This is valid for the application and will be used to avoid cases where "null" origin is accepted or that a domain is not part of the trusted domain list.
- 14.5.4: Authentication tokens will be used by the application with the use of Auth0 to generate and manage an authorization bearer token.