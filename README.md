# Exami — Quiz Management System

A desktop application built with **C# WinForms** and **SQL Server** for managing exams, students, and results. The system supports two roles: **Admin** and **Student**, each with a dedicated interface and permissions.

---

## 🖥️ Tech Stack

| Layer | Technology |
|-------|-----------|
| UI | C# WinForms |
| Business Logic | C# (BLL) |
| Data Access | ADO.NET + SQL Server (DAL) |
| Architecture | Three-Tier (UI → BLL → DAL) |
| Security | SHA-256 Password Hashing, RBAC |
| DB Safety | Parameterized Stored Procedures |

---

## ✨ Features

### 🔐 Authentication
- Secure login with SHA-256 hashed passwords
- Role-Based Access Control (Admin / Student)
- **Remember Me** — saves credentials across sessions


### 👤 Admin Panel
- **User Management** — Create, Edit, Search users (filter by First Name, Role, or Gender)
- **Exam Management** — Create, Edit, Delete exams with title, date, and description
- **Question Management** — Add multiple-choice questions (4 options) to any exam
- **Find Exam / Question** — Search by Subject or Title
- **Student Results** — View all attempts with scores and submission timestamps
- **Exam Info Dashboard** — Card-based overview showing question count and creation date per exam

### 🎓 Student Panel
- Browse available exams as info cards (title, description, date, question count)
- **Take Exam** — scrollable multi-question interface with radio button answers
- **View Results** — score, correct answers, percentage, and submission date per exam

---

## 🏗️ Architecture

```
UI Layer (WinForms Forms)
        ↓
BLL — Business Logic Layer (validation, Upsert logic, business rules)
        ↓
DAL — Data Access Layer (Stored Procedures → SQL Server)
```

- **Upsert logic** in BLL handles both Create and Update in one flow, preventing duplicate records
- All DB calls go through **Parameterized Stored Procedures** to prevent SQL Injection
- **Logging Utility** with automated failover to local file if Windows Event Log is unavailable






erDiagram
    Users ||--o{ StudentAnswers : submits
    Users ||--o{ StudentAnswerHistory : logs
    Examsubject ||--o{ Questions : contains
    Examsubject ||--o{ Results : generates
    Questions ||--o{ StudentAnswers : answered
    Results ||--o{ StudentAnswerHistory : references

    Users {
        int UserID PK
        string FirstName
        string LastName
        string Username
        string Password
        datetime DateOfBirth
        tinyint Gender
        string Email
        string Address
        string ImagePath
        tinyint Role
    }

    Examsubject {
        int ExamID PK
        string Title
        string Description
        datetime2 CreatedDate
    }

    Questions {
        int QuestionID PK
        int ExamID FK
        string QuestionText
        string OptionA
        string OptionB
        string OptionC
        string OptionD
        string CorrectOption
        string Subject
    }

    Results {
        int ResultID PK
        int StudentID FK
        int ExamID FK
        int Score
        datetime SubmissionDate
    }

    StudentAnswerHistory {
        int HistoryID PK
        int StudentID FK
        int ExamID FK
        int QuestionID FK
        int ResultID FK
        string ChosenOption
        bit IsCorrect
        string ActionType
        datetime TimeSpan
    }


---

## 📸 Screenshots

### Login Screen
<img width="883" height="662" alt="login-admin" src="https://github.com/user-attachments/assets/6ebe5887-8575-4b86-99bd-415d03cef3d3" />


### Admin — Main Dashboard
<img width="1067" height="671" alt="main-admin" src="https://github.com/user-attachments/assets/0e9bc892-48a0-44ef-a0cb-51775314329b" />


### Admin — User Management (with filter)
<img width="1067" height="671" alt="list-user" src="https://github.com/user-attachments/assets/c10b0b97-29e3-46fd-a889-9ef5584d3445" />


### Admin — Exam Manager
<img width="1067" height="671" alt="list-exams-name" src="https://github.com/user-attachments/assets/206764f8-1845-4542-ac27-10f6fc3f2737" />


### Admin — Exam Info Cards
<img width="1067" height="671" alt="exam-info" src="https://github.com/user-attachments/assets/bc17366d-3d9f-4e36-b401-83de3eb3e785" />


### Login Screen student
<img width="883" height="662" alt="login-student" src="https://github.com/user-attachments/assets/ca9e3646-0d7c-41aa-a973-95b761de37d0" />


### Student — Take Exam
<img width="1065" height="662" alt="take-exam" src="https://github.com/user-attachments/assets/5f44892d-08ce-4b7d-aef6-e721acb9bdf0" />


### Student — Results
<img width="1065" height="662" alt="results-of-exams" src="https://github.com/user-attachments/assets/f0a4e67e-b05a-406a-b10f-916d221c9a8e" />


---

## ⚙️ Setup & Requirements

**Requirements:**
- Windows OS
- Visual Studio 2019+
- SQL Server (LocalDB or full instance)
- .NET Framework 4.7+

**Steps:**

1. Clone the repository
```bash
git clone https://github.com/Rayamud/ExamSystem.git<img width="883" height="662" alt="login-admin" src="https://github.com/user-attachments/assets/be67ce0d-3924-4a86-a87a-4d6a331dc463" />

```

2. Open the `.sln` file in Visual Studio

3. Run the SQL scripts in the `/Database` folder to create and seed the database

4. Update the connection string in `DAL/DBConnection.cs`

5. Build and Run (`F5`)

---

## 🔑 Default Test Credentials

| Role | Username | Password |
|------|----------|----------|
| Admin | RayaM | 1234 |
| Student | Rayaa | 123 |

> ⚠️ Change these before any real deployment.

---

## 🧠 Key Technical Decisions

**Why Three-Tier Architecture?**
Separating UI, logic, and data makes each layer independently maintainable. A change in the database doesn't cascade into the UI, and business rules stay centralized in the BLL.

**Why Stored Procedures?**
All database interactions use parameterized stored procedures — this eliminates SQL injection risk entirely at the data layer.

**Why SHA-256?**
Passwords are never stored as plain text. SHA-256 ensures that even if the database is compromised, passwords remain protected.

**Why Upsert in BLL?**
A single Save operation handles both Insert and Update depending on whether a record ID already exists. This prevents duplicate records and simplifies the UI logic.

---

## 👩‍💻 Author

**Raya Mudhfer**  
Self-taught C# developer | Baghdad, Iraq  
[GitHub](https://github.com/Rayamud)
