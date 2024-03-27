
# Access Control

## Objective
In the context of ASVS (*Application Security Verification Standard*), access control refers to the mecanisms and processes implemented within the application scope to **manage and regulate its users access** to resources and funcionalities, **minimizing the security risk of unauthorized access to physical and logical systems**. 

 This said, access control encompasses a range of measures aimed at ensuring that **only authorized users can access the application's resources and functionalities**, while unauthorized access attempts are **detected and prevented effectively**.

To achieve this goal, requirements were defined to cover the **specific criteria and guidelines outlined by the standard to ensure the security of web applications**. These requirements serve as a collection of **security controls and best practices** that should be taken into account when designing, developing, and testing web applications.

*ASVS* requirements are categorized into 3 levels, each representing different and increasing levels of security assurance and rigor, covering various aspects of application security.

## 4.1 General Access Control Design

|#| Description  | ASVS Level | CWE|Valid|
|--|--|--|--|--|
|**4.1.1**|Verify that the application enforces access control rules on a trusted service layer, especially if client-side access control is present and could be bypassed. |1|602|Valid|
|**4.1.2**|Verify that all user and data attributes and policy information used by access controls cannot be manipulated by end users unless specifically authorized.|1|639|Valid|
|**4.1.3**|Verify that the principle of least privilege exists - users should only be able to access functions, data files, URLs, controllers, services, and other resources, for which they possess specific authorization. This implies protection against spoofing and elevation of privilege. ([C7](https://owasp.org/www-project-proactive-controls/#div-numbering))|1|285|Valid|
|**4.1.4**|[DELETED, DUPLICATE OF 4.1.3] |1|276|Not Applicable|
|**4.1.5**|Verify that access controls fail securely including when an exception occurs. ([C10](https://owasp.org/www-project-proactive-controls/#div-numbering)) |1|285|Valid|

## 4.2 Operation Level Access Control

| # | Description | ASVS Level| CWE |Valid|
|---| :---: | :--- | :---: | :---:|
| **4.2.1** | Verify that sensitive data and APIs are protected against Insecure Direct Object Reference (IDOR) attacks targeting creation, reading, updating and deletion of records, such as creating or updating someone else's record, viewing everyone's records, or deleting all records. | 1 | 639 |Valid|
| **4.2.2** | Verify that the application or framework enforces a strong anti-CSRF mechanism to protect authenticated functionality, and effective anti-automation or anti-CSRF protects unauthenticated functionality. | 1| 352 |Valid|

## 4.3 Other Access Control Considerations

| # | Description |ASVS Level | CWE |Valid|
| :---: | :--- | :---: | :---:| --|
| **4.3.1** | Verify administrative interfaces use appropriate multi-factor authentication to prevent unauthorized use. | 1 | 419 |Valid
| **4.3.2** | Verify that directory browsing is disabled unless deliberately desired. Additionally, applications should not allow discovery or disclosure of file or directory metadata, such as Thumbs.db, .DS_Store, .git or .svn folders. | 1 | 548 |Valid
| **4.3.3** | Verify the application has additional authorization (such as step up or adaptive authentication) for lower value systems, and / or segregation of duties for high value applications to enforce anti-fraud controls as per the risk of application and past fraud. | 2 | 732 |Valid
