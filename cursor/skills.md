---
name: elprincipito
description: Project skill for El Principito (Language Reader), a two-week MVP language-learning reading companion built with C#, ASP.NET Core, Razor Pages, EF Core, and SQLite. Solo project following sprint-based development. Use for any work in this repository - features, endpoints, models, tests, frontend, README, or scope questions.
alwaysApply: true
---

# El Principito (Language Reader) - Project Skill

## 1. What we are building

A language-learning reading companion. A learner browses short children's stories, reads one, clicks a word they don't know, sees its definition, and saves it to a personal vocabulary list they can review and prune later.

The single user journey the whole project exists to serve:

```
Open app -> choose story -> read -> click unfamiliar word -> see definition
        -> save word -> open vocabulary -> review -> delete
```

If a change does not make that loop work better, it is out of scope.

## 2. Why it is built this way

This is a portfolio project for a solo developer on a hard fourteen-day deadline, worked in 20-minute sprints, three sprints per day. The goal is not maximum features. The goal is a small, complete, correct application with clean architecture, real tests, and a repository that survives being read by an interviewer.

Two failure modes to actively prevent:

- **Scope creep.** A buggy half-finished app with ten features is worth less than a working app with seven.
- **Unexplainable code.** The developer must be able to explain every major component in an interview. Prefer the boring, conventional solution that a junior can defend over the clever one.

## 3. Scope - this is a hard boundary

### In the MVP

A user can:

- View available children's stories
- Open and read a story
- Look up a word from the story
- See its definition
- Save the word
- View their saved vocabulary
- Delete a saved word

The backend includes: ASP.NET Core Web API, Entity Framework Core, SQLite, REST endpoints, database relationships, Swagger, basic validation, basic automated tests, Git/GitHub.

The frontend uses Razor Pages.

### Explicitly NOT in the MVP

Accounts/login, JWT, multiple languages, AI features, flashcards, spaced repetition, TV/movie recommendations, external media or dictionary APIs, React (or any frontend framework), cloud deployment, mobile app.

### How to handle a new idea

When a feature outside the list above comes up - including when the assistant thinks of it - do not build it. Do not scaffold it "so it's easy to add later." Write it into `FUTURE_FEATURES.md` or open a GitHub issue labelled `Future Feature`, then return to the current sprint.

Standing backlog:

```
Future Features
  [] User authentication
  [] Multiple languages
  [] External dictionary API
  [] Pronunciation
  [] Example sentences
  [] Flashcards
  [] Spaced repetition
  [] Reading difficulty levels
  [] Media recommendations
  [] Progress tracking
  [] PostgreSQL
  [] Cloud deployment
```

After the two weeks this backlog becomes a genuine talking point: "I am continuing development, with planned features including authentication, external dictionary integration, and personalized vocabulary review."

## 4. Architecture

```
Razor Pages
    |
REST API (Controllers)
    |
  Services
    |
Entity Framework Core
    |
  SQLite
```

Rules:

- Controllers handle HTTP only: bind the request, call a service, map the result to a status code. No EF queries in controllers once the service layer exists (Day 7).
- Services hold business logic and talk to `AppDbContext`.
- Everything is wired through built-in dependency injection in `Program.cs`. No service locator, no static state.
- One project for the API, one for tests. Do not split into six projects for a two-week MVP.

```
elprincipito/
  LanguageReader.API/
    Controllers/
    Models/
    Services/
    Data/            AppDbContext, migrations, seed data
    Pages/           Razor Pages (Index, Books, Vocabulary)
    wwwroot/         CSS, JavaScript
    Program.cs
  LanguageReader.Tests/
  .gitignore
  README.md
  FUTURE_FEATURES.md
```

## 5. Domain model

```
Book                     Word                     SavedWord
  Id                       Id                       Id
  Title                    WordText                 WordId  -> Word
  Author                   Definition               BookId  -> Book
  Language                 Language                 DateSaved
  Text
```

Relationships: a `Book` has many `SavedWord`s; a `Word` has many `SavedWord`s. `SavedWord` is the join between "a word I looked up" and "the story I met it in", plus when I saved it.

Notes:

- `Book.Text` is the full story body, stored as text in the database. Public-domain or self-written short texts only.
- Seed 3-5 stories and 20-30 vocabulary words drawn from those stories. Seed data lives in code or a seed file under `Data/`, applied at startup or via migration.
- The dictionary is our own seeded `Word` table. Do not integrate an external dictionary API during the MVP.

## 6. API contract

| Method | Route | Success | Failure |
| --- | --- | --- | --- |
| GET | `/api/books` | 200 with list | - |
| GET | `/api/books/{id}` | 200 with book | 404 |
| GET | `/api/words/{word}` | 200 with word | 404 |
| POST | `/api/savedwords` | 201 with created | 400 invalid, 404 missing book/word, 409 or 400 duplicate |
| GET | `/api/savedwords` | 200 with list | - |
| DELETE | `/api/savedwords/{id}` | 204 | 404 |

Example lookup response:

```json
{ "word": "casa", "definition": "house", "language": "Spanish" }
```

Example save request:

```json
{ "wordId": 12, "bookId": 2 }
```

`GET /api/savedwords` returns each saved word with its definition and the story it came from, so the vocabulary page needs one call:

```
casa | house | El Principito
```

Validation to enforce: the referenced book exists, the referenced word exists, the same word is not saved twice for the same book. Return meaningful status codes and a readable message, never a raw exception.

## 7. Working conventions

