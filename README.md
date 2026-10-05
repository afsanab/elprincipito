# El Principito

A reading app for Spanish learners. Browse short children's stories, look up unfamiliar words, and save them to a vocabulary list.

I'm building it to improve my own Spanish and to bridge the gap between studying vocabulary and actually reading.

**Status:** The REST API is working. A React Native mobile app with tap-to-translate is in progress.

<!-- Add a Swagger UI screenshot or GIF here, e.g. ![Swagger UI](docs/swagger.png) -->

## Features

- Browse short Spanish children's stories
- Look up a word's definition (currently a small seeded dictionary)
- Save words to a vocabulary list, then review or remove them

## Tech stack

| Layer | Technologies |
| --- | --- |
| API | C#, ASP.NET Core Web API (.NET 8), Entity Framework Core, SQLite |
| API docs | Swagger / OpenAPI |
| Mobile app (in progress) | React Native, Expo, TypeScript |

## Architecture

```
React Native app (in progress)
        │  HTTP / JSON
        ▼
ASP.NET Core API
  Controllers → Services → EF Core
        │
        ▼
      SQLite
```

- Controllers stay thin. Business logic lives in services behind interfaces, registered with dependency injection, so it can be tested without the web layer.
- Stories load from a JSON seed file on first run, and seeding skips data that already exists.
- Word lookup is case-insensitive.

## API

| Method | Endpoint | Description |
| --- | --- | --- |
| GET | `/api/books` | List all stories |
| GET | `/api/books/{id}` | Get one story |
| GET | `/api/words/{word}` | Look up a word |
| GET | `/api/savedwords` | List saved words |
| POST | `/api/savedwords` | Save a word |
| DELETE | `/api/savedwords/{id}` | Remove a saved word |
| GET | `/api/status` | Health check |

Example request and response:

```http
GET /api/words/zorro
```

```json
{ "word": "zorro", "definition": "fox", "language": "Spanish" }
```

## Running locally

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/afsanab/elprincipito.git
cd elprincipito/LanguageReader.API
dotnet run
```

Then open http://localhost:5242/swagger to try the endpoints. Sample requests are also in `LanguageReader.API.http`.

## Roadmap to V1

- [ ] Unit tests with xUnit, run by GitHub Actions on every push
- [ ] React Native app with a tap-to-translate reading view
- [ ] A full dictionary source in place of the seeded word list
- [ ] User accounts, so each learner has their own vocabulary list

## Future 

- [ ] Expand to other common languages 
- [ ] Expand library to have a range of difficulty levels for users to advance to
