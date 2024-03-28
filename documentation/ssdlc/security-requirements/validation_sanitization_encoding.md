# Validation, Sanitization and Encoding

## Objective

In the context of ASVS (*Application Security Verification Standard*), validation, sanitization an encoding are concepts aimed at **ensuring the security and integrity of user input and output within web applications**.

To mitigate the risk of common vulnerabilities associated with user input and output in web applications, by implementing robust validation routines, complemented by appropriate sanitization and encoding techniques, developers enhance resilience on their applications against a range of attacks originated from the lack of proper input validation before directly its usage without any output encoding, such as Cross-Site Scripting (XSS), SQL injection, interpreter injection, locale/Unicode attacks, file system attacks, and buffer overflows. 

### Validation

Validation refers to the process of checking and verifying that input data meets certain criteria or constraints before it is processed or accepted by the application.
 - Some validation techniques include pattern matching, data type and length checks, whitelisting, among others, to detect and reject malicious or malformed input data.

### Sanitization

Sanitization involves the process of cleansing and filtering input data to remove potentially dangerous or malicious content before it is processed or stored by the application.
- Sanitization techniques typically involve removing or escaping special characters, HTML tags, or other potentially harmful elements from user input to neutralize injection attacks and prevent unintended code execution. 

### Encoding

Encoding refers to the process of transforming data into a format that is safe for transmission and storage, particularly in contexts where special characters or binary data may pose security risks.
-   Encoding helps mitigate the risk of security vulnerabilities like XSS (Cross-Site Scripting) by converting potentially dangerous characters into their encoded representations, thereby neutralizing their malicious impact when rendered by the application.
-   Effective encoding practices should be applied consistently throughout the application's data handling processes, including input validation, output rendering, and data storage, to maintain data integrity and security.

## 5.1 Input Validation

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| --
| **5.1.1** | Verify that the application has defenses against HTTP parameter pollution attacks, particularly if the application framework makes no distinction about the source of request parameters (GET, POST, cookies, headers, or environment variables). | 1| 235 |Valid
| **5.1.2** | Verify that frameworks protect against mass parameter assignment attacks, or that the application has countermeasures to protect against unsafe parameter assignment, such as marking fields private or similar. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1| 915 |Valid
| **5.1.3** | Verify that all input (HTML form fields, REST requests, URL parameters, HTTP headers, cookies, batch files, RSS feeds, etc) is validated using positive validation (allow lists). ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 20 |Valid
| **5.1.4** | Verify that structured data is strongly typed and validated against a defined schema including allowed characters, length and pattern (e.g. credit card numbers, e-mail addresses, telephone numbers, or validating that two related fields are reasonable, such as checking that suburb and zip/postcode match). ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 20 |Valid
| **5.1.5** | Verify that URL redirects and forwards only allow destinations which appear on an allow list, or show a warning when redirecting to potentially untrusted content. | 1 | 601 |Valid

## 5.2 Sanitization and Sandboxing

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **5.2.1** | Verify that all untrusted HTML input from WYSIWYG editors or similar is properly sanitized with an HTML sanitizer library or framework feature. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 116 |Valid
| **5.2.2** | Verify that unstructured data is sanitized to enforce safety measures such as allowed characters and length. | 1 | 138 |Valid
| **5.2.3** | Verify that the application sanitizes user input before passing to mail systems to protect against SMTP or IMAP injection. | 1 | 147 |Not Applicable
| **5.2.4** | Verify that the application avoids the use of eval() or other dynamic code execution features. Where there is no alternative, any user input being included must be sanitized or sandboxed before being executed. | 1 | 95 | Valid
| **5.2.5** | Verify that the application protects against template injection attacks by ensuring that any user input being included is sanitized or sandboxed. | 1| 94 |Valid
| **5.2.6** | Verify that the application protects against SSRF attacks, by validating or sanitizing untrusted data or HTTP file metadata, such as filenames and URL input fields, and uses allow lists of protocols, domains, paths and ports. | 1 | 918 |Valid
| **5.2.7** | Verify that the application sanitizes, disables, or sandboxes user-supplied Scalable Vector Graphics (SVG) scriptable content, especially as they relate to XSS resulting from inline scripts, and foreignObject. | 1 | 159 |Valid
| **5.2.8** | Verify that the application sanitizes, disables, or sandboxes user-supplied scriptable or expression template language content, such as Markdown, CSS or XSL stylesheets, BBCode, or similar. | 1 | 94 |Valid

