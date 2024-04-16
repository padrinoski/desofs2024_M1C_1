<h1>Stored Cryptography<h1>

## Objective

This section serves to validade that the software will follow the OWASP ASVS Standard, in the case of Cryptography, the interest is mainly on correctely deciding what data needs to be encrypted, how the encryption algorithm will work, and to guarantee that the generated keys are safely managed.

## 1. Data Classification

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.1.1** | Verify that regulated private data is stored encrypted while at rest, such as Personally Identifiable Information (PII), sensitive personal information, or data assessed likely to be subject to EU's GDPR. | 2 | 311 | Valid |
| **6.1.2** | Verify that regulated health data is stored encrypted while at rest, such as medical records, medical device details, or de-anonymized research records. | 2 |  311 | Not Valid |
| **6.1.3** | Verify that regulated financial data is stored encrypted while at rest, such as financial accounts, defaults or credit history, tax records, pay history, beneficiaries, or de-anonymized market or research records. | 2 |  311 | Valid |

## Analysis

- 6.1.1: is valid due to the nature of the e-commerce application, which will need to store important information such as address or payment info which can be used to identify a person. SQL, the chosen database for the project, does encryption that guarantees the complience of this criteria.
- 6.1.2: Not applicable for the application as it will not need or use health related data.
- 6.1.3: The application will not use financial data such as the ones mentioned in the description so this does not apply.

## 2. Algorithms
| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.2.1** | Verify that all cryptographic modules fail securely, and errors are handled in a way that does not enable Padding Oracle attacks. | 1 | 310 | Valid |
| **6.2.2** | Verify that industry proven or government approved cryptographic algorithms, modes, and libraries are used, instead of custom coded cryptography. | 2 |  327 | Valid |
| **6.2.3** | Verify that encryption initialization vector, cipher configuration, and block modes are configured securely using the latest advice. | 2 |  326 | Not Valid |
| **6.2.4** | Verify that random number, encryption or hashing algorithms, key lengths, rounds, ciphers or modes, can be reconfigured, upgraded, or swapped at any time, to protect against cryptographic breaks. | 2 |  326 | Valid |
| **6.2.5** | Verify that known insecure block modes (i.e. ECB, etc.), padding modes (i.e. PKCS#1 v1.5, etc.), ciphers with small block sizes (i.e. Triple-DES, Blowfish, etc.), and weak hashing algorithms (i.e. MD5, SHA1, etc.) are not used unless required for backwards compatibility. | 2 |  326 | Valid |
| **6.2.6** | Verify that nonces, initialization vectors, and other single use numbers must not be used more than once with a given encryption key. The method of generation must be appropriate for the algorithm being used. | 2 |  326 | Valid |
| **6.2.7** | Verify that encrypted data is authenticated via signatures, authenticated cipher modes, or HMAC to ensure that ciphertext is not altered by an unauthorized party. | 3 |  326 | Not Valid |
| **6.2.8** | Verify that all cryptographic operations are constant-time, with no 'short-circuit' operations in comparisons, calculations, or returns, to avoid leaking information. | 3 |  326 | Not Valid |

## Analysis

- 6.2.1: Errors will be handled by use of the Encrypt then MAC construction which will guarantee that the Message Authentication Code is applied to the cipher text and allow the program to see if the encryption is unsafe before it is looked at.
- 6.2.2: All forms of encryption to be used will follow well known encryption methods using the OpenSSL library.
- 6.2.3: Due to the scope of the project, it is not feasible to guarantee this criteria.
- 6.2.4: All uses of encryption will be modular to allow for updates or changes in future iterations of the application.
- 6.2.5: The application will not feature any of the mentioned old encryption methods.
- 6.2.6: The OpenSSL library can be used to guarantee that this criteria is followed, the use of random data created by it can be used to generate nonces or other values for example, without the same value being used more than once.
- 6.2.7: Although possible, the application will not be using authentications to guarantee that the ciphertext has not been altered due to the complexity of the implementation of the feature.
- 6.2.8: This criteria is important because many cryptography attacks use timing attacks to access private data, libraries such as OpenSSL can provide implementations that are contant-time in order to lessen the chances of these attacks happening, this however, is not applicable due to the complexity of the implementation.

## 3. Random Values
| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.3.1** | Verify that all random numbers, random file names, random GUIDs, and random strings are generated using the cryptographic module's approved cryptographically secure random number generator when these random values are intended to be not guessable by an attacker. | 2 | 338 | Valid |
| **6.3.2** | Verify that random GUIDs are created using the GUID v4 algorithm, and a Cryptographically-secure Pseudo-random Number Generator (CSPRNG). GUIDs created using other pseudo-random number generators may be predictable. | 2 | 338 | Valid |
| **6.3.3** | Verify that random numbers are created with proper entropy even when the application is under heavy load, or that the application degrades gracefully in such circumstances. | 3 | 338 | Not Valid |

## Analysis

- 6.3.1: This criteria will be met with the use of the library OpenSSL, where all random values will be generated from it, guaranteeing that they are not easily guessable by an outsider.
- 6.3.2: OpenSSL RAND function can be used as a CSPRNG, and will be used for the creation of Guids.
- 6.3.3: This criteria is not necessery in the context of an e-commerce application, where the risks for vulnerabilities in heavy load are minimal. 

## 4. Secret Management
| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.4.1** | Verify that a secrets management solution such as a key vault is used to securely create, store, control access to and destroy secrets. | 2 | 798 | Valid/ Not Applicable |
| **6.4.2** | Verify that key material is not exposed to the application but instead uses an isolated security module like a vault for cryptographic operations.  | 2 | 320 | Valid/ Not Applicable |

## Analysis

- 6.4.1: This criteria can be valid, as all encryption keys should be stored in a key vault to make sure it is secured, however, for this project, in an academic context, it does not make sense to implement such a feature.
- 6.4.2: Like the criteria above, it does not make sense in an academic context to implement isolated vaults for cryptographic operations.