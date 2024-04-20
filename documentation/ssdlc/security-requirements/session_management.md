# Session Management

## Objective
Session Management refers to the mechanisms and processes implemented within the application scope to manage and regulate the user's session lifecycle, minimizing the security risk of unauthorized access to physical and logical systems.
A robust Session Management mechanism ensures that only authorized users can access the application's resources and functionalities, while unauthorized access attempts are detected and/or prevented effectively.

In order to achieve this goal, the Application Security Verification Standard (ASVS) requirements were analyzed in order to cover the specific criteria and guidelines outlined by the standard to ensure the security of our web application. These requirements serve as a collection of security controls and best practices that should be taken into account when designing, developing, and testing web applications.

## 1 - Fundamental Session Management Security
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.1.1**  |1|598|Verify the application never reveals session tokens in URL parameters or error messages.|Valid|

### Analysis
- **3.1.1** - This is a valid requirement for our E-commerce web application as it a basic security measure to prevent session hijacking attacks. The session tokens should not be exposed in the URL or error messages.


## 2 - Session Binding
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|---|-------------|-------|
| **3.2.1**  |1|384|Verify the application generates a new session token on user authentication. ([C6](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))| Valid |
| **3.2.2**  |1|331|Verify that session tokens possess at least 64 bits of entropy. ([C6](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))| Valid |
| **3.2.3**  |1|539|Verify the application only stores session tokens in the browser using secure methods such as appropriately secured cookies (see section 3.4) or HTML 5 session storage.| Valid |
| **3.2.4**  |2|331|Verify that session tokens are generated using approved cryptographic algorithms. ([C6](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))| Valid |


### Analysis

- **3.2.1** - This requirement ensures that the application generates a new session token every time a user authenticates. It helps prevent session fixation attacks where an attacker could hijack a user's session. For our web application, this is important to implement as it ensures the security of user sessions, especially during login processes.
- **3.2.2** - This requirement ensures that session tokens possess at least 64 bits of entropy, ensuring they are sufficiently random and difficult to guess. Adequate entropy reduces the risk of session prediction or brute-force attacks. It's applicable to our web app to ensure the robustness of session token generation and overall session security.
- **3.2.3** - This requirement ensures that session tokens should only be stored in the browser using secure methods like secure cookies or HTML5 session storage. This prevents session hijacking through client-side attacks like XSS. Implementing secure storage mechanisms is crucial for protecting session data in our web application, ensuring that session tokens are not vulnerable to interception or tampering.
- **3.2.4** - This requirement ensures the use of approved cryptographic algorithms for generating session tokens. Using weak or deprecated algorithms could lead to vulnerabilities such as session prediction or token manipulation. It's important for our web app to adhere to this requirement to ensure the strength and integrity of session token generation.


## 3 - Session Termination
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.3.1**  |1|613|Verify that logout and expiration invalidate the session token, such that the back button or a downstream relying party does not resume an authenticated session, including across relying parties. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid |
| **3.3.2**  |1|613|If authenticators permit users to remain logged in, verify that re-authentication occurs periodically both when actively used or after an idle period. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid |
| **3.3.3**  |2|613|Verify that the application gives the option to terminate all other active sessions after a successful password change (including change via password reset/recovery), and that this is effective across the application, federated login (if present), and any relying parties.| Not Valid |
| **3.3.4**  |2|613|Verify that users are able to view and (having re-entered login credentials) log out of any or all currently active sessions and devices.| Not Valid |


### Analysis
- **3.3.1** - This requirement ensures that session tokens are invalidated upon logout or expiration, preventing the possibility of session hijacking through the browser's back button or by downstream relying parties. Implementing this requirement helps maintain the integrity of user sessions and prevents unauthorized access to sensitive data. It's essential for  web application to enforce session invalidation upon logout or expiration to mitigate security risks effectively.
- **3.3.2** -This requirement mandates periodic re-authentication for users with persistent sessions, either based on activity or idle period. Periodic re-authentication reduces the risk of unauthorized access to the application, especially for long-lived sessions. Implementing this ensures that users are periodically prompted to re-authenticate, thereby enhancing the overall security of  web application.
- **3.3.3** - This requirement specifies that the application should offer the option to terminate all other active sessions after a successful password change. This ensures that users can effectively manage their active sessions and prevent unauthorized access to their accounts. While this requirement is not valid for our web application, it's still a good practice to consider implementing it to enhance user account security.
- **3.3.4** - This requirement states that users should have the ability to view and logout of any or all currently active sessions and devices. Providing users with visibility and control over their active sessions enhances security by allowing them to identify and terminate any unauthorized sessions. While this requirement is not valid for our web application, it's a valuable feature to consider implementing to improve user account security.

In general, requirements 3.3.3 and 3.3.4 are not valid for our chosen E-commerce web application. As a web commerce application, requirements 3.3.1 and 3.3.2 cover most of the risks associated with session management.

## 4 - Cookie-based Session Management
| #          |  ASVS Level | CWE | Verification Requirement | Valid     | 
|------------|---|------------|-------------|-----------|
| **3.4.1**  |1|614|Verify that cookie-based session tokens have the 'Secure' attribute set. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid     |
| **3.4.2**  |1|1004|Verify that cookie-based session tokens have the 'HttpOnly' attribute set. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))|  Valid|
| **3.4.3**  |1|16|Verify that cookie-based session tokens utilize the 'SameSite' attribute to limit exposure to cross-site request forgery attacks. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid |
| **3.4.4**  |1|16|Verify that cookie-based session tokens use the "__Host-" prefix so cookies are only sent to the host that initially set the cookie.|  Valid |
| **3.4.5**  |1|16|Verify that if the application is published under a domain name with other applications that set or use session cookies that might disclose the session cookies, set the path attribute in cookie-based session tokens using the most precise path possible. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Not Valid |


