
# Communication

## Objective

The objective of communication security is none other than to secure the transmission of data between different components, systems, or parties within a web application environment. By this, the confidentiality, integrity, and authenticity of data exchanged over communication channels can be ensured, thereby mitigating the risk of eavesdropping, tampering, or unauthorized access.


###### The majority of these requirements sit on the transport layer of the system, thing that, at first, won't be implemented. This said, although valid, these requirements are not applicable.

## Client Communication Security

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **9.1.1** | Verify that TLS is used for all client connectivity, and does not fall back to insecure or unencrypted communications. ([C8](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 319 | Valid / Not Applicable
| **9.1.2** | Verify using up to date TLS testing tools that only strong cipher suites are enabled, with the strongest cipher suites set as preferred. | 1 | 326 |Valid / Not Applicable
| **9.1.3** | Verify that only the latest recommended versions of the TLS protocol are enabled, such as TLS 1.2 and TLS 1.3. The latest version of the TLS protocol should be the preferred option. | 1 | 326 | Valid / Not Applicable

## Server Communication Security

Server communications are more than just HTTP. Secure connections to and from other systems, such as monitoring systems, management tools, remote access and ssh, middleware, database, mainframes, partner or external source systems &mdash; must be in place. All of these must be encrypted to prevent "hard on the outside, trivially easy to intercept on the inside".

| # | Description | ASVS Level | CWE | Valid
| :---: | :--- | :---: | :---:| :---: |
| **9.2.1** | Verify that connections to and from the server use trusted TLS certificates. Where internally generated or self-signed certificates are used, the server must be configured to only trust specific internal CAs and specific self-signed certificates. All others should be rejected. | 2 | 295 | Valid
| **9.2.2** | Verify that encrypted communications such as TLS is used for all inbound and outbound connections, including for management ports, monitoring, authentication, API, or web service calls, database, cloud, serverless, mainframe, external, and partner connections. The server must not fall back to insecure or unencrypted protocols. |2 | 319 |Valid / Not Applicable
| **9.2.3** | Verify that all encrypted connections to external systems that involve sensitive information or functions are authenticated. | 2 | 287 |Valid / Not Applicable
| **9.2.4** | Verify that proper certification revocation, such as Online Certificate Status Protocol (OCSP) Stapling, is enabled and configured. | 2| 299 |Valid / Not Applicable
| **9.2.5** | Verify that backend TLS connection failures are logged. | 3 | 544 |Valid / Not Applicable


