
# Architecture, Design and Threat

### Secure Software Development Lifecycle

|    #    | Description                                                                                                                                                                                                                                               | ASVS Level | CWE  |   Valid   | Implementation Plan                                                                                                                                                              |
|:-------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:----:|:---------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **1.1** | Verify the use of a secure software development lifecycle that addresses security in all stages of development.                                                                                                                                           |     2      |      |   Valid   | Implement a secure software development lifecycle that addresses security in all stages of development.                                                                          |
| **1.2** | Verify the use of threat modeling for every design change or sprint planning to identify threats, plan for countermeasures, facilitate appropriate risk responses, and guide security testing.                                                            |     2      | 1053 |   Valid   | Use threat modeling for every design change or sprint planning to identify threats, plan for countermeasures, facilitate appropriate risk responses, and guide security testing. |
| **1.3** | Verify that all user stories and features contain functional security constraints, such as "As a user, I should be able to view and edit my profile. I should not be able to view or edit anyone else's profile                                           |     2      | 1110 |   Valid   | Ensure that all user stories and features contain functional security constraints.                                                                                               |
| **1.4** | Verify documentation and justification of all the application's trust boundaries, components, and significant data flows.                                                                                                                                 |     2      | 1059 |   Valid   | Document and justify all the application's trust boundaries, components, and significant data flows.                                                                             |
| **1.5** | Verify definition and security analysis of the application's high-level architecture and all connected remote services. ([C1](https://owasp.org/www-project-proactive-controls/#div-numbering))                                                           |     2      | 1059 |   Valid   | Define and analyze the security of the application's high-level architecture and all connected remote services.                                                                  |
| **1.6** | Verify implementation of centralized, simple (economy of design), vetted, secure, and reusable security controls to avoid duplicate, missing, ineffective, or insecure controls. ([C10](https://owasp.org/www-project-proactive-controls/#div-numbering)) |     2      | 637  | Non-Valid |                                                                                                                                                                                  |
| **1.7** | Verify availability of a secure coding checklist, security requirements, guideline, or policy to all developers and testers.                                                                                                                              |     2      | 637  |   Valid   | Make a secure coding checklist, security requirements, guideline, or policy available to all developers and testers.                                                             |

### Authentication Architecture

|    #    | Description                                                                                                                                                                                                                                                     | ASVS Level | CWE |   Valid   | Implementation Plan                                                                                                                                                                                       |
|:-------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:---------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **2.1** | Verify the use of unique or special low-privilege operating system accounts for all application components, services, and servers. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering))                                                      |     2      | 250 |   Valid   | Use unique or special low-privilege operating system accounts for all application components, services, and servers.                                                                                      |
| **2.2** | Verify that communications between application components, including APIs, middleware and data layers, are authenticated. Components should have the least necessary privileges needed. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering)) |     2      | 306 |   Valid   | Authenticate communications between application components, including APIs, middleware and data layers. Components should have the least necessary privileges needed.                                     |
| **2.3** | Verify that the application uses a single vetted authentication mechanism that is known to be secure, can be extended to include strong authentication, and has sufficient logging and monitoring to detect account abuse or breaches.                          |     2      | 306 |   Valid   | Use a single vetted authentication mechanism that is known to be secure, can be extended to include strong authentication, and has sufficient logging and monitoring to detect account abuse or breaches. |
| **2.4** | Verify that all authentication pathways and identity management APIs implement consistent authentication security control strength, such that there are no weaker alternatives per the risk of the application.                                                 |     2      | 306 | Non-Valid |                                                                                                                                                                                                           |

### Access Control Architecture

