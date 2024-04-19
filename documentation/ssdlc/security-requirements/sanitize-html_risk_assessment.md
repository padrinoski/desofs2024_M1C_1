
# sanitize-html - HTML Sanitization API 

## Overview

> sanitize-html provides a simple HTML sanitizer with a clear API.
It is well suited for cleaning up HTML fragments such as those created by CKEditor and other rich text editors.  [sanitize-html](https://www.npmjs.com/package/sanitize-html)

### Risk identification 

For an accurate risk assessment, the following potential risks were identified and are going to be analysed: 

- **1.0 Dependency**
- **1.1 Configuration Errors**
- **1.2 Insecure Error Handling**
- **1.3 Outdated API**


### Risk Analysis

- **1.0 Dependecy** - the application is dependent on this api as its use is highly important as it protects the system from harm originated from unsafe user input. 
- **1.1 Configuration Errors** - misconfigurations on the options, such as allowed tags, allowed attributes or schemes can lead to weak sanitization and, for this reason, be a vulnerability. 
- **1.2 Insecure Error Handling** - If, for some reason, the api throws an error, the application must handle it properly as it could lead to harm for the system.
- **1.3 Outdated API** - as for right now, the sanitize-html is being kept up to date, with a large community of developers in charge of its manegement. If this were not the case, new not know vulnerabilites could be discovered, putting the application at risk.

### Risk Evaluation

- **1.0 Dependecy** - **(High Impact, Low Likelihood)**- This risk is of high impact due to the potential disruption of service, but has a low to inexistent likelihood 
- **1.1 Configuration Errors** - **(High Impact, Medium Likelihood)** a little misconfiguration can lead to exploitation and harm. The high impact is given to the scale that this exploit can take.
- **1.2 Insecure Error Handling** - **(High Impact, Low Likelihood)** as for right now, errors thrown by the api are unknown to exist. If these exist, it could provide an entry point for an attack that could scale very quickly. 
- **1.3 Outdated API** - **(High Impact, Low Likelihood)** as for right now, the API keeps on getting frequent updates with no discontinuation date is foreseen. If this were the case, it could lead to new sorts of attacks that the API is not ready to address.

### Risk Mitigation

- **1.0 Dependecy** - The use of a backup, internal html sanitizer. This, like the the other one, must be kept up to date in order to maintain its relevance.
- **1.1 Configuration Errors** - No procedure is confirmed to ensure the mitigation as the HTML input content could vary a lot. One method that could greatly decrease the risk is to ensure that the HTML that is going to be treated/ outputed has the expected format and nodes, not allowing anything outside the expected input.
- **1.2 Insecure Error Handling** - Implement error handling and, most importantly, that errors do not display any sensible information or exploitable content.
- **1.3 Outdated API** - As we are using external code, we are not able to ensure its maintenance. We can monitorized developements on it and, when discontinuation arrives, adopt new tools for the job. 

### Analysis DREAD

Microsoft DREAD is a quantitative risk assessment model that evaluates threats based 
on different influencing factors of it.

These factors are:

- **Damage**: How big would the damage be if the attack succeeded?
- **Reproducibility**: How easy is it to reproduce an attack?
- **Exploitability**: How much time, effort, and expertise is needed to
exploit the threat?
- **Affected Users**: If a threat were exploited, what percentage of
users would be affected?
- **Discoverability**: How easy is it for an attacker to discover this
threat?

### Threat 1.0 - Dependency

- Damage : System downtime ( 3 )
- Reproducibility :  Not very likely ( 1 )
- Exploitability : No vulnerabilities could be exploited while the system is down ( 0 )
- Affected Users : All (10)
- Discoverability: Not Applicable ( 0 )

Overall DREAD score for this threat: **2.8**

### Threat 1.1 - Configuration Errors

- Damage : Major. Leaks of data, denial of service, etc. ( 10 )
- Reproducibility :  Always when exploited ( 10 )
- Exploitability :  Not everyone can do it but the one who can, can easily do it ( 5 )
- Affected Users : All (10)
- Discoverability: WhiteListing contents sweeps the majority of the most commum exploits making the exploit hard to discover ( 2 )

Overall DREAD score for this threat: **7.4**

### Threat 1.2 - Insecure Error Handling

- Damage : Major. Leaks of data, account stealing and such ( 7 )
- Reproducibility :  Not always reproducible ( 6 )
- Exploitability :  Depending on the error, some informations could be exploited( 6 )
- Affected Users : Individual (2)
- Discoverability: Hard ( 2 )

Overall DREAD score for this threat: **4.6**

### Threat 1.3 - Outdated API

- Damage : The system could be vulnerable to new sorts of attacks ( 8 )
- Reproducibility :  Fully reproducible ( 10 )
- Exploitability :  Requires deprecation and unmanagement of the application ( 2 )
- Affected Users : All (10)
- Discoverability: New ways of exploitation could exploit the system in ways the system is not ready to address ( 4 )

Overall DREAD score for this threat: **6.8**

### Relevant topics
- [sanitize-html vulnerabilities](https://security.snyk.io/package/npm/sanitize-html)
- [SnykAdvisor sanitize-html](https://snyk.io/advisor/npm-package/sanitize-html)
