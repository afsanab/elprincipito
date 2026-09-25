# Language Reader 

A language-learning reading companion where users can browse short children's stories, look up words, and save unfamiliar vocabulary to a personal list.

## About

Language Reader helps language learners transition from studying vocabulary to reading authentic text by providing:
- Browse children's stories in your target language
- Read stories with instant word lookup
- Look up definitions for unfamiliar words
- Save vocabulary to a personal collection
- Review and manage your saved words

Built with C# and ASP.NET Core following sprint-based Agile development.

## Tech Stack

**Backend**
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- xUnit (testing)
- Swagger/OpenAPI

**Frontend**
- Razor Pages
- HTML/CSS
- JavaScript

**Architecture**
```
Razor Pages
    ↓
REST API
    ↓
Controllers
    ↓
Services
    ↓
EF Core
    ↓
SQLite
```

## Getting Started

### Prerequisites
- .NET 6.0 or higher
- SQLite

### Installation

1. Clone the repository
```bash
git clone <repository-url>
cd elprincipito
```

2. Navigate to the API project
```bash
cd LanguageReader.API
```

3. Restore dependencies
```bash
dotnet restore
```

4. Run the application
```bash
dotnet run
```

5. Access the application
- API: `https://localhost:5001`
- Swagger UI: `https://localhost:5001/swagger`

## API Endpoints

### Books
- `GET /api/books` - Get all available stories
- `GET /api/books/{id}` - Get a specific story

### Words
- `GET /api/words/{word}` - Look up a word definition

### Saved Vocabulary
- `GET /api/savedwords` - Get all saved words
- `POST /api/savedwords` - Save a word to vocabulary list
- `DELETE /api/savedwords/{id}` - Remove a saved word


Run tests:
```bash
dotnet test
```
