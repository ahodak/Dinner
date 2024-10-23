# Domain Model

## Menu

```csharp
class Manu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Yammy Menu",
    "description": "A menu with yammy food",
    "averageRating": 4.5,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Fried Picklers",
                    "description": "Deep fried picklers",
                    "price": 5
                },
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Fish and chips",
                    "description": "Fried fish and potaitous chips",
                    "price": 5.59
                },
            ]
        },
    ],
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z",
    "hostId": "00000000-0000-0000-0000-000000000000",
    "dinnerIds": [
        "00000000-0000-0000-0000-000000000000",
    ],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000000",
    ],
}
```
