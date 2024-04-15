# sanitize-html - HTML Sanitization API 

## Overview

> sanitize-html provides a simple HTML sanitizer with a clear API.
It is well suited for cleaning up HTML fragments such as those created by CKEditor and other rich text editors.  [sanitize-html](https://www.npmjs.com/package/sanitize-html)

### Risk identification 

For an accurate risk assessment, the following potential risks we identified and are going to be analysed: 

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

