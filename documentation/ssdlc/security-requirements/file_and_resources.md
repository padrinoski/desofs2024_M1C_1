# Files and Resources Security Analysis

## Objective
Files and Resources Security involves implementing measures to securely handle file uploads, storage, integrity checks, and downloads within the application. Ensuring proper handling of files and resources mitigates risks such as denial of service, unauthorized access, and injection attacks.

The Application Security Verification Standard (ASVS) provides a comprehensive set of requirements for verifying the security of web applications, including those related to files and resources. In that way, we performed an analysis on those ASVS requirements as they serve as a guide to implementing robust files and resources security controls and best practices in our project.

## 1 - File Upload
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **12.1.1** |1|400|Verify that the application will not accept large files that could fill up storage or cause a denial of service.| Not Valid |
| **12.1.2** |2|409|Verify that the application checks compressed files against maximum allowed uncompressed size and against maximum number of files before uncompressing the file.| Not Valid |
| **12.1.3** |2|770|Verify that a file size quota and maximum number of files per user is enforced.| Valid |

### Analysis
- **12.1.1** - While preventing large file uploads can mitigate storage and denial-of-service risks, it may not be applicable to our e-commerce website where users should only upload small images for product listings.
- **12.1.2** - Checking compressed files against maximum sizes and file counts may not be necessary for a basic e-commerce website where the risk of such files causing harm is low.
- **12.1.3** - Enforcing file size quotas and maximum file counts per user can help prevent abuse and ensure fair resource allocation, which may be relevant for our web app.

## 2 - File Integrity
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **12.2.1** |2|434|Verify that files obtained from untrusted sources are validated to be of expected type based on the file's content.| Valid |

### Analysis
- **12.2.1** - Validating files from untrusted sources based on their content type helps prevent the upload of malicious files. This requirement is relevant for any web application, including a simple e-commerce website as the one wee choose.

## 3 - File Execution
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **12.3.1** |1|22 |Verify that user-submitted filename metadata is not used directly by system or framework filesystems.| Valid |
| **12.3.2** |1|73 |Verify that user-submitted filename metadata is validated or ignored to prevent the disclosure, creation, updating or removal of local files.| Valid |
| **12.3.3** |1|98 |Verify that user-submitted filename metadata is validated or ignored to prevent the disclosure or execution of remote files.| Valid |
| **12.3.4** |1|641|Verify that the application protects against Reflective File Download (RFD).| Not Valid |
| **12.3.5** |1|78 |Verify that untrusted file metadata is not used directly with system API or libraries.| Valid |
| **12.3.6** |2|829|Verify that the application does not include and execute functionality from untrusted sources.| Valid |

### Analysis
- **12.3.x** - Most requirements in this category are valid for ensuring the safe handling of user-submitted files. However, the need to protect against Reflective File Download (RFD) may be less relevant for a basic e-commerce website.
- **12.3.4** - Reflective File Download (RFD) is a specific attack vector that may not be a high priority for our project, as our e-commerce website  doesn't involve extensive user-generated content or file-sharing features, the attack surface for RFD may be limited.

## 4 - File Storage
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **12.4.1** |1|922|Verify that files obtained from untrusted sources are stored outside the web root.| Valid |
| **12.4.2** |1|509|Verify that files obtained from untrusted sources are scanned by antivirus scanners.| Not Valid |

### Analysis
- **12.4.1** - Storing files from untrusted sources outside the web root mitigates the risk of unauthorized access and execution. This requirement is relevant for our web application.
- **12.4.2** - While scanning files with antivirus scanners can enhance security, it may not be necessary for a simple e-commerce website with limited file uploads.

## 5 - File Download
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **12.5.1** |1|552|Verify that the web tier is configured to serve only files with specific file extensions.| Valid |
| **12.5.2** |1|434|Verify that direct requests to uploaded files will never be executed as HTML/JavaScript content.| Valid |

### Analysis
- **12.5.x** - These requirements ensure secure file serving and prevent unintentional information leakage or execution of malicious content. They are relevant for our web app as we allow users to upload images for products.

## 6 - SSRF Protection
| #          |  ASVS Level | CWE | Verification Requirement | Valid | 
|------------|---|------------|-------------|-------|
| **12.6.1** |1|918|Verify that the web or application server is configured with an allow list of resources.| Not Valid |

### Analysis
- **12.6.1** - While SSRF protection is important for preventing server-side request forgery, it may not be applicable to our e-commerce website, as the interaction with external resources is limited to standard functionalities. If these interactions are well-defined and controlled, the risk of SSRF vulnerabilities are reduced.

