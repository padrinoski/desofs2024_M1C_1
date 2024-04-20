# OpenSSL - Cryptography library

## Overview

OpenSSL is a library that is generally used for cryptography and secure communication. It is widely used by websites due to it's open-source nature. This library will be used in the application for cryptography purposes relating to requirements present in ASVS, such as the use of well-known encryptation algorithms, generation of random numbers, creation of Guids and generation of encryption keys.

## Risk identification

The following potential risks were identified and are going to be analysed:

- **1.0 Configuration Errors**
- **1.1 Known Vulnerabilities**
- **1.2 Vulnerabilities outside of library scope**
- **1.3 Outdated Library Version**

### Risk Analysis

- **1.0 Configuration Errors** Configuration of OpenSSL can determine how certain functionalities work and what variables are defined. It is important then that the configuration does not allow for unintended behaviour that might lead to vulnerabilities such as setting the wrong environment in a production deployment. See [OpenSSL configuration](https://www.openssl.org/docs/man1.1.1/man5/config.html)
- **1.1 Known Vulnerabilities** Some vulnerabilities present in OpenSSL are known and have been raised beforehand, these can potentially prove to be likely to affect the application. See [Vulnerabilities](https://www.cvedetails.com/vulnerability-list/vendor_id-217/Openssl.html)
- **1.2 Vulnerabilities outside of library scope** Some vulnerabilities that are discovered by users fall outside of the scope of what OpenSSL tries to achieve, therefore, they are not fixed by a new version of the library. 
- **1.3 Outdated Library Version** New versions of OpenSSL are released up to date to fix new vulnerabilities that might prove to be a risk to the application. See [Release Strategy](https://www.openssl.org/policies/releasestrat.html)

### Risk Evaluation

- **1.0 Configuration Errors** - **(High Impact, Medium Likelihood)** With configuration, any error can create big vulnerabilities to the project or allow attackers to access hidden behaviour/data, making the impact high. The chances of configuration errors happening is somewhat considerable because it is especially prone to human error.
- **1.1 Known Vulnerabilities** - **(Low Impact, Low Likelihood)** With the list of current raised vulnerabilities as of version 3.3 of the library (See [Vulnerabilities](https://www.cvedetails.com/vulnerability-list/vendor_id-217/Openssl.html)), most vulnerability are listed with an average CVSS score (Common Vulnerability Scoring System) that means that the attacks may only happen with uncommon system configuration or a specific attack origin. Considering the scope of the application, we found very hard to imagine that such a configuration could be applied to our application to make it vulnerable to these attacks.
- **1.2 Vulnerabilities outside of library scope**- **(Low Impact, Low Likelihood)** Some known vulnerabilities exists that are only applied when the OpenSSL library is interaction with other assets or with very specific hardware configuration [See as an example CVE-2002-20001](https://www.cve.org/CVERecord?id=CVE-2002-20001). Vulnerabilities such as these are not considered a weakness of the library, and thus fall outside of the scope of fixes for new updates. Thus, they can become a vulnerability depending on how the system is configured.
- **1.3 Outdated Library** - **(High Impact, Low Likelihood)** With every release, vulnerabilities are fixed, so it's important that the library is kept up-to-date. Luckily, as of the creation of this anlysis, the library continuous to receive updates. 

### Risk Mitigation

- **1.0 Configuration Errors** - Due to human errors, it's impossible to guarantee that the configuration of the library is completely safe, however, one way to mitigate the possibility is to guarantee that any functionality set as part of the configuration is done automatically during the deployment taking into consideration the environment .
- **1.1 Known Vulnerabilities** - For known vulnerabilities, it's only possible to monitor them such that their point of entrance is not applicable to the application.
- **1.2 Vulnerabilities outside of library scope** - Similar to the known vulnerabilities, these have to be monitored continuously to avoid configurations that allow for such an attack to be used.
- **1.3 Outdated Library Version** - To guarantee that the library will not use old versions, a step in the pipeline that install the library will always try to install the latest version. If the library stops being supported, a full migration to another tool must be made, however, due to the popularity of the library, this seems unlikely.