|    #    | Description                                                                                                                                                                                                                                                                                                   | ASVS Level | CWE |     Valid      | Implementation Plan                                                                                                                                                                                    |
|:-------:|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:--------------:|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **4.1** | Verify that trusted enforcement points such as at access control gateways, servers, and serverless functions enforce access controls. Never enforce access controls on the client.                                                                                                                            |     2      | 602 |   Non-Valid    |                                                                                                                                                                                                        |
| **4.2** | NA                                                                                                                                                                                                                                                                                                            |     2      | 284 | Not Applicable |                                                                                                                                                                                                        |
| **4.3** | NA                                                                                                                                                                                                                                                                                                            |     2      | 272 | Not Applicable |                                                                                                                                                                                                        |
| **4.4** | Verify the application uses a single and well-vetted access control mechanism for accessing protected data and resources. All requests must pass through this single mechanism to avoid copy and paste or insecure alternative paths. ([C7](https://owasp.org/www-project-proactive-controls/#div-numbering)) |     2      | 284 |   Non-Valid    |                                                                                                                                                                                                        |
| **4.5** | Verify that attribute or feature-based access control is used whereby the code checks the user's authorization for a feature/data item rather than just their role. Permissions should still be allocated using roles. ([C7](https://owasp.org/www-project-proactive-controls/#div-numbering))                |     2      | 275 |     Valid      | Use attribute or feature-based access control whereby the code checks the user's authorization for a feature/data item rather than just their role. Permissions should still be allocated using roles. |

### Input and Output Architecture

|    #    | Description                                                                                                                                                                                                                                                                       | ASVS Level | CWE  |   Valid   | Implementation Plan                                                                                                                                                   |
|:-------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:----:|:---------:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **5.1** | Verify that input and output requirements clearly define how to handle and process data based on type, content, and applicable laws, regulations, and other policy compliance.                                                                                                    |     2      | 1029 |   Valid   | Clearly define input and output requirements on how to handle and process data based on type, content, and applicable laws, regulations, and other policy compliance. |
| **5.2** | Verify that serialization is not used when communicating with untrusted clients. If this is not possible, ensure that adequate integrity controls (and possibly encryption if sensitive data is sent) are enforced to prevent deserialization attacks including object injection. |     2      | 502  | Non-Valid |                                                                                                                                                                       |
| **5.3** | Verify that input validation is enforced on a trusted service layer. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering))                                                                                                                                      |     2      | 602  | Non-Valid |                                                                                                                                                                       |
| **5.4** | Verify that output encoding occurs close to or by the interpreter for which it is intended. ([C4](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))                                                                                                 |     2      | 116  | Non-Valid |                                                                                                                                                                       |

### Cryptographic Architecture

|    #    | Description                                                                                                                                                                     | ASVS Level | CWE |   Valid   | Implementation Plan                                                                                                     |
|:-------:|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:---------:|:------------------------------------------------------------------------------------------------------------------------|
| **6.1** | Verify that there is an explicit policy for management of cryptographic keys and that a cryptographic key lifecycle follows a key management standard such as NIST SP 800-57.   |     2      | 320 | Non-Valid |                                                                                                                         |
| **6.2** | Verify that consumers of cryptographic services protect key material and other secrets by using key vaults or API based alternatives.                                           |     2      | 320 | Non-Valid |                                                                                                                         |
| **6.3** | Verify that all keys and passwords are replaceable and are part of a well-defined process to re-encrypt sensitive data.                                                         |     2      | 320 |   Valid   | Ensure that all keys and passwords are replaceable and are part of a well-defined process to re-encrypt sensitive data. |
| **6.4** | Verify that the architecture treats client-side secrets--such as symmetric keys, passwords, or API tokens--as insecure and never uses them to protect or access sensitive data. |     2      | 320 | Non-Valid |                                                                                                                         |

### Error, Logging and Auditing Architecture

