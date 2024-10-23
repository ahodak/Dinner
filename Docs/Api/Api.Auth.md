# Dinner API

- [Dinner API](#dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)
  - [Dinners](#dinners)
    - [List](#list)
      - [List Request](#list-request)
      - [List Response](#list-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Andrey",
    "lastName": "Khodak",
    "email": "andrey@khodak.ru",
    "password": "111"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "firstName": "Andrey",
    "lastName": "Khodak",
    "email": "andrey@khodak.ru",
    "password": "111"
}
```

### Login

#### Login Request

```js
POST {{host}}/auth/login
```

#### Login Response

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "firstName": "Andrey",
    "lastName": "Khodak",
    "email": "andrey@khodak.ru",
    "token": "eyJhb..hbbQ"
}
```

## Dinners

### List

#### List Request

```js
GET {{host}}/dinners
```

#### List Response

```json
[]
```