- Swagger must stay working for the whole project. It is both a manual test tool and a screenshot for the README.
- Async EF Core methods (`ToListAsync`, `FindAsync`) throughout.
- DTOs for request and response shapes where the entity would leak fields the client should not send. Do not build a mapping framework; hand-write the projections.
- Keep the frontend to three files. No build step, no npm, no bundler.
- Nothing secret in the repo. `.gitignore` covers `bin/`, `obj/`, and the SQLite database file.
- Commits are small and messages say what changed and why. Work goes through branches and pull requests, reviewed by the other developer - this is a deliberate resume point, not ceremony.

## 8. Fourteen-day plan

Three 20-minute sprints per day. Each day has an end state; do not move on without it.

### Week 1 - build the backend

**Day 1 - project and architecture.** Learn what an API, HTTP endpoint, JSON payload, and controller are. Create the solution and `LanguageReader.API`, get it running. Get Swagger working.
*End state: running API with Swagger and one working endpoint.*

**Day 2 - database.** Learn ORM, `DbContext`, `DbSet`, migrations. Create the `Book` model. Create `AppDbContext`, configure SQLite, create the first migration.
*End state: C# model -> EF Core -> SQLite.*

**Day 3 - books.** Build `GET /api/books`. Build `GET /api/books/{id}` with 200 and 404. Add 3-5 short stories.
*End state: books can be retrieved from the database.*

**Day 4 - word lookup.** Create the `Word` model and learn EF Core entity relationships. Build `GET /api/words/{word}`. Seed 20-30 vocabulary words from the stories.
*End state: a functioning dictionary.*

**Day 5 - save vocabulary. The most important day.** Design `SavedWord`; learn foreign keys and one-to-many relationships in EF Core. Build `POST /api/savedwords`. Build `GET /api/savedwords`.
*End state: the core product exists - read, encounter, look up, save, review.*

**Day 6 - delete and validation.** Build `DELETE /api/savedwords/{id}`. Learn ASP.NET Core model validation; handle missing book, missing word, duplicate saved word. Test every endpoint by hand in Swagger against a checklist: GET books, GET book, GET word, POST saved word, GET saved words, DELETE saved word, invalid requests handled.

**Day 7 - cleanup. Add no features.** Introduce the service layer and move business logic out of controllers. Clean up dependency injection. Git cleanup - learn branching and pull requests, and make sure both developers have contributed through GitHub.
*End of Week 1: a functional backend.*

### Week 2 - make it a portfolio project

Week 1 proves "I can build a backend." Week 2 proves "I can build software."

**Day 8 - basic frontend.** Set up Razor Pages. Build a book list page. Clicking a book navigates to the reading page with the story text.

**Day 9 - word lookup UI.** Make words in the story clickable using JavaScript. On click, call `GET /api/words/{word}` and show the word, its definition, and a SAVE WORD button.
*End state: it now looks like an application.*

**Day 10 - vocabulary page.** Build "My Vocabulary" Razor Page. Call `GET /api/savedwords` and show word, definition, and source story. Add delete buttons.
*End state: the whole user workflow runs through the UI.*

**Day 11 - automated tests.** Learn xUnit: test, assertion, Arrange/Act/Assert. Test GET book and GET nonexistent book. Test save word and delete word. Five to ten good tests is plenty.

**Day 12 - error handling and polish.** Learn ASP.NET Core exception handling so unexpected errors do not return ugly responses. Audit status codes: 200, 201, 400, 404. Then walk the entire flow as a user from zero. If it works end to end, stop adding features.

**Day 13 - GitHub and README.** Write the README: project description, features, tech stack, architecture diagram. Add screenshots of the book list, reading page, word definition, vocabulary page, and Swagger. Screenshots make a large difference to how the repository reads.

**Day 14 - final bug hunt and resume.** Try to break it: nonexistent book, nonexistent word, duplicate word, empty request, deleting a nonexistent word. Fix what is obvious. Final repo pass: README, screenshots, installation instructions, API documentation, meaningful commits, no secrets, `.gitignore`, clean structure. Then write the resume entry.

Target resume entry:

> **Language Learning Reading Companion** | C#, ASP.NET Core, Entity Framework Core, SQLite
> - Developed a RESTful API for a language-learning application that allows users to browse reading materials, look up unfamiliar vocabulary, and maintain a persistent vocabulary collection.
> - Designed relational data models and implemented database persistence using Entity Framework Core and SQLite.
> - Built and tested REST endpoints with validation, error handling, and automated unit tests, and developed a lightweight JavaScript frontend to consume the API.

## 9. Two-developer split

Ownership is split rather than both people writing every line together:

- **Developer A** - API and database: ASP.NET Core setup, EF Core, database, controllers, tests.
- **Developer B** - API and application integration: book endpoints, vocabulary endpoints, frontend, Swagger and documentation, testing.

Both must understand the entire system well enough to explain any component in an interview, regardless of who wrote it. All work goes through pull requests with review by the other developer.

## 10. How the assistant should behave in this repo

- Check any request against Section 3 first. If it is out of scope, say so, offer to add it to `FUTURE_FEATURES.md`, and do not write the code.
- Prefer the smallest change that satisfies the current day's end state. Do not refactor beyond the sprint.
- Do not introduce a library, pattern, or abstraction that is not already named in this file - no AutoMapper, MediatR, repository-over-repository layers, or frontend frameworks.
- Explain the reasoning briefly alongside code, since both developers need to be able to defend it. Point to the concept to search for rather than dumping a finished solution when the day's plan calls for learning.
- When something is ambiguous, ask rather than inventing a requirement.