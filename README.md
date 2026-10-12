# StudyDashboard

> **Work in progress**

A personal study dashboard for managing university courses, tasks, schedules, habits, grades, and deadlines in one place.

## Planned Features

* [ ] Task management with CRUD operations
* [ ] Weekly important tasks
* [ ] Schedule and time blocking
* [ ] Habit tracking
* [ ] Course management
* [ ] Assignment and deadline tracking
* [ ] Grade tracking
* [ ] Course average calculation
* [ ] Predicted GPA
* [ ] Dashboard with an overview of important information

## Current Progress

### Authentication

* [x] Authentication
* [x] Authorization

### Course Feature

* [x] Course model and database setup
* [x] Course CRUD
* [x] DTOs and validation
* [x] Course service
* [x] User ownership/authorization
* [x] Active courses
* [x] Controller
* [x] Tests
* [ ] Filtering by semester/name

## Course API

| Method | Endpoint                 | Description         |
| ------ | ------------------------ | ------------------- |
| GET    | `/api/courses/my`        | List user's courses |
| GET    | `/api/courses/my/active` | List active courses |
| GET    | `/api/courses/{id}`      | Get course details  |
| POST   | `/api/courses`           | Create a course     |
| PUT    | `/api/courses/{id}`      | Update a course     |
| DELETE | `/api/courses/{id}`      | Delete a course     |

### Filtering

```text
GET /api/courses/my?semester=3
GET /api/courses/my?name=Algorithms
GET /api/courses/my?semester=3&name=Algorithms
```


## Current Tech Stack

* C#
* ASP.NET Core
* Entity Framework Core
* REST API
* Minimal APIs
* SQL database

The project is being developed incrementally, with the README updated as features are completed.
