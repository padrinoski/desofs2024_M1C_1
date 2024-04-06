

# Malicious Code

## Objective


"Malicious code" refers to any software or script intentionally designed to cause harm or damage to computer systems, networks, or data. It incorporates a wide range of malicious software and scripts that are created with malicious intent, often designed for activities such as stealing sensitive information, disrupting system operations, or gaining unauthorized access to resources by exploiting systems in various ways to generate profit for attackers.

The concept of malicious code is addressed primarily in requirements related to secure coding practices, input validation, output encoding, and secure communication, in order to mitigate the risk of malicious code injection, execution, and exploitation.

## 1. Code Integrity

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **1.1** | Verify that a code analysis tool is in use that can detect potentially malicious code, such as time functions, unsafe file operations and network connections. |3| 749 |Valid

### Analysis

- 1.1 - Source code analysis tools, also known as Static Application Security Testing (SAST) Tools, can help analyze source code or compiled versions of code to help find security flaws, providing good scalability and identification of well-know vulnerabilities.

	> https://github.com/features/security

## 2 Malicious Code Search

| # | Description | ASVS Level | CWE |Valid
| :---: | :--- | :---: | :---:| :---: |
| **2.1** | Verify that the application source code and third party libraries do not contain unauthorized phone home or data collection capabilities. Where such functionality exists, obtain the user's permission for it to operate before collecting any data. |2 | 359 |Valid
| **2.2** | Verify that the application does not ask for unnecessary or excessive permissions to privacy related features or sensors, such as contacts, cameras, microphones, or location. | 2 | 272 |Valid
| **2.3** | Verify that the application source code and third party libraries do not contain back doors, such as hard-coded or additional undocumented accounts or keys, code obfuscation, undocumented binary blobs, rootkits, or anti-debugging, insecure debugging features, or otherwise out of date, insecure, or hidden functionality that could be used maliciously if discovered. | 3 | 507 |Valid
| **2.4** | Verify that the application source code and third party libraries do not contain time bombs by searching for date and time related functions. | 3 | 511 |Valid
| **2.5** | Verify that the application source code and third party libraries do not contain malicious code, such as salami attacks, logic bypasses, or logic bombs. |3 | 511 |Valid
| **2.6** | Verify that the application source code and third party libraries do not contain Easter eggs or any other potentially unwanted functionality. | 3 | 507 |Valid


> Complying with this section is not possible without complete access to source code, including third-party libraries.
> 
### Analysis

- **2.1** - This topic is relevant as it is important to know if, by using such libraries, we are exposing personal data to third-parties without the user's consent and, more importantly, ensuring that no sensible data is being sent to them.
- **2.2** - It is important to ensure the that **only strictly necessary permissions** are asked in order to comply with intended use of the application.
- **2.3** - This requirement is valid as this back doors could be exploited presenting themselves as possible vulnerabilities.
- **2.4**- Time bombs are programs/functions with delayed execution that are designed to run when certain conditions are being met, for example reaching a specific date. Although software like this doesn’t have to be necessarily malicious, sometimes they can used by threat actors to create devious malware.
- **2.5**- Just like time bombs, the presence of malicious presents itself as an entry point for attackers and could provoke harm for the system. For these reason, these vulnerabilities must be mitigated.
- **2.6**- Easter eggs or unwanted functionalities can present themselves as vulnerabilities as they are often disguised as harmless features or games, making them difficult to detect. Easter egg attacks can take many forms, from hidden codes in software to hidden scripts in websites, often used to gain access to sensitive information, to take control of your system or even used to install malware or other unwanted software on your device.

## 3 Application Integrity

Once an application is deployed, malicious code can still be inserted. Applications need to protect themselves against common attacks, such as executing unsigned code from untrusted sources and subdomain takeovers.

Complying with this section is likely to be operational and continuous.

| # | Description | ASVS Level | CWE |Valid|
| :---: | :--- | :---: | :---:| :---: | 
| **3.1** | Verify that if the application has a client or server auto-update feature, updates should be obtained over secure channels and digitally signed. The update code must validate the digital signature of the update before installing or executing the update. | 1 | 16 |Valid / Not Applicable
| **3.2** | Verify that the application employs integrity protections, such as code signing or subresource integrity. The application must not load or execute code from untrusted sources, such as loading includes, modules, plugins, code, or libraries from untrusted sources or the Internet. | 1 | 353 |Valid/ Not Applicable
| **3.3** | Verify that the application has protection from subdomain takeovers if the application relies upon DNS entries or DNS subdomains, such as expired domain names, out of date DNS pointers or CNAMEs, expired projects at public source code repos, or transient cloud APIs, serverless functions, or storage buckets (*autogen-bucket-id*.cloud.example.com) or similar. Protections can include ensuring that DNS names used by applications are regularly checked for expiry or change. | 1 | 350 |Valid / Not Applicable

### Analysis
As for right now, the soon to be developed application wont be deployed making these requirements not applicable altough, in other scenarios, valid.
