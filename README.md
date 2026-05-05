The IT Book Online Shop API
Overview
This project is a RESTful API built with **ASP.NET Core 8.0** that allows users to:
- Register and login
- View a list of IT books from external API
- Like books and store them in a database


Tech Stack
- .NET 8 Web API
- Entity Framework Core
- SQLite
- HttpClient (External API)
- Swagger (API testing)
- BCrypt (Password hashing)


External API
- https://api.itbook.store/1.0/search/mysql


How to Run
1. Clone Repository
```bash
git clone https://github.com/your-username/it-book-online-shop.git
cd it-book-online-shop
```
2. Install Dependencies
```bash
dotnet restore
```
3. Setup Database
```bash
dotnet ef database update
```
4. Run Application
```bash
dotnet run
```


Application URL
- https://localhost:5001
- http://localhost:5000

Swagger UI:
- https://localhost:5001/swagger


API Endpoints
1. Register
POST `/register`
Request:
```json
{
  "username": "test",
  "password": "123456",
  "fullname": "Test User"
}
```

Response:
```json
{
  "id": 1,
  "username": "test",
  "fullname": "Test User"
}
```


2. Login
POST `/login`
Request:
```json
{
  "username": "test",
  "password": "123456"
}
```

Response:
```json
{
  "id": 1,
  "username": "test",
  "fullname": "Test User"
}
```


3. Get Books
GET `/books`
Response:
```json
[
  {
    "title": "MySQL Cookbook",
    "isbn13": "9781449374020",
    "price": "$40.00",
    "image": "https://...",
    "subtitle": "...",
    "url": "https://..."
  }
]
```

- Data is fetched from external API
- Sorted alphabetically (A-Z) by title


4. Like Book
POST `/user/like`
Request:
```json
{
  "userId": 1,
  "bookId": "9781449374020"
}
```

Response:
```json
"Liked successfully"
```

Database
Users Table
| Column    | Type            |
| --------- | --------------- |
| Id        | int             |
| Username  | string          |
| Password  | string (hashed) |
| Fullname  | string          |
| CreatedAt | datetime        |


LikedBooks Table
| Column    | Type            |
| --------- | --------------- |
| Id        | int             |
| UserId    | int (FK)        |
| BookId    | string (isbn13) |
| CreatedAt | datetime        |


Validation & Rules

- Username must be unique
- Password is stored as hashed (BCrypt)
- A user cannot like the same book more than once
- BookId must be a valid ISBN-13 string


Error Handling
- 400 Bad Request → invalid input / duplicate data
- 401 Unauthorized → invalid login
- 404 Not Found → user not found
- 500 Internal Server Error → unexpected error


Author
Wattanasin


Notes

- Swagger is enabled in development mode
- SQLite database file: `app.db`
- Make sure ports 5000 / 5001 are available
- Test APIs using Swagger or Postman
