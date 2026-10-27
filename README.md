# Portfolio Backend API

Dit is de backend API voor mijn portfolio website, gebouwd met ASP.NET Core (.NET 10) en Entity Framework Core. De API slaat gegevens op in een Microsoft SQL Server database.

---

## 1. Wat doet dit project?
Met deze API kun je twee dingen beheren:
- Projects: Portfolio projecten (titel, beschrijving, categorie, GitHub link).
- Blogposts: Blogartikelen (titel, inhoud, auteur, publicatiedatum).

Elk onderdeel ondersteunt volledige CRUD-functionaliteit:
- Create: Nieuw item toevoegen via POST
- Read: Alles ophalen of per ID via GET
- Update: Gegevens aanpassen via PUT
- Delete: Verwijderen via DELETE

---

## 2. Hoe is de code opgebouwd? (Architectuur)
De applicatie werkt in lagen volgens het 'Separation of Concerns'-principe:

1. Controllers: Ontvangen het HTTP-verzoek van de frontend en sturen het juiste antwoord terug (bijv. 200 OK of 201 Created).
2. Services: Bevatten de logica en zetten inkomende DTO's om naar database-modellen.
3. Data (DbContext): Verzorgt de communicatie met Microsoft SQL Server via Entity Framework Core.
4. DTO's: Zorgen dat de gebruiker geen ID hoeft mee te geven bij het aanmaken van een item.

---

## 3. Handleiding: Hoe start je dit project op?

### Vereisten
- .NET 10 SDK
- Docker Desktop

### Stappenplan

1. Start de database (Docker):
docker run -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD=YourStrongPassw0rd -p 1433:1433 --name portfolio-sql -d mcr.microsoft.com/azure-sql-edge

2. Maak de tabellen aan:
dotnet ef database update

3. Start de API:
dotnet run

4. Open Swagger UI in je browser:
http://localhost:5188/swagger

---

## 4. Voorbeelden van verzoeken (JSON)

### Voorbeeld: Project toevoegen (POST /api/Projects)
{
  "titel": "Portfolio Website",
  "beschrijving": "Mijn persoonlijke portfolio gebouwd met ASP.NET Core",
  "categorie": "Web Development",
  "gitHubUrl": "https://github.com/FilipHHS/portfolio-backend",
  "datum": "2026-10-27T10:00:00Z"
}

### Voorbeeld: Blogpost toevoegen (POST /api/Blogposts)
{
  "titel": "Leren werken met EF Core",
  "inhoud": "Vandaag heb ik Entity Framework Core gekoppeld aan SQL Server via Docker.",
  "auteur": "Filip",
  "datum": "2026-10-27T10:00:00Z"
}
