# Language Reader 📚

A language-learning reading companion where users can browse short children's stories, look up words, and save unfamiliar vocabulary to a personal list.

## 🎯 About

Language Reader helps language learners transition from studying vocabulary to reading authentic text by providing:
- Browse children's stories in your target language
- Read stories with instant word lookup
- Look up definitions for unfamiliar words
- Save vocabulary to a personal collection
- Review and manage your saved words

Built with C# and ASP.NET Core following sprint-based Agile development.

## 🛠️ Tech Stack

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

## 🚀 Getting Started

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

## 📋 API Endpoints

### Books
- `GET /api/books` - Get all available stories
- `GET /api/books/{id}` - Get a specific story

### Words
- `GET /api/words/{word}` - Look up a word definition

### Saved Vocabulary
- `GET /api/savedwords` - Get all saved words
- `POST /api/savedwords` - Save a word to vocabulary list
- `DELETE /api/savedwords/{id}` - Remove a saved word

## 📅 Two-Week MVP Roadmap

### Week 1 — Backend Development

#### Day 1 — Project + Architecture
- [x] ASP.NET Core Web API project
- [x] Project structure
- [x] Swagger/OpenAPI configuration
- [x] First working endpoint

#### Day 2 — Database
- [x] `Book` model (Id, Title, Author, Language, Text)
- [x] `AppDbContext`
- [x] SQLite connection
- [x] Initial migration

#### Day 3 — Books Endpoints
- [x] `GET /api/books`
- [x] `GET /api/books/{id}`
- [x] Seed 3-5 children's stories
- [x] HTTP response handling (200, 404)

#### Day 4 — Word Lookup
- [x] `Word` model (Id, WordText, Definition, Language)
- [x] `GET /api/words/{word}` endpoint
- [x] Seed 20-30 vocabulary words
- [x] Dictionary functionality

#### Day 5 — Save Vocabulary 🎉
- [x] `SavedWord` model (Id, WordId, BookId, DateSaved)
- [x] Foreign key relationships
- [x] `POST /api/savedwords`
- [x] `GET /api/savedwords`
- **Core product complete** ✅

#### Day 6 — Delete + Validation
- [x] `DELETE /api/savedwords/{id}`
- [x] Model validation (missing book, missing word, duplicates)
- [x] Error handling for invalid requests

#### Day 7 — Backend Cleanup
- [x] Service layer extraction
- [x] Dependency injection
- [x] `IBookService`, `IWordService`, `ISavedWordService`

### Week 2 — Frontend & Polish

#### Day 8 — Basic Frontend
- [ ] Razor Pages setup
- [ ] Book list page
- [ ] Book detail/reading page

#### Day 9 — Word Lookup UI
- [ ] Clickable words in story text
- [ ] Word definition display
- [ ] "Save Word" functionality

#### Day 10 — Vocabulary Page
- [ ] "My Vocabulary" page
- [ ] Saved words list with definitions
- [ ] Story source display
- [ ] Delete word functionality

#### Day 11 — Automated Tests
- [ ] xUnit test project
- [ ] Book endpoint tests
- [ ] Saved words tests
- [ ] Validation and error handling tests

#### Day 12 — Error Handling + Polish
- [ ] Global exception handling
- [ ] HTTP status code verification
- [ ] Bug fixes

#### Day 13 — Documentation
- [ ] Complete README
- [ ] Screenshots (book list, reading page, word lookup, vocabulary, Swagger)
- [ ] Installation instructions

#### Day 14 — Final Polish
- [ ] Bug fixes
- [ ] Repository cleanup
- [ ] Final documentation review

## NOT in MVP (Version 2+)

These features are saved for future versions:
- User authentication/login
- JWT authorization
- Multiple language support
- AI integration
- Flashcard system
- Spaced repetition algorithms
- TV/movie recommendations
- External media APIs
- Mobile app
- Cloud deployment
- External dictionary API integration

## 🎯 Future Features

Planned enhancements for Version 2+:
- [ ] User authentication and personal accounts
- [ ] Support for multiple languages (Spanish, French, German, etc.)
- [ ] External dictionary API integration
- [ ] Audio pronunciation
- [ ] Example sentences in context
- [ ] Flashcard system
- [ ] Spaced repetition for vocabulary review
- [ ] Reading difficulty levels
- [ ] Progress tracking and statistics
- [ ] PostgreSQL for production
- [ ] Cloud deployment (Azure/AWS)

## 🧪 Testing

Run tests:
```bash
dotnet test
```
