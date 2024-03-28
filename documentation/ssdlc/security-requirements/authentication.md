
<h1> Authentication </h1>

### ASVS Requirement 2.1.1 - Auth0 Supported

**ASVS Requirement Description**: Verify that user set passwords are at least 12 characters in length (after multiple spaces are combined).

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps to ensure that users' passwords are sufficiently complex. This is supported by out-of-the-box Auth0 api.

**Security Requirement**: User Password Length - The application should ensure that user-set passwords are at least 12 characters in length.

---

### ASVS Requirement 2.1.2 - Not Relevant

**ASVS Requirement Description**: Verify that passwords of at least 64 characters are permitted, and that passwords of more than 128 characters are denied.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it sets boundaries on the password length. Allowing at least 64 characters enables users to set complex passwords, while denying more than 128 characters prevents potential denial of service attacks related to processing extremely long passwords. Auth0 api currently cannot limit a password of over 128 characters as described in (https://community.auth0.com/t/support-owasp-asvs-v4-0-3-items-2-1-2-and-2-1-3/129527)

**Security Requirement**: NOT APPLICABLE > User Password Length Limit - The application should permit user-set passwords of at least 64 characters and deny passwords of more than 128 characters.

---

### ASVS Requirement 2.1.3 - Not Relevant

**ASVS Requirement Description**: Verify that password truncation is not performed. However, consecutive multiple spaces may be replaced by a single space.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that the full complexity of users' passwords is preserved. Truncating passwords could inadvertently weaken them by reducing their length and complexity. This is supported by Auth0 API however there is a limitation where passwords beyond 72 bytes are ignored, and therefore truncated described here (https://community.auth0.com/t/customize-password-max-length/88610). This means if the first 72bytes of 2 users' passwords are the same, then they will be truncated and treated as the same password.

**Security Requirement**: NOT APPLICABLE > No Password Truncation - The application should not perform password truncation. However, it may replace consecutive multiple spaces with a single space.

---

### ASVS Requirement 2.1.4 - Auth0 Supported

**ASVS Requirement Description**: Verify that any printable Unicode character, including language neutral characters such as spaces and Emojis are permitted in passwords.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to create complex and diverse passwords. Allowing any printable Unicode character increases the potential password space, making brute-force attacks more difficult. This is supported by Auth0, however there is a community note from a developer, that brought up a problem, where emojis seem to count as 2 characters, so to satisfy a password policy of 12 characters, it would be possible to just enter 6. (https://community.auth0.com/t/owasp-asvs-4-0-password-policy/103090)

**Security Requirement**: Unicode Characters in Passwords - The application should permit any printable Unicode character, including language neutral characters such as spaces and Emojis, in passwords.

---

### ASVS Requirement 2.1.5 - Auth0 Supported

**ASVS Requirement Description**: Verify users can change their password.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to manage their own security by changing their password. This feature is particularly important if a user believes their password has been compromised. This feature is supported by Auth0 API, as it is quite an important requirement to have.

**Security Requirement**: User Password Change - The application should provide a feature that allows users to change their password.

---

### ASVS Requirement 2.1.6 - Auth0 Supported

**ASVS Requirement Description**: Verify that password change functionality requires the user's current and new password.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that only the authenticated user can change their password. Requiring the current password prevents an attacker from changing the password if they have temporary access to the user's session. This is available in Auth0 API, so it can be easily implemented.

**Security Requirement**: Current and New Password for Password Change - The application should require the user's current and new password when changing the password.

---

### ASVS Requirement 2.1.7 - Auth0 Supported ; Not Relevant

**ASVS Requirement Description**: Verify that passwords submitted during account registration, login, and password change are checked against a set of breached passwords either locally (such as the top 1,000 or 10,000 most common passwords which match the system's password policy) or using an external API. If using an API a zero knowledge proof or other mechanism should be used to ensure that the plain text password is not sent or used in verifying the breach status of the password. If the password is breached, the application must require the user to set a new non-breached password. 

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps to prevent users from setting passwords that have been breached. Checking against a set of breached passwords can help to protect against dictionary and brute-force attacks. This requirement is available in Auth0, but not with the free plan, as described here (https://auth0.com/docs/secure/attack-protection/breached-password-detection).

**Security Requirement**: NOT APPLICABLE > Password Breach Check - The application should check passwords submitted during account registration, login, and password change against a set of breached passwords. This could be done either locally or using an external API with a zero knowledge proof or other mechanism to ensure that the plain text password is not sent or used. If the password is found in the set of breached passwords, the application should require the user to set a new non-breached password.

---

### ASVS Requirement 2.1.8 - Auth0 Supported; Not Relevant

**ASVS Requirement Description**: Verify that a password strength meter is provided to help users set a stronger password.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps users to understand the strength of their password and encourages them to set a stronger password. Auth0 API only offers a password strength meter for database connections, as described here (https://auth0.com/docs/authenticate/database-connections/password-strength#minimum-password-length).

**Security Requirement**: NOT APPLICABLE > Password Strength Meter - The application should provide a password strength meter to help users set a stronger password.

---

### ASVS Requirement 2.1.9 - Auth0 Supported

**ASVS Requirement Description**: Verify that there are no password composition rules limiting the type of characters permitted. There should be no requirement for upper or lower case or numbers or special characters.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to create complex and diverse passwords. Imposing composition rules can limit the potential password space and make passwords more predictable. Unfortunatly, the Auth0 API supports password composition, however, it is only for database connections, as described here (https://auth0.com/docs/authenticate/database-connections/password-strength). This means, this requirement can be implemented in our application.

**Security Requirement**: No Password Composition Rules - The application should not impose password composition rules limiting the type of characters permitted. There should be no requirement for upper or lower case or numbers or special characters.

---

### ASVS Requirement 2.1.10 - Auth0 Supported

**ASVS Requirement Description**: Verify that there are no periodic credential rotation or password history requirements.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to manage their own password security. Periodic credential rotation and password history requirements can lead to user frustration and potentially insecure practices, such as users choosing simpler passwords or incrementing a number in their existing password. The API supports both approaches, with credential rotation or without.

**Security Requirement**: No Periodic Credential Rotation or Password History - The application should not impose periodic credential rotation or password history requirements.

---

### ASVS Requirement 2.1.11 - Auth0 Supported

**ASVS Requirement Description**: Verify that "paste" functionality, browser password helpers, and external password managers are permitted.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to use tools that help them manage their passwords securely, like password managers. These tools can encourage users to set stronger, unique passwords and reduce the risk of successful phishing attacks. Auth0 does not explicity say that pasting a password works, but there are user comments that confirming it works, like here (https://community.auth0.com/t/owasp-asvs-4-0-password-policy/103090)

**Security Requirement**: Permit Paste Functionality and Password Helpers - The application should permit 'paste' functionality, browser password helpers, and external password managers.

---

### ASVS Requirement 2.1.12 - Auth0 Supported

**ASVS Requirement Description**: Verify that the user can choose to either temporarily view the entire masked password, or temporarily view the last typed character of the password on platforms that do not have this as built-in functionality.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to verify their input when entering their password, which can help prevent errors. This is particularly important on platforms that do not have this as built-in functionality. This functionality exists in Auth0 API, not being explicitly. This requirement is not an out-of-the-box feature of Auth0 but the api can be customized to allow for this.

**Security Requirement**: Temporary Password View - The application should provide a feature that allows users to choose to either temporarily view the entire masked password, or temporarily view the last typed character of the password.

---

### ASVS Requirement 2.2.1 - Auth0 Supported

**ASVS Requirement Description**: Verify that anti-automation controls are effective at mitigating breached credential testing, brute force, and account lockout attacks. Such controls include blocking the most common breached passwords, soft lockouts, rate limiting, CAPTCHA, ever increasing delays between attempts, IP address restrictions, or risk-based restrictions such as location, first login on a device, recent attempts to unlock the account, or similar. Verify that no more than 100 failed attempts per hour is possible on a single account.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps to protect user accounts from automated attacks. Implementing effective anti-automation controls can help to prevent unauthorized access to user accounts. Auth0 supports attack protection against bots, ip throttling, brute force and breached password detection, as described here (https://auth0.com/docs/secure/attack-protection). However, some features like breached password detection are not available in the free version.

**Security Requirement**: Effective Anti-Automation Controls - The application should implement effective anti-automation controls to mitigate breached credential testing, brute force, and account lockout attacks. These controls could include blocking the most common breached passwords, soft lockouts, rate limiting, CAPTCHA, ever increasing delays between attempts, IP address restrictions, or risk-based restrictions such as location, first login on a device, recent attempts to unlock the account, or similar. The application should also ensure that no more than 100 failed attempts per hour is possible on a single account.

---

### ASVS Requirement 2.2.2 - Auth0 Supported

**ASVS Requirement Description**: Verify that the use of weak authenticators (such as SMS and email) is limited to secondary verification and transaction approval and not as a replacement for more secure authentication methods. Verify that stronger methods are offered before weak methods, users are aware of the risks, or that proper measures are in place to limit the risks of account compromise.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that weak authenticators are not used as the primary method of authentication. Limiting the use of weak authenticators and informing users of the risks can help to prevent unauthorized access to user accounts. Auth0 supports adaptive MFA and allows for customization of methods of authentication and their priorities, as described here (https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa).

**Security Requirement**: Limited Use of Weak Authenticators - The application should limit the use of weak authenticators (such as SMS and email) to secondary verification and transaction approval, and not as a replacement for more secure authentication methods. The application should offer stronger methods before weak methods, make users aware of the risks, or put proper measures in place to limit the risks of account compromise.

---

### ASVS Requirement 2.2.3 - Auth0 Supported

**ASVS Requirement Description**: Verify that secure notifications are sent to users after updates to authentication details, such as credential resets, email or address changes, logging in from unknown or risky locations. The use of push notifications - rather than SMS or email - is preferred, but in the absence of push notifications, SMS or email is acceptable as long as no sensitive information is disclosed in the notification.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps to keep users informed about changes to their authentication details. Secure notifications can help users to detect and respond to unauthorized changes to their account. Auth0 api supports push notifications and email notifications through AWS, as described here (https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa).

**Security Requirement**: Secure Notifications on Authentication Updates - The application should send secure notifications to users after updates to authentication details, such as credential resets, email or address changes, logging in from unknown or risky locations. The use of push notifications is preferred, but in the absence of push notifications, SMS or email is acceptable as long as no sensitive information is disclosed in the notification.

---

### ASVS Requirement 2.2.4 - Auth0 Supported

**ASVS Requirement Description**: Verify impersonation resistance against phishing, such as the use of multi-factor authentication, cryptographic devices with intent (such as connected keys with a push to authenticate), or at higher AAL levels, client-side certificates.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps to protect user accounts from impersonation attempts, such as phishing. Implementing measures like multi-factor authentication and cryptographic devices can significantly increase the difficulty for an attacker to impersonate a user. This is supported in Auth0 as implementing measures like MFA is possible in the API.

**Security Requirement**: - The application should implement measures to resist impersonation attempts, such as phishing. These measures could include the use of multi-factor authentication, cryptographic devices with intent (such as connected keys with a push to authenticate), or at higher AAL levels, client-side certificates.

---

### ASVS Requirement 2.2.5 - Auth0 Supported

**ASVS Requirement Description**: Verify that where a Credential Service Provider (CSP) and the application verifying authentication are separated, mutually authenticated TLS is in place between the two endpoints.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures secure communication between the application and the CSP. Mutually authenticated TLS can help to prevent man-in-the-middle attacks and ensure the integrity and confidentiality of the authentication data. Auth0 clearly allows authentication with mTLS as stated here (https://auth0.com/docs/get-started/authentication-and-authorization-flow/authenticate-with-mtls).

**Security Requirement**: Mutually Authenticated TLS - If a Credential Service Provider (CSP) and the application verifying authentication are separated, the application should ensure that mutually authenticated TLS is in place between the two endpoints.

---

### ASVS Requirement 2.2.6 - Auth0 Supported

**ASVS Requirement Description**: Verify replay resistance through the mandated use of One-time Passwords (OTP) devices, cryptographic authenticators, or lookup codes.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it helps to protect user accounts from replay attacks. Implementing measures like OTP devices, cryptographic authenticators, or lookup codes can significantly increase the difficulty for an attacker to replay a user's authentication sequence. Auth0 api allows for replay attack mitigation through cryptographic authenticators, as stated here (https://auth0.com/docs/get-started/authentication-and-authorization-flow/implicit-flow-with-form-post/mitigate-replay-attacks-when-using-the-implicit-flow).

**Security Requirement**: Replay Resistance - The application should ensure replay resistance through the mandated use of One-time Passwords (OTP) devices, cryptographic authenticators, or lookup codes.

---

### ASVS Requirement 2.2.7 - Auth0 Supported

**ASVS Requirement Description**: Verify intent to authenticate by requiring the entry of an OTP token or user-initiated action such as a button press on a FIDO hardware key.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that the user intends to authenticate. Requiring an OTP token or a user-initiated action can help to prevent unintentional or accidental authentication. This requirement can be implemented with Auth0 by way of customizing the flow of authentication in order to verify an intent to authenticate by the user.

**Security Requirement**: Verify Intent to Authenticate - The application should verify the intent to authenticate by requiring the entry of an OTP token or user-initiated action such as a button press on a FIDO hardware key.

---

### ASVS Requirement 2.3.1 - Auth0 Supported

**ASVS Requirement Description**: Verify system generated initial passwords or activation codes SHOULD be securely randomly generated, SHOULD be at least 6 characters long, and MAY contain letters and numbers, and expire after a short period of time. These initial secrets must not be permitted to become the long term password.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that initial passwords or activation codes are secure and temporary. This can help to prevent unauthorized access to user accounts. Auth0 supports customization for this requirement.

**Security Requirement**: Secure Initial Passwords and Activation Codes - The application should ensure that system generated initial passwords or activation codes are securely randomly generated, are at least 6 characters long, may contain letters and numbers, and expire after a short period of time. These initial secrets must not be permitted to become the long term password.

---

### ASVS Requirement 2.3.2 - Auth0 Supported

**ASVS Requirement Description**: Verify that enrollment and use of user-provided authentication devices are supported, such as a U2F or FIDO tokens.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it allows users to use their own authentication devices, which can provide a higher level of security. Supporting user-provided authentication devices can help to prevent unauthorized access to user accounts. Auth0 is supporting WebAuthn with FIDO security keys for multi-factor authentication as described here (https://auth0.com/blog/fido-security-key-support-comes-to-auth0/)

**Security Requirement**: Support for User-Provided Authentication Devices - The application should support the enrollment and use of user-provided authentication devices, such as U2F or FIDO tokens.

---

### ASVS Requirement 2.3.3 - Auth0 Supported

**ASVS Requirement Description**: Verify that renewal instructions are sent with sufficient time to renew time bound authenticators.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that users are given enough time to renew their time bound authenticators. Timely renewal instructions can help to prevent unauthorized access to user accounts due to expired authenticators. This requirement is supported and can be customized through the Auth0 API, as described here (https://auth0.com/docs/libraries/auth0-swift/auth0-swift-save-and-renew-tokens)

**Security Requirement**: Timely Renewal Instructions - The application should send renewal instructions with sufficient time to renew time bound authenticators.

---

### ASVS Requirement 2.4.1 - Auth0 Supported

**ASVS Requirement Description**: Verify that passwords are stored in a form that is resistant to offline attacks. Passwords SHALL be salted and hashed using an approved one-way key derivation or password hashing function. Key derivation and password hashing functions take a password, a salt, and a cost factor as inputs when generating a password hash.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that passwords are stored securely. Storing passwords in a form that is resistant to offline attacks can help to prevent unauthorized access to user accounts. The Auth0-hosted database is highly secure. Passwords are never stored or logged in plain text but are hashed with bcrypt (https://auth0.com/docs/authenticate/database-connections/auth0-user-store) and they also support costumization with salt as described here (https://auth0.com/blog/adding-salt-to-hashing-a-better-way-to-store-passwords/)

**Security Requirement**: Resistant Password Storage - The application should store passwords in a form that is resistant to offline attacks. Passwords should be salted and hashed using an approved one-way key derivation or password hashing function. Key derivation and password hashing functions should take a password, a salt, and a cost factor as inputs when generating a password hash.

---

### ASVS Requirement 2.4.2 - Auth0 Supported

**ASVS Requirement Description**: Verify that the salt is at least 32 bits in length and be chosen arbitrarily to minimize salt value collisions among stored hashes. For each credential, a unique salt value and the resulting hash SHALL be stored.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that salts used in password hashing are adequately long and unique. This can help to prevent attacks that rely on precomputed tables of hash values, such as rainbow table attacks. The Auth0-hosted database is highly secure. Passwords are never stored or logged in plain text but are hashed with bcrypt (https://auth0.com/docs/authenticate/database-connections/auth0-user-store) and they also support costumization with salt as described here (https://auth0.com/blog/adding-salt-to-hashing-a-better-way-to-store-passwords/).

**Security Requirement**: Adequate Salt Length and Uniqueness - The application should ensure that the salt is at least 32 bits in length and is chosen arbitrarily to minimize salt value collisions among stored hashes. For each credential, a unique salt value and the resulting hash should be stored.

---

### ASVS Requirement 2.4.3 - Auth0 Supported

**ASVS Requirement Description**: Verify that if PBKDF2 (Password Based Key Derivation Function 2) is used, the iteration count SHOULD be as large as verification server performance will allow, typically at least 100,000 iterations.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that if PBKDF2 is used for password hashing, the iteration count is sufficiently large to provide a good level of security. A higher iteration count can help to protect against brute force attacks. Auth0 supports customization for this requirement.

**Security Requirement**: Adequate PBKDF2 Iteration Count - If PBKDF2 is used, the application should ensure that the iteration count is as large as verification server performance will allow, typically at least 100,000 iterations.

---

### ASVS Requirement 2.4.4 - Auth0 Supported

**ASVS Requirement Description**: Verify that if bcrypt is used, the work factor SHOULD be as large as verification server performance will allow, with a minimum of 10.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that if bcrypt is used for password hashing, the work factor is sufficiently large to provide a good level of security. A higher work factor can help to protect against brute force attacks. The Auth0-hosted database is highly secure. Passwords are never stored or logged in plain text but are hashed with bcrypt (https://auth0.com/docs/authenticate/database-connections/auth0-user-store)

**Security Requirement**: Adequate bcrypt Work Factor - If bcrypt is used, the application should ensure that the work factor is as large as verification server performance will allow, with a minimum of 10.

---

### ASVS Requirement 2.4.5 - Auth0 Supported

**ASVS Requirement Description**: Verify that an additional iteration of a key derivation function is performed, using a salt value that is secret and known only to the verifier. Generate the salt value using an approved random bit generator [SP 800-90Ar1] and provide at least the minimum security strength specified in the latest revision of SP 800-131A. The secret salt value SHALL be stored separately from the hashed passwords (e.g., in a specialized device like a hardware security module).

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that an additional layer of security is added to the password hashing process. This can help to protect against brute force and rainbow table attacks. Auth0 supports customization of bcrypt and the flow of hashing a password, as described here (https://auth0.com/blog/hashing-in-action-understanding-bcrypt/) which allows to customize salt and verify an additional iteration of key derivation function.

**Security Requirement**: Additional Key Derivation Iteration and Secret Salt - The application should perform an additional iteration of a key derivation function, using a salt value that is secret and known only to the verifier. The salt value should be generated using an approved random bit generator and provide at least the minimum security strength specified in the latest revision of SP 800-131A. The secret salt value should be stored separately from the hashed passwords (e.g., in a specialized device like a hardware security module).

---

### ASVS Requirement 2.5.1 - Auth0 Supported

**ASVS Requirement Description**: Verify that a system generated initial activation or recovery secret is not sent in clear text to the user.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that initial activation or recovery secrets are transmitted securely. This can help to prevent unauthorized access to user accounts. Auth0 API supports this requirement with recovery codes for MFA, as described here (https://auth0.com/docs/secure/multi-factor-authentication/configure-recovery-codes-for-mfa)

**Security Requirement**: Secure Transmission of Initial Activation or Recovery Secret - The application should ensure that a system generated initial activation or recovery secret is not sent in clear text to the user.

---

### ASVS Requirement 2.5.2 - Auth0 Support

**ASVS Requirement Description**: Verify password hints or knowledge-based authentication (so-called "secret questions") are not present.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that insecure authentication methods, such as password hints or knowledge-based authentication, are not used. This can help to prevent unauthorized access to user accounts. As of early 2024, Auth0 does not have Knowledge-Based Authentication and no secret questions.

**Security Requirement**: Absence of au and Knowledge-Based Authentication - The application should ensure that password hints or knowledge-based authentication (so-called "secret questions") are not present.

---

### ASVS Requirement 2.5.3 - Auth0 Support

**ASVS Requirement Description**: Verify password credential recovery does not reveal the current password in any way.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that the current password is not revealed during the password recovery process. This can help to prevent unauthorized access to user accounts. Auth0 API supports secure password recovery as described here (https://auth0.com/docs/customize/actions/flows-and-triggers/password-reset).

**Security Requirement**: Secure Password Recovery - The application should ensure that password credential recovery does not reveal the current password in any way.

---

### ASVS Requirement 2.5.4 - Auth0 Support

**ASVS Requirement Description**: Verify shared or default accounts are not present (e.g. "root", "admin", or "sa").

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that shared or default accounts, which can be a security risk, are not used. This can help to prevent unauthorized access to the application. This is easily implemented and customizable with Auth0 api.

**Security Requirement**: Absence of Shared or Default Accounts - The application should ensure that shared or default accounts (e.g. "root", "admin", or "sa") are not present.

---

### ASVS Requirement 2.5.5 - Auth0 Support

**ASVS Requirement Description**: Verify that if an authentication factor is changed or replaced, that the user is notified of this event.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that users are aware of changes to their authentication factors. This can help to prevent unauthorized changes to user accounts. This is customizable and available to implement through the API with any of the following authentication factor described here (https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors)

**Security Requirement**: Notification of Authentication Factor Changes - The application should notify the user if an authentication factor is changed or replaced.

---

### ASVS Requirement 2.5.6 - Auth0 Support

**ASVS Requirement Description**: Verify forgotten password, and other recovery paths use a secure recovery mechanism, such as time-based OTP (TOTP) or other soft token, mobile push, or another offline recovery mechanism.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that recovery paths, such as forgotten password, use secure recovery mechanisms. This can help to prevent unauthorized access to user accounts. Auth0 API supports secure recovery codes for MFA (https://auth0.com/docs/secure/multi-factor-authentication/configure-recovery-codes-for-mfa).

**Security Requirement**: Secure Recovery Mechanism - The application should ensure that forgotten password and other recovery paths use a secure recovery mechanism, such as time-based OTP (TOTP) or other soft token, mobile push, or another offline recovery mechanism.

---

### ASVS Requirement 2.5.7 - Auth0 Support

**ASVS Requirement Description**: Verify that if OTP or multi-factor authentication factors are lost, that evidence of identity proofing is performed at the same level as during enrollment.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that if OTP or multi-factor authentication factors are lost, the user's identity is verified at the same level as during enrollment. This can help to prevent unauthorized access to user accounts. This requirement is supported with Auth0 as described here (https://auth0.com/docs/get-started/manage-dashboard-access/add-change-remove-mfa/remove-or-change-dashboard-multi-factor-authentication).

**Security Requirement**: Identity Proofing for Lost OTP or MFA Factors - The application should ensure that if OTP or multi-factor authentication factors are lost, evidence of identity proofing is performed at the same level as during enrollment.

---

### ASVS Requirement 2.6.1 - Auth0 Support

**ASVS Requirement Description**: Verify that lookup secrets can be used only once.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that lookup secrets, which are often used for password recovery or account activation, cannot be reused. This can help to prevent unauthorized access to user accounts. Auth0 supports the generation of an OTP lookup secret to aid in resetting a password, as described here (https://auth0.com/docs/authenticate/database-connections/password-change).

**Security Requirement**: Single-Use Lookup Secrets - The application should ensure that lookup secrets can be used only once.

---

### ASVS Requirement 2.6.2 - Auth0 Support

**ASVS Requirement Description**: Verify that lookup secrets have sufficient randomness (112 bits of entropy), or if less than 112 bits of entropy, salted with a unique and random 32-bit salt and hashed with an approved one-way hash.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that lookup secrets, which are often used for password recovery or account activation, have sufficient randomness. This can help to prevent unauthorized access to user accounts. Auth0 supports customization of this requirement. (https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-otp-notifications-for-mfa)

**Security Requirement**: Sufficient Randomness for Lookup Secrets - The application should ensure that lookup secrets have sufficient randomness (112 bits of entropy), or if less than 112 bits of entropy, they are salted with a unique and random 32-bit salt and hashed with an approved one-way hash.

---

### ASVS Requirement 2.6.3 - Auth0 Support

**ASVS Requirement Description**: Verify that lookup secrets are resistant to offline attacks, such as predictable values.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that lookup secrets, which are often used for password recovery or account activation, are resistant to offline attacks. This can help to prevent unauthorized access to user accounts. Auth0 customization (https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-otp-notifications-for-mfa)

**Security Requirement**: Resistance to Offline Attacks for Lookup Secrets - The application should ensure that lookup secrets are resistant to offline attacks, such as predictable values.

---

### ASVS Requirement 2.7.1 - Auth0 Support

**ASVS Requirement Description**: Verify that clear text out of band (NIST "restricted") authenticators, such as SMS or PSTN, are not offered by default, and stronger alternatives such as push notifications are offered first.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that insecure authentication methods, such as clear text out of band authenticators, are not offered by default. This can help to prevent unauthorized access to user accounts. Auth0 offers support for push notifications (https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors).

**Security Requirement**: Restricted Authenticators Not Offered by Default - The application should ensure that clear text out of band (NIST "restricted") authenticators, such as SMS or PSTN, are not offered by default, and stronger alternatives such as push notifications are offered first.

---

### ASVS Requirement 2.7.2 - Auth0 Support

**ASVS Requirement Description**: Verify that the out of band verifier expires out of band authentication requests, codes, or tokens after 10 minutes.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that out of band authentication requests, codes, or tokens are not valid indefinitely, which can help to prevent unauthorized access to user accounts. Auth0 supports this requirement, as described here (https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian)

**Security Requirement**: Expiration of Out of Band Authentication - The application should ensure that the out of band verifier expires out of band authentication requests, codes, or tokens after 10 minutes.

---

### ASVS Requirement 2.7.3 - Auth0 Support

**ASVS Requirement Description**: Verify that the out of band verifier authentication requests, codes, or tokens are only usable once, and only for the original authentication request.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that out of band authentication requests, codes, or tokens cannot be reused, which can help to prevent unauthorized access to user accounts. Auth0 supports this requirement.

**Security Requirement**: Single-Use Out of Band Authentication - The application should ensure that the out of band verifier authentication requests, codes, or tokens are only usable once, and only for the original authentication request.

---

### ASVS Requirement 2.7.4 - Auth0 Support

**ASVS Requirement Description**: Verify that the out of band authenticator and verifier communicates over a secure independent channel.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that out of band authentication, which is often used for two-factor authentication or password recovery, is conducted over a secure independent channel. This can help to prevent unauthorized access to user accounts. Auth0 supports this requirement as described here (https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian)

**Security Requirement**: Secure Independent Channel for Out of Band Authentication - The application should ensure that the out of band authenticator and verifier communicates over a secure independent channel.

---

### ASVS Requirement 2.7.5 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify that the out of band verifier retains only a hashed version of the authentication code.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that the authentication code, which is often used for two-factor authentication or password recovery, is stored securely. This can help to prevent unauthorized access to user accounts. Auth0 supports authentication codes however it it not explicit in the documentation that it only retains a hashed version.

**Security Requirement**: Hashed Authentication Code Retention - The application should ensure that the out of band verifier retains only a hashed version of the authentication code.

---

### ASVS Requirement 2.7.6 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify that the initial authentication code is generated by a secure random number generator, containing at least 20 bits of entropy (typically a six digital random number is sufficient).

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that the initial authentication code, which is often used for two-factor authentication or account activation, is generated securely. This can help to prevent unauthorized access to user accounts. Auth0 supports authentication codes, however there is no explicit way to tell if they follow 20 bits of entropy, therefore it is an uncertainty.

**Security Requirement**: Secure Generation of Initial Authentication Code - The application should ensure that the initial authentication code is generated by a secure random number generator, containing at least 20 bits of entropy (typically a six digital random number is sufficient).

---

### ASVS Requirement 2.8.1 - Auth0 Support

**ASVS Requirement Description**: Verify that time-based OTPs have a defined lifetime before expiring.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that time-based OTPs, which are often used for two-factor authentication or password recovery, are not valid indefinitely. This can help to prevent unauthorized access to user accounts. Auth0 api supports tOTPs, and last for around 30 seconds, as described here (https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian).

**Security Requirement**: Defined Lifetime for Time-Based OTPs - The application should ensure that time-based OTPs have a defined lifetime before expiring.

---

### ASVS Requirement 2.8.2 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify that symmetric keys used to verify submitted OTPs are highly protected, such as by using a hardware security module or secure operating system based key storage.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that symmetric keys, which are often used for OTP verification, are stored securely. This can help to prevent unauthorized access to user accounts. Auth0 supports OTPs, but there is no way to verify that symmetric keys are highly protected.

**Security Requirement**: High Protection for Symmetric Keys - The application should ensure that symmetric keys used to verify submitted OTPs are highly protected, such as by using a hardware security module or secure operating system based key storage.

---

### ASVS Requirement 2.8.3 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify that approved cryptographic algorithms are used in the generation, seeding, and verification of OTPs.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that OTPs, which are often used for two-factor authentication or password recovery, are generated, seeded, and verified using approved cryptographic algorithms. This can help to prevent unauthorized access to user accounts. Auth0 supports  OTPs, but there is no way to verify that approved cryptographic algorithms are being used.

**Security Requirement**: Use of Approved Cryptographic Algorithms for OTPs - The application should ensure that approved cryptographic algorithms are used in the generation, seeding, and verification of OTPs.

---

### ASVS Requirement 2.8.4 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify that time-based OTP can be used only once within the validity period.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that time-based OTPs, which are often used for two-factor authentication or password recovery, cannot be reused within their validity period. This can help to prevent unauthorized access to user accounts. Auth0 supports time-based OTP, as described here (https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian), however it is not possible to verify that they can be used only once withing the validity period.

**Security Requirement**: Single-Use Within Validity for Time-Based OTPs - The application should ensure that time-based OTP can be used only once within the validity period.

---

### ASVS Requirement 2.8.5 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify that if a time-based multi-factor OTP token is re-used during the validity period, it is logged and rejected with secure notifications being sent to the holder of the device.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that time-based OTPs, which are often used for two-factor authentication, cannot be reused within their validity period. This can help to prevent unauthorized access to user accounts. Auth0 supports time-based OTP, as described here (https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian), however it is not possible to verify that if it is re-used during the validity period, is is logged and rejected with secure notifications sent to the holder.

**Security Requirement**: Rejection and Notification of Reused Time-Based OTPs - The application should ensure that if a time-based multi-factor OTP token is re-used during the validity period, it is logged and rejected with secure notifications being sent to the holder of the device.

---

### ASVS Requirement 2.8.6 - Auth0 Support (uncertain)

**ASVS Requirement Description**: Verify physical single-factor OTP generator can be revoked in case of theft or other loss. Ensure that revocation is immediately effective across logged in sessions, regardless of location.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that a physical single-factor OTP generator, which is often used for two-factor authentication, can be revoked in case of theft or other loss. This can help to prevent unauthorized access to user accounts. Auth0 supports physical OTPs as described here (https://auth0.com/blog/not-all-mfa-is-created-equal/), however it is not possible to verify that a physical single-factor OTP generator can be revoked in case of theft or other loss.

**Security Requirement**: Revocation of Physical Single-Factor OTP Generator - The application should ensure that a physical single-factor OTP generator can be revoked in case of theft or other loss, and that revocation is immediately effective across logged in sessions, regardless of location.

---
//todo
### ASVS Requirement 2.8.7

**ASVS Requirement Description**: Verify that biometric authenticators are limited to use only as secondary factors in conjunction with either something you have and something you know.

**Related Functional Requirement**: User Registration and Authentication

**Justification**: This requirement is relevant because it ensures that biometric authenticators, which are often used for two-factor authentication, are not used as the sole method of authentication. This can help to prevent unauthorized access to user accounts.

**Security Requirement**: Limited Use of Biometric Authenticators - The application should ensure that biometric authenticators are limited to use only as secondary factors in conjunction with either something you have and something you know.

---

### ASVS Requirement 2.9.1 - Not Relevant

**ASVS Requirement Description**: Verify that cryptographic keys used in verification are stored securely and protected against disclosure, such as using a Trusted Platform Module (TPM) or Hardware Security Module (HSM), or an OS service that can use this secure storage.

**Related Functional Requirement**: Security

**Justification**: This requirement is not relevant because, given the scope of the project, it's unlikely that the team will have access to a TPM or HSM or need to implement such a high level of security.

**Security Requirement**: NOT APPLICABLE > Secure Storage of Cryptographic Keys - The application should ensure that cryptographic keys used in verification are stored securely and protected against disclosure, such as using a Trusted Platform Module (TPM) or Hardware Security Module (HSM), or an OS service that can use this secure storage.

---

### ASVS Requirement 2.9.2

**ASVS Requirement Description**: Verify that the challenge nonce is at least 64 bits in length, and statistically unique or unique over the lifetime of the cryptographic device.

**Related Non-Functional Requirement**: Security

**Justification**: This requirement is relevant because it ensures that the challenge nonce, which is often used for user authentication but not exclusively, is unique and of sufficient length. 

**Security Requirement**: Unique Challenge Nonce - The application should ensure that the challenge nonce is at least 64 bits in length, and statistically unique or unique over the lifetime of the cryptographic device.

---

### ASVS Requirement 2.9.3

**ASVS Requirement Description**: Verify that approved cryptographic algorithms are used in the generation, seeding, and verification.

**Related Non-Functional Requirement**: Security

**Justification**: This requirement is relevant because it ensures that approved cryptographic algorithms are used in the generation, seeding, and verification, which is a fundamental aspect of secure communication and data protection in the application.

**Security Requirement**: Use of Approved Cryptographic Algorithms - The application should ensure that approved cryptographic algorithms are used in the generation, seeding, and verification.

---

### ASVS Requirement 2.10.1 - Not Relevant

**ASVS Requirement Description**: Verify that intra-service secrets do not rely on unchanging credentials such as passwords, API keys or shared accounts with privileged access.

**Related Non-Functional Requirement**: Security

**Justification**: This requirement is not relevant because, given the scope of the project, it's unlikely that the application will have multiple services that need to communicate securely with each other.


**Security Requirement**: NOT APPLICABLE > Dynamic Intra-Service Secrets - The application should ensure that intra-service secrets do not rely on unchanging credentials such as passwords, API keys or shared accounts with privileged access.

---

### ASVS Requirement 2.10.2

**ASVS Requirement Description**: Verify that if passwords are required for service authentication, the service account used is not a default credential. (e.g. root/root or admin/admin are default in some services during installation).

**Related Non-Functional Requirement**: Security

**Justification**: This requirement is relevant because it ensures that service accounts, which are often used for secure communication between different services in the application, do not use default credentials. This can help to prevent unauthorized access to the services.

**Security Requirement**: Non-Default Service Account Credentials - The application should ensure that if passwords are required for service authentication, the service account used is not a default credential.

---

### ASVS Requirement 2.10.3

**ASVS Requirement Description**: Verify that passwords are stored with sufficient protection to prevent offline recovery attacks, including local system access.

**Related Non-Functional Requirement**: Security

**Justification**: This requirement is relevant because it ensures that passwords, which are often used for user authentication, are stored securely. This can help to prevent unauthorized access to user accounts.

**Security Requirement**: Sufficient Protection of Stored Passwords - The application should ensure that passwords are stored with sufficient protection to prevent offline recovery attacks, including local system access.

---

### ASVS Requirement 2.10.4 - Not Relevant

**ASVS Requirement Description**: Verify passwords, integrations with databases and third-party systems, seeds and internal secrets, and API keys are managed securely and not included in the source code or stored within source code repositories. Such storage SHOULD resist offline attacks. The use of a secure software key store (L1), hardware TPM, or an HSM (L3) is recommended for password storage.

**Related Non-Functional Requirement**: Security

**Justification**: This requirement is not relevant because, while it's important to not include sensitive data in the source code, the part about resisting offline attacks and using a secure software key store, hardware TPM, or an HSM is beyond the scope of the project.

**Security Requirement**: NOT APPLICABLE > Secure Management of Secrets - The application should ensure that passwords, integrations with databases and third-party systems, seeds and internal secrets, and API keys are managed securely and not included in the source code or stored within source code repositories. Such storage should resist offline attacks.