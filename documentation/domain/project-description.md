Project Idea: Online Comic Book Store

This system would manage comic books, customers, and orders in a online store.

**Front-end Application:**
A web-based application with a comic-themed design. Customers can browse comic books, add them to a shopping cart, and place orders. Admins can add new comic books, manage existing ones, and view customer orders.

**Back-end Application:**
A REST API that handles all the business logic and interacts with the database. It would have endpoints for managing comic books, managing customers, and managing orders.

**Database:**
A relational database that stores information about comic books, customers, and orders.

**Domain-Driven Design (DDD) Aggregates:**
1. Comic Books: Each comic book is an aggregate, with attributes such as title, authors, price, synopsis/description, publish date, edition and its cover page.
2. User: Each User is an aggregate, with attributes such as role, name, email, and password.
3. Orders: Each order is an aggregate, with attributes such as customer, ordered comic books, total cost.

**Authorization:**
Three roles will be implemented:
1. Customer: Can browse comic books, add comic books to a shopping cart, and place orders.
2. Store Clerk: Can do everything a customer can do, plus add new comic books, manage existing comic books, and view all customer orders.
3. Store Manager: Can do everything a Store Clerk can do, plus manage Store Clerk accounts.

**Operating System Functionalities:**
The back-end server could provide services such as generating a report of current orders, which would involve reading from the database, writing to a file, and saving that file in a specific directory. This report could be requested and downloaded through the front-end application by admins.
