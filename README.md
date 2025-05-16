# Todo API (Minimal API with Swagger)

🚀 **Project Overview**

A simple Todo API built using ASP.NET Core Minimal API. The application supports basic CRUD operations on Todo items and uses an in-memory thread-safe collection for storage.

Additionally, Swagger is integrated for interactive API documentation.

---

🛠️ **Technologies Used**

* .NET 8.0 (ASP.NET Core)
* Swagger (Swashbuckle)
* C#

---

⚙️ **Getting Started**

### Prerequisites

* .NET SDK 9.0 or higher
* cURL (for testing via terminal)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/todo-api.git
   cd todo-api
   ```

2. Restore packages:

   ```bash
   dotnet restore
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

4. Access the Swagger UI:
   Visit [http://localhost:5000/swagger](http://localhost:5000/swagger) in your browser.

---

📝 **API Endpoints**

#### 1. Get all todos

* **GET /todos**
* Example:

  ```bash
  curl -i http://localhost:5000/todos
  ```
* **Response:**

  * `200 OK`: List of todo items
  * `204 No Content`: No todo items available

#### 2. Get a specific todo

* **GET /todos/{id}**
* Example:

  ```bash
  curl -i http://localhost:5000/todos/{id}
  ```
* **Response:**

  * `200 OK`: The requested todo item
  * `404 Not Found`: No todo item found with the given ID

#### 3. Create a new todo

* **POST /todos**
* Example:

  ```bash
  curl -i -X POST http://localhost:5000/todos -H "Content-Type: application/json" -d '{"text":"Buy milk"}'
  ```
* **Response:**

  * `201 Created`: Returns the created todo item
  * `400 Bad Request`: Invalid input data

#### 4. Update a todo item

* **PUT /todos/{id}**
* Example:

  ```bash
  curl -i -X PUT http://localhost:5000/todos/{id} -H "Content-Type: application/json" -d '{"text":"Buy bread","isComplete":true}'
  ```
* **Response:**

  * `200 OK`: Updated todo item
  * `404 Not Found`: No todo item found with the given ID
  * `400 Bad Request`: Invalid input data

#### 5. Delete a todo item

* **DELETE /todos/{id}**
* Example:

  ```bash
  curl -i -X DELETE http://localhost:5000/todos/{id}
  ```
* **Response:**

  * `204 No Content`: Successfully deleted
  * `404 Not Found`: No todo item found with the given ID

---

🔥 **Testing via Swagger**

Visit [http://localhost:5000/swagger](http://localhost:5000/swagger) to explore and test the API through an interactive UI.

---