### Analysis
- **3.4.1** - This requirement mandates that cookie-based session tokens should have the 'Secure' attribute set. When this attribute is set, the browser only sends the cookie over HTTPS connections, ensuring that session data is encrypted during transit. It's crucial for  web application to enforce this requirement to protect session data from being intercepted by attackers during communication.
- **3.4.2** - This requirement specifies that cookie-based session tokens should have the 'HttpOnly' attribute set. With this attribute, the cookie is inaccessible to client-side scripts, reducing the risk of cross-site scripting (XSS) attacks that attempt to steal session data via malicious scripts. Implementing this requirement enhances the security of  web application by limiting the avenues for session hijacking.
- **3.4.3** - This requirement emphasizes the use of the 'SameSite' attribute for cookie-based session tokens to mitigate cross-site request forgery (CSRF) attacks. Setting the 'SameSite' attribute to 'Strict' or 'Lax' helps prevent the browser from sending cookies in cross-origin requests, thus reducing the risk of CSRF attacks. It's important for  web application to implement this requirement to bolster the security of session management.
- **3.4.4** - This requirement suggests using the '__Host-' prefix for cookie-based session tokens, ensuring that cookies are only sent to the host that initially set them. By restricting cookie transmission to the host domain, this measure mitigates the risk of session token leakage to unauthorized parties. Implementing this requirement contributes to the overall security of  web application's session management.
- **3.4.5** -  This requirement advises setting the 'path' attribute in cookie-based session tokens to the most precise path possible, especially if the application is published under a domain with other applications that may use session cookies. This requirement is not valid for our chosen E-commerce web application. As the application is not published under a domain name with other applications that set or use session cookies that might disclose the session cookies, setting the path attribute in cookie-based session tokens using the most precise path possible is not necessary.

## 5 - Token-based Session Management
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.5.1**  |2|290|Verify the application allows users to revoke OAuth tokens that form trust relationships with linked applications.| Valid |
| **3.5.2**  |2|798|Verify the application uses session tokens rather than static API secrets and keys, except with legacy implementations.|  Valid |
| **3.5.3**  |2|345|Verify that stateless session tokens use digital signatures, encryption, and other countermeasures to protect against tampering, enveloping, replay, null cipher, and key substitution attacks.| Valid|


### Analysis
- **3.5.1** - This requirement pertains to the ability of the application to allow users to revoke OAuth tokens that are used to establish trust relationships with linked applications. if there are no plans to integrate with external services that utilize OAuth for authentication and authorization, this requirement may not be immediately applicable. However, it's a good practice to consider implementing this feature to enhance user control over their linked applications and data.
- **3.5.2** - This requirement emphasizes the use of session tokens over static API secrets and keys, except in legacy implementations. Session tokens provide a more secure and flexible approach to managing user sessions and access control. By using session tokens, the application can enforce session-specific security controls and reduce the risk of unauthorized access. Implementing this requirement enhances the security of  web application's session management.
- **3.5.3** - This requirement focuses on the security measures applied to stateless session tokens to protect against various attacks such as tampering, replay, and key substitution. By using digital signatures, encryption, and other countermeasures, the application can safeguard stateless session tokens from exploitation. Implementing this requirement ensures the integrity and confidentiality of session data, enhancing the overall security of  web application.

## 6 - Federated Re-authentication
| #          |  ASVS Level | CWE | Verification Requirement | Valid     | 
|------------|---|------------|-------------|-----------|
| **3.6.1**  |3|613|Verify that Relying Parties (RPs) specify the maximum authentication time to Credential Service Providers (CSPs) and that CSPs re-authenticate the subscriber if they haven't used a session within that period.| Not Valid |
| **3.6.2**  |3|613|Verify that Credential Service Providers (CSPs) inform Relying Parties (RPs) of the last authentication event, to allow RPs to determine if they need to re-authenticate the user.| Not Valid |


### Analysis
- **3.6.1** - This requirement focuses on specifying the maximum authentication time for Relying Parties (RPs) and re-authenticating subscribers who haven't used a session within that period. While this requirement is not valid for our chosen E-commerce web application, it's essential for more complex systems that rely on federated services to manage user authentication and authorization across multiple applications or domains.
- **3.6.2** - This requirement emphasizes informing Relying Parties (RPs) of the last authentication event to determine if re-authentication is necessary. For a simple e-commerce application, where users typically have short sessions and interactions are limited to shopping activities, implementing this may be unnecessary.

Those requirements are not valid for our chosen E-commerce web application. As in a simple e-commerce application where user authentication is handled internally without reliance on external identity providers or federated services, the need for federated re-authentication is reduced.

## 7 - Defenses Against Session Management Exploits
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.7.1**  |1|778|Verify the application ensures a valid login session or requires re-authentication or secondary verification before allowing any sensitive transactions or account modifications.| Valid |


### Analysis
- **3.7.1** - This requirement ensures that the application enforces a valid login session or requires re-authentication before allowing sensitive transactions or account modifications. Even though this is a simple web application that may have fewer complexities compared to larger or more complex systems, it's still essential to implement basic security measures to protect user accounts, sensitive data, and transactions.