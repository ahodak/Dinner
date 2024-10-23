# Dinner API

## Create Menu

### Create Menu Request

```js
POST {{host}}/hosts/{hostId}/menus
```

```json
{
    "name": "Yammy Menu",
    "description": "A menu with yammy food",
    "sections": [
        {
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ]
}
```

#### Create Menu Response

```js
200 OK
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Yammy Menu",
    "description": "Description",
    "sections": [
        {
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ]
}
```
