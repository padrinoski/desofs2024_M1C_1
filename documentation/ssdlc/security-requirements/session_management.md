# Session Management

## Description
Session Management refers to the mechanisms and processes implemented within the application scope to manage and regulate the user's session lifecycle, minimizing the security risk of unauthorized access to physical and logical systems.
A robust Session Management mechanism ensures that only authorized users can access the application's resources and functionalities, while unauthorized access attempts are detected and/or prevented effectively.

In order to achieve this goal, the Application Security Verification Standard (ASVS) requirements were analyzed in order to cover the specific criteria and guidelines outlined by the standard to ensure the security of our web application. These requirements serve as a collection of security controls and best practices that should be taken into account when designing, developing, and testing web applications.

## 1 - Fundamental Session Management Security
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.1.1**  |1|598|Verify the application never reveals session tokens in URL parameters or error messages.|Valid|

## 2 - Session Binding
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|---|-------------|-------|
| **3.2.1**  |1|384|Verify the application generates a new session token on user authentication. ([C6](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))| Valid |
| **3.2.2**  |1|331|Verify that session tokens possess at least 64 bits of entropy. ([C6](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))| Valid |
| **3.2.3**  |1|539|Verify the application only stores session tokens in the browser using secure methods such as appropriately secured cookies (see section 3.4) or HTML 5 session storage.| Valid |
| **3.2.4**  |2|331|Verify that session tokens are generated using approved cryptographic algorithms. ([C6](https://www.owasp.org/index.php/OWASP_Proactive_Controls#tab=Formal_Numbering))| Valid |

## 3 - Session Termination
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.3.1**  |1|613|Verify that logout and expiration invalidate the session token, such that the back button or a downstream relying party does not resume an authenticated session, including across relying parties. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid |
| **3.3.2**  |1|613|If authenticators permit users to remain logged in, verify that re-authentication occurs periodically both when actively used or after an idle period. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid |
| **3.3.3**  |2|613|Verify that the application gives the option to terminate all other active sessions after a successful password change (including change via password reset/recovery), and that this is effective across the application, federated login (if present), and any relying parties.| Not Valid |
| **3.3.4**  |2|613|Verify that users are able to view and (having re-entered login credentials) log out of any or all currently active sessions and devices.| Not Valid |

## 4 - Cookie-based Session Management
| #          |  ASVS Level | CWE | Verification Requirement | Valid     | 
|------------|---|------------|-------------|-----------|
| **3.4.1**  |1|614|Verify that cookie-based session tokens have the 'Secure' attribute set. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid     |
| **3.4.2**  |1|1004|Verify that cookie-based session tokens have the 'HttpOnly' attribute set. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))|  Valid|
| **3.4.3**  |1|16|Verify that cookie-based session tokens utilize the 'SameSite' attribute to limit exposure to cross-site request forgery attacks. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Valid |
| **3.4.4**  |1|16|Verify that cookie-based session tokens use the "__Host-" prefix so cookies are only sent to the host that initially set the cookie.|  Valid |
| **3.4.5**  |1|16|Verify that if the application is published under a domain name with other applications that set or use session cookies that might disclose the session cookies, set the path attribute in cookie-based session tokens using the most precise path possible. ([C6](https://owasp.org/www-project-proactive-controls/#div-numbering))| Not Valid |

## 5 - Token-based Session Management
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.5.1**  |2|290|Verify the application allows users to revoke OAuth tokens that form trust relationships with linked applications.| Valid |
| **3.5.2**  |2|798|Verify the application uses session tokens rather than static API secrets and keys, except with legacy implementations.|  Valid |
| **3.5.3**  |2|345|Verify that stateless session tokens use digital signatures, encryption, and other countermeasures to protect against tampering, enveloping, replay, null cipher, and key substitution attacks.| Valid|

## 6 - Federated Re-authentication
| #          |  ASVS Level | CWE | Verification Requirement | Valid     | 
|------------|---|------------|-------------|-----------|
| **3.6.1**  |3|613|Verify that Relying Parties (RPs) specify the maximum authentication time to Credential Service Providers (CSPs) and that CSPs re-authenticate the subscriber if they haven't used a session within that period.| Not Valid |
| **3.6.2**  |3|613|Verify that Credential Service Providers (CSPs) inform Relying Parties (RPs) of the last authentication event, to allow RPs to determine if they need to re-authenticate the user.| Not Valid |

## 7 - Defenses Against Session Management Exploits
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **3.7.1**  |1|778|Verify the application ensures a valid login session or requires re-authentication or secondary verification before allowing any sensitive transactions or account modifications.| Valid |

## Requirement Analysis
* 3.1.1 - This is a valid requirement for our E-commerce web application as it a basic security measure to prevent session hijacking attacks. The session tokens should not be exposed in the URL or error messages.
* 3.2.x - Those are valid requirements for our E-commerce web application as those help prevent session fixation attacks.  Generating new session tokens on user authentication, ensuring sufficient entropy, storing session tokens securely, and using approved cryptographic algorithms are all good practices that must be followed.
* 3.3.1 and 3.3.2 - Those requirements are considered valid for our chosen E-commerce web application. Even tho there's a low risk of session hijacking or unauthorized access, as the registered user can visualize its own shipment address - which is sensitive information, it's important to ensure that the session is invalidated after logout or expiration and that re-authentication occurs periodically.
* 3.3.3 and 3.3.4 - Those requirements are not valid for our chosen E-commerce web application. As a web commerce application, requirements 3.3.1 and 3.3.2 cover most of the risks associated with session management. 
* 3.4.1, 3.4.2, 3.4.3 and 3.4.4 - Those are valid requirements for an E-commerce web application. implementing these cookie-based session management requirements boost the security posture of our E-commerce application by safeguarding the confidentiality, integrity, and availability of sensitive user information, including shipment addresses. This not only protects the users but also helps maintain regulatory compliance and reinforces trust.
* 3.4.5 - This requirement is not valid for our chosen E-commerce web application. As the application is not published under a domain name with other applications that set or use session cookies that might disclose the session cookies, setting the path attribute in cookie-based session tokens using the most precise path possible is not necessary.
* 3.5.x - Those are valid requirements for an E-commerce web application. Token-based session management requirements are essential for securing the application's API endpoints and ensuring that only authorized users can access the application's resources and functionalities.
* 3.6.x - Those requirements are not valid for our chosen E-commerce web application. In a simple e-commerce application where user authentication is handled internally without reliance on external identity providers or federated services, the need for federated re-authentication is reduced.
* 3.7.1 - This is a valid requirement for our E-commerce web application. Even tho this is a simple web application that may have fewer complexities compared to larger or more complex systems, it's still essential to implement basic security measures to protect user accounts, sensitive data, and transactions.