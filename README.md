> [!IMPORTANT]
> This is a educational project made by Joel Hellberg.
> With the intent to learn basic API operations.
<br>

# LoanAPI

>[!NOTE]
>I've created a API that will handle loan applications for a bank.
<br>

## Testade CRUD Funktioner i APIet
- [x] GET 
- [x] POST 
- [x] PUT
- [x] DELETE
<br>

## Data Model

### LoanApplication

>[!NOTE]
>Here is a list of the properties of the Loan Application

- Id: Unique identifier for the loan application.

- Borrower: User object representing the borrower's details (Id, FirstName, LastName, Income).

- Amount: The requested loan amount.

- Status: Enumeration representing the status of the loan application (e.g., Submitted, Approved, Rejected).

- Date: Date and time when the loan application was submitted or updated.

<br>

## API Endpoints

>[!NOTE]
>Below i will list all endpoints and their respective usages.
<br>

### 1. Retrieve all Loan Applications
Endpoint: GET /api/Loans
Returns a list of all loan applications.
<br>

### 2. Retrieve Loan Applications by Status
Endpoint: GET /api/Loans/status/{status}
Status: Options representing the status of the loan application (e.g., Submitted, Approved, Rejected).
Returns a list of loan applications filtered by the specified status.
<br>

### 3. Retrieve Loan Application by ID
Endpoint: GET /api/Loans/{id}
id: Unique identifier of the loan application.
Returns the details of a specific loan application identified by its ID.
<br>

### 4. Retrieve Loan Applications by User ID
Endpoint: GET /api/Loans/user/{userId}
userId: Unique identifier of the user.
Returns a list of loan applications associated with the specified user ID.
<br>

### 5. Create a New Loan Application
Endpoint: POST /api/Loans
Creates a new loan application.
Request Body: LoanApplication object with details of the new application.
Response: Returns the created loan application with a unique ID.
<br>

### 6. Update an Existing Loan Application
Endpoint: PUT /api/Loans/{id}
id: Unique identifier of the loan application to be updated.
Updates the details of an existing loan application.
Request Body: LoanApplication object with updated details.
Response: Returns the updated loan application.
<br>

### 7. Delete a Loan Application
Endpoint: DELETE /api/Loans/{id}
id: Unique identifier of the loan application to be deleted.
Deletes a specific loan application.
Response: Returns no content upon successful deletion.
<br>

## Error Handling

>[!NOTE]
>Here is a list of all errorhandling.

- 404 Not Found: Returned when attempting to access a resource that does not exist (e.g., invalid ID).

- 400 Bad Request: Returned when the request body or parameters are invalid (e.g., negative Borrower ID or Amount).

- 201 Created: Returned upon successful creation of a new loan application.

- 200 OK: Returned for successful retrieval, update, or deletion of loan applications.
<br>

## Usage Examples

>[!TIP]
>Retrieve all loan applications: GET /api/Loans

>[!TIP]
>Retrieve applications with status 'Approved': GET /api/Loans/status/Approved

>[!TIP]
>Retrieve details of a specific loan application: GET /api/Loans/{id}

>[!TIP]
>Retrieve applications associated with a specific user: GET /api/Loans/user/{userId}

>[!WARNING]
>Create a new loan application: POST /api/Loans

>[!WARNING]
>Update an existing loan application: PUT /api/Loans/{id}

>[!CAUTION]
>Delete a loan application: DELETE /api/Loans/{id}
