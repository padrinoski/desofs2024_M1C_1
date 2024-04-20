# Business Logic Security Analysis

## Objective
Business Logic Security refers to the mechanisms and processes implemented within the application to ensure the integrity, availability, and security of the business processes and operations. It involves verifying that the application's business logic flows are designed and implemented securely to prevent abuse, exploitation, or unauthorized access.

The Application Security Verification Standard (ASVS) provides a set of requirements for assessing and verifying the security of web applications. So, we performed an analysis on those ASVS requirement as they serve as a guide to implementing robust business logic security controls and best practices in our project.

## 1 - Business Logic Security Requirements
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **11.1.1** |1|841|Verify that the application will only process business logic flows for the same user in sequential step order and without skipping steps.| Valid |
| **11.1.2** |1|799|Verify that the application will only process business logic flows with all steps being processed in realistic human time, i.e., transactions are not submitted too quickly.| Not Valid |
| **11.1.3** |1|770|Verify the application has appropriate limits for specific business actions or transactions which are correctly enforced on a per-user basis.| Valid |
| **11.1.4** |1|770|Verify that the application has anti-automation controls to protect against excessive calls such as mass data exfiltration, business logic requests, file uploads, or denial-of-service attacks.| Not Valid |
| **11.1.5** |1|841|Verify the application has business logic limits or validation to protect against likely business risks or threats, identified using threat modeling or similar methodologies.| Valid |
| **11.1.6** |2|367|Verify that the application does not suffer from "Time Of Check to Time Of Use" (TOCTOU) issues or other race conditions for sensitive operations.| Not Valid |
| **11.1.7** |2|754|Verify that the application monitors for unusual events or activity from a business logic perspective.| Not Valid |
| **11.1.8** |2|390|Verify that the application has configurable alerting when automated attacks or unusual activity is detected.| Valid |

### Analysis
- **11.1.1** - This requirement ensures that business logic flows are processed sequentially and without skipping steps, which is important for maintaining the integrity of the transactions. 
- **11.1.2** - While ensuring realistic human timing for processing transactions is important for preventing abuse, in a basic e-commerce website, the risk of rapid transaction submissions may be relatively low, making this requirement less applicable.
- **11.1.3** - Enforcing limits for specific business actions on a per-user basis is important for preventing abuse and ensuring fair usage of resources. So, it's important to enforce these limits in our e-commerce website.
- **11.1.4** - While having anti-automation controls to prevent excessive calls and denial-of-service attacks is essential, the specific controls required by this requirement may be more relevant to larger-scale systems handling a higher volume of transactions.
- **11.1.5** - Implementing business logic limits and validation to protect against likely business risks or threats identified through threat modeling is important for ensuring the security and integrity of the application's operations.
- **11.1.6** - While preventing race conditions is crucial for sensitive operations, the risk of such issues occurring may be lower in a simple e-commerce website, as we do not expect high concurrency in our operations as well.
- **11.1.7** - While monitoring for unusual activity from a business logic perspective is important for detecting anomalies and potential security incidents, the level of sophistication required for monitoring may vary based on the application's scale, and our web application is not likely to require extensive monitoring.
- **11.1.8** - Configurable alerting for detecting automated attacks and unusual activity is essential for timely incident response and mitigation. While the level of sophistication required in alerting mechanisms may vary, having the capability to detect and respond to security incidents is crucial for any web application.
