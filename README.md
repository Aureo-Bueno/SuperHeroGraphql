# 🚀 SuperHero 

The project was create using .net 7, with postgres database and using graphql

## 📋 Requirements

- [SDK .NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [PostgreSQL] 

## ⚙️ Config of Projects

Clone repository:

```bash
git clone git@github.com:Aureo-Bueno/SuperHeroGraphql.git
```

### Run migrations

```bash
dotnet ef database update
```

### Run request on Postman or Insonmia

```bash
query SuperHeroes {
    superHeroes {
        id
        name
        description
    }
}
```

or with param

```bash
query SuperHeroes {
    superHeroes(where: { name: { eq: "Superman" } }) {
        id
        name
        description
    }
}

```