## 5.3 Output Encoding and Injection Prevention

Output encoding, close or adjacent to the interpreter in use, is critical to the security of any application, as it is used to render the output safely in the appropriate output context for its immediate use.

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **5.3.1** | Verify that output encoding is relevant for the interpreter and context required. For example, use encoders specifically for HTML values, HTML attributes, JavaScript, URL parameters, HTTP headers, SMTP, and others as the context requires, especially from untrusted inputs (e.g. names with Unicode or apostrophes, such as ねこ or O'Hara). ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1| 116 | Valid
| **5.3.2** | Verify that output encoding preserves the user's chosen character set and locale, such that any Unicode character point is valid and safely handled. ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1| 176 |Valid
| **5.3.3** | Verify that context-aware, preferably automated - or at worst, manual - output escaping protects against reflected, stored, and DOM based XSS. ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 79 |?
| **5.3.4** | Verify that data selection or database queries (e.g. SQL, HQL, ORM, NoSQL) use parameterized queries, ORMs, entity frameworks, or are otherwise protected from database injection attacks. ([C3](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 89 |Valid
| **5.3.5** | Verify that where parameterized or safer mechanisms are not present, context-specific output encoding is used to protect against injection attacks, such as the use of SQL escaping to protect against SQL injection. ([C3, C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 89 | Valid
| **5.3.6** | Verify that the application protects against JSON injection attacks, JSON eval attacks, and JavaScript expression evaluation. ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) |1 | 830 |Valid
| **5.3.7** | Verify that the application protects against LDAP injection vulnerabilities, or that specific security controls to prevent LDAP injection have been implemented. ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 90 |Valid
| **5.3.8** | Verify that the application protects against OS command injection and that operating system calls use parameterized OS queries or use contextual command line output encoding. ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 78 |Not Applicable?
| **5.3.9** | Verify that the application protects against Local File Inclusion (LFI) or Remote File Inclusion (RFI) attacks. | 1 | 829 |Valid?
| **5.3.10** | Verify that the application protects against XPath injection or XML injection attacks. ([C4](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 643 |Valid

## 5.4 Memory, String, and Unmanaged Code

Generally, the following requirements will only apply when the application uses a systems language or unmanaged code. As it  won't  be the case, these are marked as 'Not Applicable'.

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **5.4.1** | Verify that the application uses memory-safe string, safer memory copy and pointer arithmetic to detect or prevent stack, buffer, or heap overflows. | 2 | 120 |Not Applicable
| **5.4.2** | Verify that format strings do not take potentially hostile input, and are constant. | 2 | 134 |Not Applicable
| **5.4.3** | Verify that sign, range, and input validation techniques are used to prevent integer overflows. |2 | 190 |Not Applicable

## 5.5 Deserialization Prevention

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **5.5.1** | Verify that serialized objects use integrity checks or are encrypted to prevent hostile object creation or data tampering. ([C5](https://owasp.org/www-project-proactive-controls/#div-numbering)) | 1 | 502 |Valid
| **5.5.2** | Verify that the application correctly restricts XML parsers to only use the most restrictive configuration possible and to ensure that unsafe features such as resolving external entities are disabled to prevent XML eXternal Entity (XXE) attacks. |1| 611 |Valid
| **5.5.3** | Verify that deserialization of untrusted data is avoided or is protected in both custom code and third-party libraries (such as JSON, XML and YAML parsers). | 1 | 502 | Not Applicable
| **5.5.4** | Verify that when parsing JSON in browsers or JavaScript-based backends, JSON.parse is used to parse the JSON document. Do not use eval() to parse JSON. | 1| 95 |Valid

