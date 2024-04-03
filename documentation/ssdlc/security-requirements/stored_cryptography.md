<h1>Stored Cryptography<h1>

## Objective

This section serves to validade that the software will follow the OWASP ASVS Standard, in the case of Cryptography, the interest is mainly on correctely deciding what data needs to be encrypted, how the encryption algorithm will work, and to guarantee that the generated keys are safely managed.

## 1. Data Classification

| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.1.1** | Verify that regulated private data is stored encrypted while at rest, such as Personally Identifiable Information (PII), sensitive personal information, or data assessed likely to be subject to EU's GDPR. | 2 | 311 | Valid |
| **6.1.2** | Verify that regulated health data is stored encrypted while at rest, such as medical records, medical device details, or de-anonymized research records. | 2 |  311 | Not Valid |
| **6.1.3** | Verify that regulated financial data is stored encrypted while at rest, such as financial accounts, defaults or credit history, tax records, pay history, beneficiaries, or de-anonymized market or research records. | 2 |  311 | Valid |

## 2. Algorithms
| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.2.1** | Verify that all cryptographic modules fail securely, and errors are handled in a way that does not enable Padding Oracle attacks. | 1 | 310 | Valid |
| **6.2.2** | Verify that industry proven or government approved cryptographic algorithms, modes, and libraries are used, instead of custom coded cryptography. | 2 |  327 | Valid |
| **6.2.3** | Verify that encryption initialization vector, cipher configuration, and block modes are configured securely using the latest advice. | 2 |  326 | Valid |
| **6.2.4** | Verify that random number, encryption or hashing algorithms, key lengths, rounds, ciphers or modes, can be reconfigured, upgraded, or swapped at any time, to protect against cryptographic breaks. | 2 |  326 | Valid |
| **6.2.5** | Verify that known insecure block modes (i.e. ECB, etc.), padding modes (i.e. PKCS#1 v1.5, etc.), ciphers with small block sizes (i.e. Triple-DES, Blowfish, etc.), and weak hashing algorithms (i.e. MD5, SHA1, etc.) are not used unless required for backwards compatibility. | 2 |  326 | Valid |
| **6.2.6** | Verify that nonces, initialization vectors, and other single use numbers must not be used more than once with a given encryption key. The method of generation must be appropriate for the algorithm being used. | 2 |  326 | Valid |
| **6.2.7** | Verify that encrypted data is authenticated via signatures, authenticated cipher modes, or HMAC to ensure that ciphertext is not altered by an unauthorized party. | 3 |  326 | Not Valid |
| **6.2.8** | Verify that all cryptographic operations are constant-time, with no 'short-circuit' operations in comparisons, calculations, or returns, to avoid leaking information. | 3 |  326 | Not Valid |

## 3. Random Values
| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.3.1** | Verify that all random numbers, random file names, random GUIDs, and random strings are generated using the cryptographic module's approved cryptographically secure random number generator when these random values are intended to be not guessable by an attacker. | 2 | 338 | Valid |
| **6.3.2** | Verify that random GUIDs are created using the GUID v4 algorithm, and a Cryptographically-secure Pseudo-random Number Generator (CSPRNG). GUIDs created using other pseudo-random number generators may be predictable. | 2 | 338 | Valid |
| **6.3.3** | Verify that random numbers are created with proper entropy even when the application is under heavy load, or that the application degrades gracefully in such circumstances. | 3 | 338 | Not Valid |

## 4. Secret Management
| # | Description | ASVS Level |  CWE | Valid |
| :---: | :--- | :---: |  :---: | :---: |
| **6.4.1** | Verify that a secrets management solution such as a key vault is used to securely create, store, control access to and destroy secrets. | 2 | 798 | Valid |
| **6.4.2** | Verify that key material is not exposed to the application but instead uses an isolated security module like a vault for cryptographic operations.  | 2 | 320 | Valid |