|    #    | Description                                                                                                                                                                                        | ASVS Level | CWE  | Valid | Implementation Plan                                                                                     |
|:-------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:----:|:-----:|:--------------------------------------------------------------------------------------------------------|
| **7.1** | Verify that a common logging format and approach is used across the system. ([C9](https://owasp.org/www-project-proactive-controls/#div-numbering))                                                |     2      | 1009 | Valid | Use a common logging format and approach across the system.                                             |
| **7.2** | Verify that logs are securely transmitted to a preferably remote system for analysis, detection, alerting, and escalation. ([C9](https://owasp.org/www-project-proactive-controls/#div-numbering)) |     2      |      | Valid | Securely transmit logs to a preferably remote system for analysis, detection, alerting, and escalation. |

### Data Protection and Privacy Architecture

|    #    | Description                                                                                                                                                                                                                                              | ASVS Level | CWE | Valid |                                                                                                       Implementation Plan                                                                                                       |
|:-------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:-----:|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|
| **8.1** | Verify that all sensitive data is identified and classified into protection levels.                                                                                                                                                                      |     2      |     | Valid |                                                                                Identify and classify all sensitive data into protection levels.                                                                                 |
| **8.2** | Verify that all protection levels have an associated set of protection requirements, such as encryption requirements, integrity requirements, retention, privacy and other confidentiality requirements, and that these are applied in the architecture. |     2      |     | Valid | Associate all protection levels with a set of protection requirements, such as encryption requirements, integrity requirements, retention, privacy and other confidentiality requirements, and apply these in the architecture. |

### Communications Architecture

|    #    | Description                                                                                                                                                                                                                                    | ASVS Level | CWE |   Valid   | Implementation Plan                                                                                                                                      |
|:-------:|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:---------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------|
| **9.1** | Verify the application encrypts communications between components, particularly when these components are in different containers, systems, sites, or cloud providers. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering)) |     2      | 319 | Non-Valid |                                                                                                                                                          |
| **9.2** | Verify that application components verify the authenticity of each side in a communication link to prevent person-in-the-middle attacks. For example, application components should validate TLS certificates and chains.                      |     2      | 295 |   Valid   | Verify the authenticity of each side in a communication link to prevent person-in-the-middle attacks. For example, validate TLS certificates and chains. |

### Malicious Software Architecture

|    #     | Description                                                                                                                                                                                                                                                      | ASVS Level | CWE | Valid |                                                                                                              Implementation Plan                                                                                                               |
|:--------:|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:-----:|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|
| **10.1** | Verify that a source code control system is in use, with procedures to ensure that check-ins are accompanied by issues or change tickets. The source code control system should have access control and identifiable users to allow traceability of any changes. |     2      | 284 | Valid | Use a source code control system, with procedures to ensure that check-ins are accompanied by issues or change tickets. The source code control system should have access control and identifiable users to allow traceability of any changes. |

### Business Logic Architecture

|    #     | Description                                                                                                                                                                                      | ASVS Level | CWE  |   Valid   |                                                                 Implementation Plan                                                                  |
|:--------:|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:----:|:---------:|:----------------------------------------------------------------------------------------------------------------------------------------------------:|
| **11.1** | Verify the definition and documentation of all application components in terms of the business or security functions they provide.                                                               |     2      | 1059 |   Valid   |                     Define and document all application components in terms of the business or security functions they provide.                      |
| **11.2** | Verify that all high-value business logic flows, including authentication, session management and access control, do not share unsynchronized state.                                             |     2      | 362  |   Valid   | Ensure that all high-value business logic flows, including authentication, session management and access control, do not share unsynchronized state. |
| **11.3** | Verify that all high-value business logic flows, including authentication, session management and access control are thread safe and resistant to time-of-check and time-of-use race conditions. |     2      | 367  | Non-Valid |                                                                                                                                                      |

### Secure File Upload Architecture

|    #     | Description                                                                                                                                                                                                                                                                                                                                       | ASVS Level | CWE |     Valid      | Implementation Plan |
|:--------:|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:---:|:--------------:|:-------------------:|
| **12.1** |                                                                                                                                                                                                                                                                                                                                                   |     2      | 552 | Not Applicable |                     |
| **12.2** | Verify that user-uploaded files - if required to be displayed or downloaded from the application - are served by either octet stream downloads, or from an unrelated domain, such as a cloud file storage bucket. Implement a suitable Content Security Policy (CSP) to reduce the risk from XSS vectors or other attacks from the uploaded file. |     2      | 646 | Not Applicable |                     |

### Configuration Architecture

|    #     | Description                                                                                                                                                                                                                                                                                                                                  | ASVS Level | CWE  |     Valid      |                                                                                                                   Implementation Plan                                                                                                                    |
|:--------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------:|:----:|:--------------:|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|
| **14.1** | Verify the segregation of components of differing trust levels through well-defined security controls, firewall rules, API gateways, reverse proxies, cloud-based security groups, or similar mechanisms.                                                                                                                                    |     2      | 923  | Not Applicable |                                                                                                                                                                                                                                                          |
| **14.2** | Verify that binary signatures, trusted connections, and verified endpoints are used to deploy binaries to remote devices.                                                                                                                                                                                                                    |     2      | 494  | Not Applicable |                                                                                                                                                                                                                                                          |
| **14.3** | Verify that the build pipeline warns of out-of-date or insecure components and takes appropriate actions.                                                                                                                                                                                                                                    |     2      | 1104 |   Non-Valid    |                                                                                                                                                                                                                                                          |
| **14.4** | Verify that the build pipeline contains a build step to automatically build and verify the secure deployment of the application, particularly if the application infrastructure is software defined, such as cloud environment build scripts.                                                                                                |     2      |      |     Valid      |           Include a build step in the build pipeline to automatically build and verify the secure deployment of the application, particularly if the application infrastructure is software defined, such as cloud environment build scripts.            |
| **14.5** | Verify that application deployments adequately sandbox, containerize and/or isolate at the network level to delay and deter attackers from attacking other applications, especially when they are performing sensitive or dangerous actions such as deserialization. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering)) |     2      | 265  |     Valid      | Adequately sandbox, containerize and/or isolate application deployments at the network level to delay and deter attackers from attacking other applications, especially when they are performing sensitive or dangerous actions such as deserialization. |
| **14.6** | Verify the application does not use unsupported, insecure, or deprecated client-side technologies such as NSAPI plugins, Flash, Shockwave, ActiveX, Silverlight, NACL, or client-side Java applets.                                                                                                                                          |     2      | 477  |   Non-Valid    |                                                                                                                                                                                                                                                          |



