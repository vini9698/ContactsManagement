
# Project README

## Overview
This project demonstrates expertise in Angular and ASP.NET Core, featuring a user-friendly interface for managing contacts. It includes custom middleware to handle authorization and error management, ensuring secure access and robust error handling.

## Technologies Used
- **Angular**: For building dynamic web applications with optimized code.
- **ASP.NET Core**: Used for creating a RESTful API to manage contacts.
- **JSON**: Contact data is stored in a JSON file.
- **Dependency Injection**: Applied for managing logging and services.


## Features

### Angular Application
- **Contact Management**:
  - Modals for creating and editing contacts.
  - Confirmation modals for contact deletion.
  - Efficient data processing through optimized filtering and observables.

### ASP.NET Core API for Contact Management
- **Endpoints**:
  - `GET /Contact/GetContacts`: Retrieves all contacts.
  - `GET /Contact/GetContactById`: Retrieves a specific contact by ID.
  - `POST /Contact/AddContact`: Adds a new contact.
  - `PUT /Contact/UpdateContact`: Updates an existing contact.
  - `DELETE /Contact/DeleteContact`: Deletes a contact by ID.



## Setup Instructions

### Prerequisites
Ensure the following are installed:

- **Node.js** (version 16 or higher): Download from [nodejs.org](https://nodejs.org).
- **npm**: Comes bundled with Node.js. Verify installation by running:
  ```visual studio
  node -v
  npm -v
  ```

### Installation

1. **Download the Repository**:
   ```Download Repository from <repository-url>
	Extract the Zip file
   ```

2. **Set Up Angular Client**:
   ```bash
   cd ContactsManagement-main
   cd ContactManagement.Web
   npm install
   ```

3. **Set Up ASP.NET Core API**:
   - Navigate back to the root directory:
     ```
	 Go to ContactsManagement-main
	 Open solution file in visual studio
     ```
   - set startup project:
     ```
	 Go to Visual studio=>Solution Explorer
	 Right Click on ContactManagement.API=>click Set as StartUp Project
     ```
   - Run the API application:
     ```
	 Choose 'IIS Express' and click to Run
     ```
