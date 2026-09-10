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
- [x] Create ASP.NET Core Web API project
- [x] Set up project structure
- [x] Configure Swagger/OpenAPI
- [x] First working endpoint

#### Day 2 — Database
- [x] Create `Book` model (Id, Title, Author, Language, Text)
- [x] Create `AppDbContext`
- [x] Configure SQLite connection
- [x] Create initial migration

#### Day 3 — Books Endpoints
- [x] Implement `GET /api/books`
- [x] Implement `GET /api/books/{id}`
- [x] Add 3-5 children's stories to database
- [x] Handle 200 OK and 404 Not Found responses

#### Day 4 — Word Lookup
- [x] Create `Word` model (Id, WordText, Definition, Language)
- [x] Implement `GET /api/words/{word}` endpoint
- [x] Seed 20-30 vocabulary words from stories
- [x] Test dictionary functionality

#### Day 5 — Save Vocabulary 🎉
- [x] Create `SavedWord` model (Id, WordId, BookId, DateSaved)
- [x] Set up foreign key relationships
- [x] Implement `POST /api/savedwords`
- [x] Implement `GET /api/savedwords`
- **Core product complete** ✅

#### Day 6 — Delete + Validation
- [x] Implement `DELETE /api/savedwords/{id}`
- [x] Add model validation (missing book, missing word, duplicates)
- [ ] Test all endpoints through Swagger
  - [ ] GET books
  - [ ] GET single book
  - [ ] GET word lookup
  - [ ] POST saved word
  - [ ] GET saved words
  - [ ] DELETE saved word
  - [ ] Invalid requests handled properly

#### Day 7 — Backend Cleanup
- [x] Extract service layer from controllers
- [x] Implement dependency injection for services
- [x] Create `IBookService`, `IWordService`, `ISavedWordService`
- [ ] Git cleanup and commit history review

### Week 2 — Make it a Portfolio Project

#### Day 8 — Basic Frontend
- [ ] Set up Razor Pages
- [ ] Create book list page
- [ ] Implement fetch calls to `/api/books`
- [ ] Display clickable book titles

#### Day 9 — Word Lookup UI
- [ ] Make words in story clickable
- [ ] Display word definition modal/popup
- [ ] Add "Save Word" button
- [ ] Connect to word lookup API

#### Day 10 — Vocabulary Page
- [ ] Create "My Vocabulary" page
- [ ] Display saved words with definitions
- [ ] Show which story each word came from
- [ ] Add delete buttons for saved words

#### Day 11 — Automated Tests
- [ ] Set up xUnit test project
- [ ] Write tests for GET book endpoints
- [ ] Write tests for saved words functionality
- [ ] Test edge cases (nonexistent resources, validation)

#### Day 12 — Error Handling + Polish
- [ ] Implement global exception handling
- [ ] Verify proper HTTP status codes (200, 201, 400, 404)
- [ ] End-to-end user flow testing
- [ ] Fix any obvious bugs

#### Day 13 — GitHub + README
- [ ] Complete README with features and architecture
- [ ] Document installation instructions
- [ ] Add screenshots (book list, reading page, word lookup, vocabulary page, Swagger)
- [ ] Document API endpoints
- [ ] Add tech stack section

#### Day 14 — Final Demo + Resume
- [ ] Final bug hunt and testing
- [ ] Clean GitHub repository
  - [ ] Meaningful commit messages
  - [ ] .gitignore configured
  - [ ] No hardcoded credentials
  - [ ] Clean project structure
- [ ] Write resume entry
- [ ] Create "Future Features" list for Version 2+

## ❌ Explicitly NOT in MVP (Version 2+)

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

## 📝 License

[Add your license here]

---

*"One sees clearly only with the heart. What is essential is invisible to the eye."* - Antoine de Saint-Exupéry