## Extensive Analysis

### ASVS Requirement 1.1.1

**ASVS Requirement Description**: Verify the use of a secure software development lifecycle that addresses security in
all stages of development. ([C1](https://owasp.org/www-project-proactive-controls/#div-numbering))![img.png](img.png)

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication is a critical part of the software development lifecycle.
Ensuring security at this stage can help prevent unauthorized access and protect user data.

**Security Requirement**: The application should implement secure password handling practices such as hashing and
salting, and use secure communication channels for transmitting user credentials.

---

### ASVS Requirement 1.1.2

**ASVS Requirement Description**: Verify the use of threat modeling for every design change or sprint planning to
identify threats, plan for countermeasures, facilitate appropriate risk responses, and guide security testing.

**Related Functional Requirement**: Manage Comic Books (Store Clerk)

**Justification**: The ability for a Store Clerk to manage comic books can introduce potential threats such as
unauthorized access or modification of comic book data. Threat modeling can help identify these threats and plan
appropriate countermeasures.

**Security Requirement**: The application should implement role-based access control to ensure only authorized Store
Clerks can manage comic books. It should also log all actions for audit purposes.

---

### ASVS Requirement 1.1.3

**ASVS Requirement Description**: Verify that all user stories and features contain functional security constraints,
such as "As a user, I should be able to view and edit my profile. I should not be able to view or edit anyone else's
profile"

**Related Functional Requirement**: View Customer Orders (Store Clerk)

**Justification**: The ability for a Store Clerk to view customer orders can potentially expose sensitive customer data.
Functional security constraints can help protect this data.

**Security Requirement**: The application should implement access controls to ensure Store Clerks can only view customer
orders and not other sensitive customer data. It should also anonymize or pseudonymize customer data where possible.

---

### ASVS Requirement 1.1.4

**ASVS Requirement Description**: Verify documentation and justification of all the application's trust boundaries,
components, and significant data flows.

**Related Functional Requirement**: Manage Admin Accounts (Store Manager)

**Justification**: he ability for a Store Manager to manage admin accounts is a significant trust boundary in the
application. Documenting and justifying this trust boundary can help ensure it is properly secured.

**Security Requirement**: The application should implement strong access controls and multi-factor authentication for
Store Managers. It should also log all actions for audit purposes.

---

### ASVS Requirement 1.1.5

**ASVS Requirement Description**: Verify definition and security analysis of the application's high-level architecture
and all connected remote services. ([C1](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement** : Browse Comic Books

**Justification**: The high-level architecture of the application and its connected remote services play a crucial role
in how users browse comic books. Ensuring security in this aspect can help protect the integrity and confidentiality of
the comic book data.

**Security Requirement**: The application should implement secure communication protocols when interacting with remote
services. It should also ensure that all connected remote services are secure and trusted.

---

### ASVS Requirement 1.1.6

**ASVS Requirement Description**: Verify implementation of centralized, simple (economy of design), vetted, secure, and
reusable security controls to avoid duplicate, missing, ineffective, or insecure
controls. ([C10](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: Shopping Cart

**Justification**: The shopping cart functionality involves multiple security controls such as access control, data
validation, and secure data transmission. Implementing centralized, simple, vetted, secure, and reusable security
controls can help ensure the security of this functionality.

**Security Requirement**: The application should implement a centralized security control mechanism that is simple,
vetted, secure, and reusable. This mechanism should be used across all functionalities of the application.

---

### ASVS Requirement 1.1.7

**ASVS Requirement Description**: Verify availability of a secure coding checklist, security requirements, guideline, or
policy to all developers and testers.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves sensitive user data and requires secure coding
practices. Having a secure coding checklist, security requirements, guideline, or policy can help developers and testers
ensure the security of this functionality.

**Security Requirement**: The development team should have access to a secure coding checklist, security requirements,
guideline, or policy. This resource should be used throughout the development and testing of the application.

---

### ASVS Requirement 1.2.1

**ASVS Requirement Description**: Verify the use of unique or special low-privilege operating system accounts for all
application components, services, and servers. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: Manage Admin Accounts (Store Manager)

**Justification**: The management of admin accounts is a sensitive operation that requires secure access control. Using
unique or special low-privilege operating system accounts can help ensure the security of this operation.

**Security Requirement**: The application should use unique or special low-privilege operating system accounts for all
its components, services, and servers. This should be enforced especially in functionalities that involve sensitive
operations such as the management of admin accounts.

---

### ASVS Requirement 1.2.2

**ASVS Requirement Description**: Verify that communications between application components, including APIs, middleware
and data layers, are authenticated. Components should have the least necessary privileges
needed. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: Place Orders

**Justification**: The process of placing orders involves communication between various application components. Ensuring
that these communications are authenticated can help prevent unauthorized access and manipulation of order data.

**Security Requirement**: The application should implement secure and authenticated communication channels between its
components. It should also enforce the principle of least privilege to limit the capabilities of each component.

---

### ASVS Requirement 1.2.3

**ASVS Requirement Description**: Verify that the application uses a single vetted authentication mechanism that is
known to be secure, can be extended to include strong authentication, and has sufficient logging and monitoring to
detect account abuse or breaches.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication is a critical functionality that requires a secure and vetted
authentication mechanism. This can help prevent unauthorized access and protect user data.

**Security Requirement**: The application should use a single, vetted, and secure authentication mechanism. It should
also implement sufficient logging and monitoring to detect and respond to account abuse or breaches.

---

### ASVS Requirement 1.2.4

**ASVS Requirement Description**: Verify that all authentication pathways and identity management APIs implement
consistent authentication security control strength, such that there are no weaker alternatives per the risk of the
application.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves multiple authentication pathways and identity
management APIs. Ensuring that these pathways and APIs implement consistent authentication security control strength can
help prevent unauthorized access and protect user data.

**Security Requirement**: The application should implement consistent authentication security control strength across
all authentication pathways and identity management APIs. It should not provide any weaker alternatives.

---

### ASVS Requirement 1.4.1

**ASVS Requirement Description**: Verify that trusted enforcement points such as at access control gateways, servers,
and serverless functions enforce access controls. Never enforce access controls on the client.

**Related Functional Requirement**: Manage Admin Accounts (Store Manager)

**Justification**: The management of admin accounts is a sensitive operation that requires trusted enforcement points to
enforce access controls. This can help prevent unauthorized access and manipulation of admin account data.

**Security Requirement**: The application should enforce access controls at trusted enforcement points such as access
control gateways, servers, and serverless functions. It should never enforce access controls on the client.

---

### ASVS Requirement 1.4.4

**ASVS Requirement Description**: Verify the application uses a single and well-vetted access control mechanism for
accessing protected data and resources. All requests must pass through this single mechanism to avoid copy and paste or
insecure alternative paths. ([C7](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: Manage Admin Accounts (Store Manager)

**Justification**: The management of admin accounts involves accessing protected data and resources. Using a single and
well-vetted access control mechanism can help ensure the security of this operation.

**Security Requirement**: The application should use a single and well-vetted access control mechanism for all its
functionalities. All requests should pass through this mechanism to avoid insecure alternative paths.

---

### ASVS Requirement 1.5.1

**ASVS Requirement Description**: Verify that input and output requirements clearly define how to handle and process
data based on type, content, and applicable laws, regulations, and other policy compliance.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves handling and processing user data. Clearly defining
input and output requirements can help ensure the security and compliance of this operation.

**Security Requirement**: The application should clearly define how to handle and process user data during registration
and authentication. It should comply with applicable laws, regulations, and other policy compliance.

---

### ASVS Requirement 1.5.2

**ASVS Requirement Description**: Verify that serialization is not used when communicating with untrusted clients. If
this is not possible, ensure that adequate integrity controls (and possibly encryption if sensitive data is sent) are
enforced to prevent deserialization attacks including object injection.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves communication with clients. Ensuring that serialization
is not used or that adequate integrity controls are enforced can help prevent deserialization attacks.

**Security Requirement**: The application should not use serialization when communicating with untrusted clients during
registration and authentication. If this is not possible, it should enforce adequate integrity controls and possibly
encryption if sensitive data is sent.

---

### ASVS Requirement 1.5.3

**ASVS Requirement Description**: Verify that input validation is enforced on a trusted service
layer. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves input from users. Enforcing input validation on a
trusted service layer can help prevent common security vulnerabilities such as injection attacks.

**Security Requirement**: The application should enforce input validation on a trusted service layer during registration
and authentication. It should validate user inputs to prevent common security vulnerabilities.

---

### ASVS Requirement 1.5.4

**ASVS Requirement Description**: Verify that output encoding occurs close to or by the interpreter for which it is
intended. ([C4](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))

**Related Functional Requirement**: Browse Comic Books, Search and Filter Comic Books

**Justification**: These functionalities involve displaying data to the user, which requires output encoding to prevent
cross-site scripting (XSS) attacks.

**Security Requirement**: The application should implement output encoding close to or by the interpreter for which it
is intended, to ensure that any data displayed to the user is properly encoded and safe from XSS attacks.

---

### ASVS Requirement 1.6.1

**ASVS Requirement Description**: Verify that there is an explicit policy for management of cryptographic keys and that
a cryptographic key lifecycle follows a key management standard such as NIST SP 800-57.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves the use of cryptographic keys for secure password
storage and transmission. An explicit policy for the management of these keys, following a standard such as NIST SP
800-57, can help ensure their secure usage and lifecycle management.

**Security Requirement**: The application should have an explicit policy for the management of cryptographic keys,
following a standard such as NIST SP 800-57.

---

### ASVS Requirement 1.6.2

**ASVS Requirement Description**: Verify that consumers of cryptographic services protect key material and other secrets
by using key vaults or API based alternatives.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves the use of key material and other secrets. Protecting
these by using key vaults or API based alternatives can help ensure their security.

**Security Requirement**: The application should protect key material and other secrets used in User Registration and
Authentication by using key vaults or API based alternatives.

---

### ASVS Requirement 1.6.3

**ASVS Requirement Description**: Verify that all keys and passwords are replaceable and are part of a well-defined
process to re-encrypt sensitive data.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication involves the use of keys and passwords. Ensuring that these are
replaceable and part of a well-defined process to re-encrypt sensitive data can help maintain security in case of key or
password compromise.

**Security Requirement**: The application should ensure that all keys and passwords used in User Registration and
Authentication are replaceable and are part of a well-defined process to re-encrypt sensitive data.

---

### ASVS Requirement 1.6.4

**ASVS Requirement Description**: Verify that the architecture treats client-side secrets--such as symmetric keys,
passwords, or API tokens--as insecure and never uses them to protect or access sensitive data.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication may involve client-side secrets such as passwords. Treating
these secrets as insecure and never using them to protect or access sensitive data can help prevent unauthorized access.

**Security Requirement**: The application should treat any client-side secrets used in User Registration and
Authentication as insecure and should never use them to protect or access sensitive data.

---

### ASVS Requirement 2.3.3 - Auth0 Supported

**ASVS Requirement Description**: Verify that renewal instructions are sent with sufficient time to renew time bound
authenticators.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that users are given enough time to renew their time
bound authenticators. Timely renewal instructions can help to prevent unauthorized access to user accounts due to
expired authenticators. This requirement is supported and can be customized through the Auth0 API, as described
here (https://auth0.com/docs/libraries/auth0-swift/auth0-swift-save-and-renew-tokens)

**Security Requirement**: Timely Renewal Instructions - The application should send renewal instructions with sufficient
time to renew time bound authenticators.

---

### ASVS Requirement 1.7.1

**ASVS Requirement Description**: Verify that a common logging format and approach is used across the
system. ([C9](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**:

**Justification**:

**Security Requirement**:

---

### ASVS Requirement 1.7.2

**ASVS Requirement Description**: Verify that logs are securely transmitted to a preferably remote system for analysis,
detection, alerting, and escalation. ([C9](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application generate logs that can provide valuable information about the
system's operation and potential security incidents. Secure transmission of these logs to a remote system for analysis,
detection, alerting, and escalation is crucial to maintain the integrity of the logs and ensure timely response to
potential security incidents.

**Security Requirement**: The application should implement secure transmission mechanisms for logs, preferably to a
remote system. This system should be capable of analyzing the logs, detecting potential security incidents, alerting the
appropriate personnel, and escalating the incident as necessary.

---

### ASVS Requirement 1.8.1

**ASVS Requirement Description**: Verify that all sensitive data is identified and classified into protection levels.

**Related Functional Requirement**: User Registration and Authentication, Place Orders, View Invoice, Manage Admin
Accounts (Store Manager)

**Justification**: These functionalities involve handling sensitive data such as user credentials, payment information,
invoice details, and admin account details. Identifying and classifying this data into protection levels can help ensure
appropriate security measures are applied.

**Security Requirement**: The application should identify all sensitive data involved in these functionalities and
classify them into protection levels. Appropriate security measures should be applied based on these classifications.

---

### ASVS Requirement 1.8.2

**ASVS Requirement Description**: Verify that all protection levels have an associated set of protection requirements,
such as encryption requirements, integrity requirements, retention, privacy and other confidentiality requirements, and
that these are applied in the architecture.

**Related Functional Requirement**: User Registration and Authentication, Place Orders, View Invoice, Manage Admin
Accounts (Store Manager)

**Justification**: These functionalities involve handling sensitive data such as user credentials, payment information,
invoice details, and admin account details. Each of these data types can be classified into different protection levels,
each with its own set of protection requirements such as encryption, integrity, retention, privacy, and other
confidentiality requirements. Ensuring that these requirements are applied in the architecture can help maintain the
security and integrity of the data.

**Security Requirement**: The application should identify all protection levels for the sensitive data involved in these
functionalities and associate each level with a set of protection requirements. These requirements should include
encryption, integrity, retention, privacy, and other confidentiality requirements, and should be applied in the
application's architecture.

---

### ASVS Requirement 1.9.1

**ASVS Requirement Description**: Verify the application encrypts communications between components, particularly when
these components are in different containers, systems, sites, or cloud
providers. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve communication between different components, possibly
located in different containers, systems, sites, or cloud providers. Encrypting these communications can help prevent
unauthorized access and data breaches.

**Security Requirement**: The application should implement secure communication protocols, such as HTTPS or TLS, to
encrypt communications between its components. This should be enforced particularly when these components are in
different containers, systems, sites, or cloud providers.

---

### ASVS Requirement 1.9.2

**ASVS Requirement Description**: Verify that application components verify the authenticity of each side in a
communication link to prevent person-in-the-middle attacks. For example, application components should validate TLS
certificates and chains.

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve communication between different components. Verifying
the authenticity of each side in a communication link can help prevent person-in-the-middle attacks. For example,
validating TLS certificates and chains can ensure that the communication is happening between the intended parties.

**Security Requirement**: The application should implement mechanisms to verify the authenticity of each side in a
communication link. This includes validating TLS certificates and chains to prevent person-in-the-middle attacks.

---

### ASVS Requirement 1.10.1

**ASVS Requirement Description**: Verify that a source code control system is in use, with procedures to ensure that
check-ins are accompanied by issues or change tickets. The source code control system should have access control and
identifiable users to allow traceability of any changes.

**Related Functional Requirement**: Manage Comic Books (Store Clerk)

**Justification**: The ability for a Store Clerk to manage comic books involves changes to the source code. Using a
source code control system can help ensure the traceability of these changes.

**Security Requirement**: The application should use a source code control system. All check-ins should be accompanied
by issues or change tickets. The system should have access control and identifiable users to allow traceability of
changes.

---

### ASVS Requirement 1.11.1

**ASVS Requirement Description**: Verify the definition and documentation of all application components in terms of the
business or security functions they provide.

**Related Functional Requirement**: Browse Comic Books

**Justification**: The ability for users to browse comic books involves various application components. Defining and
documenting these components can help ensure their proper functioning and security.

**Security Requirement**: The application should define and document all its components in terms of the business or
security functions they provide. This should include the components involved in browsing comic books.

---

### ASVS Requirement 1.11.2

**ASVS Requirement Description**: Verify that all high-value business logic flows, including authentication, session
management and access control, do not share unsynchronized state.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication is a high-value business logic flow. Ensuring that it does not
share unsynchronized state can help prevent security vulnerabilities.

**Security Requirement**: The application should ensure that all high-value business logic flows, including registration
and authentication, do not share unsynchronized state.

---

### ASVS Requirement 1.11.3

**ASVS Requirement Description**: Verify that all high-value business logic flows, including authentication, session
management and access control are thread safe and resistant to time-of-check and time-of-use race conditions.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: User Registration and Authentication is a high-value business logic flow. Ensuring that it is thread
safe and resistant to race conditions can help prevent security vulnerabilities.

**Security Requirement**: The application should ensure that all high-value business logic flows, including registration
and authentication, are thread safe and resistant to time-of-check and time-of-use race conditions.

---

### ASVS Requirement 1.12.2

**ASVS Requirement Description**: Verify that user-uploaded files - if required to be displayed or downloaded from the
application - are served by either octet stream downloads, or from an unrelated domain, such as a cloud file storage
bucket. Implement a suitable Content Security Policy (CSP) to reduce the risk from XSS vectors or other attacks from the
uploaded file.

**Related Functional Requirement**: Browse Comic Books, Manage Comic Books (Store Clerk)

**Justification**: These functionalities may involve user-uploaded files such as comic book cover images or sample
pages. Serving these files by either octet stream downloads or from an unrelated domain can help prevent unauthorized
access and manipulation. Implementing a suitable Content Security Policy (CSP) can further reduce the risk from XSS
vectors or other attacks from the uploaded file.

**Security Requirement**: The application should serve user-uploaded files required to be displayed or downloaded by
either octet stream downloads or from an unrelated domain, such as a cloud file storage bucket. It should also implement
a suitable Content Security Policy (CSP) to reduce the risk from XSS vectors or other attacks from the uploaded file.

---

### ASVS Requirement 1.14.1

**ASVS Requirement Description**: Verify the segregation of components of differing trust levels through well-defined
security controls, firewall rules, API gateways, reverse proxies, cloud-based security groups, or similar mechanisms.

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve components of differing trust levels. For example,
user-facing components may have a lower trust level than backend components that handle sensitive data. Segregating
these components through well-defined security controls, firewall rules, API gateways, reverse proxies, cloud-based
security groups, or similar mechanisms can help prevent unauthorized access and data breaches.

**Security Requirement**: The application should segregate components of differing trust levels through well-defined
security controls. This may include the use of firewall rules, API gateways, reverse proxies, and cloud-based security
groups. The application should ensure that these mechanisms are properly configured and maintained to provide effective
segregation.

---

### ASVS Requirement 1.14.2

**ASVS Requirement Description**: Verify that binary signatures, trusted connections, and verified endpoints are used to
deploy binaries to remote devices.

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve deploying binaries to remote devices. Using binary
signatures, trusted connections, and verified endpoints can help ensure the integrity and authenticity of the deployed
binaries, and prevent unauthorized access or manipulation.

**Security Requirement**: The application should use binary signatures to verify the integrity of binaries before
deployment. It should also use trusted connections and verified endpoints for deploying binaries to remote devices. This
can help ensure that the binaries are not tampered with during transmission and that they are deployed to the correct
devices.

---

### ASVS Requirement 1.14.3

**ASVS Requirement Description**: Verify that the build pipeline warns of out-of-date or insecure components and takes
appropriate actions.

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve the use of various components, libraries, and
dependencies. Ensuring that these components are up-to-date and secure is crucial for the overall security of the
application. The build pipeline plays a critical role in this process by warning of out-of-date or insecure components
and taking appropriate actions such as updating the components or failing the build.

**Security Requirement**: The application's build pipeline should be configured to warn of out-of-date or insecure
components. It should also be set up to take appropriate actions in response to such warnings, such as updating the
components, failing the build, or notifying the development team.

---

### ASVS Requirement 1.14.4

**ASVS Requirement Description**: Verify that the build pipeline contains a build step to automatically build and verify
the secure deployment of the application, particularly if the application infrastructure is software defined, such as
cloud environment build scripts.

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve the deployment of the application, which should be
secure and automated. This is particularly important if the application infrastructure is software defined, such as
cloud environment build scripts. An automated build step in the build pipeline can help ensure that the application is
built and deployed securely.

**Security Requirement**: The application's build pipeline should contain a build step that automatically builds and
verifies the secure deployment of the application. This should be enforced particularly if the application
infrastructure is software defined. The build step should include checks for common security issues and should fail if
any issues are detected.

---

### ASVS Requirement 1.14.5

**ASVS Requirement Description**: Verify that application deployments adequately sandbox, containerize and/or isolate at
the network level to delay and deter attackers from attacking other applications, especially when they are performing
sensitive or dangerous actions such as
deserialization. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering))

**Related Functional Requirement**: All functionalities

**Justification**: All functionalities of the application involve deploying the application, which should be adequately
sandboxed, containerized, and/or isolated at the network level. This can help delay and deter attackers from attacking
other applications, especially when they are performing sensitive or dangerous actions such as deserialization.

**Security Requirement**: The application should be deployed in a manner that adequately sandboxes, containerizes,
and/or isolates it at the network level. This can help delay and deter attackers from attacking other applications.
Special attention should be given to sensitive or dangerous actions such as deserialization to ensure they are
adequately protected.

---

### ASVS Requirement 1.14.6

**ASVS Requirement Description**: Verify the application does not use unsupported, insecure, or deprecated client-side
technologies such as NSAPI plugins, Flash, Shockwave, ActiveX, Silverlight, NACL, or client-side Java applets.

**Related Functional Requirement**: Browse Comic Books, Search and Filter Comic Books

**Justification**: These functionalities involve client-side operations that could potentially use unsupported,
insecure, or deprecated technologies. Ensuring that such technologies are not used can help maintain the security and
integrity of the application.

**Security Requirement**: The application should not use unsupported, insecure, or deprecated client-side technologies
such as NSAPI plugins, Flash, Shockwave, ActiveX, Silverlight, NACL, or client-side Java applets. Instead, it should use
modern, secure, and supported technologies for client-side operations.
