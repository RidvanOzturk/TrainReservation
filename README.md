# TrainReservation API

Bir tren için rezervasyon yapýlýp yapýlamayacaðýný kontrol eden ve mümkünse yolcularý vagonlara (online %70 doluluk kuralýna göre) daðýtan basit HTTP API.

- Teknoloji: .NET 10, FastEndpoints, Clean Architecture (Domain, Application, API)
- Deploy URL: https://visual-jyoti-trainreservation-405e2576.koyeb.app
- Swagger: https://visual-jyoti-trainreservation-405e2576.koyeb.app/swagger
- Swagger Endpoint: https://visual-jyoti-trainreservation-405e2576.koyeb.app/swagger/index.html#/Api/TrainReservationApiEndpointsReservationCheckEndpoint
- HTTP Endpoint: POST `/api/reservations/check`

## Ýþ Kurallarý
- Online rezervasyonlarda bir vagonun doluluk kapasitesi %70’i geçmemelidir.
- Bir vagondaki online maksimum dolu koltuk sayýsý: `floor(Kapasite * 0.70)`.
- `KisilerFarkliVagonlaraYerlestirilebilir=false` ise tüm yolcular tek vagonda olmalýdýr.

## Ýstek Örneði
```json
{
  "Tren": {
    "Ad": "Baþkent Ekspres",
    "Vagonlar": [
      { "Ad": "Vagon 1", "Kapasite": 100, "DoluKoltukAdet": 68 },
      { "Ad": "Vagon 2", "Kapasite": 90,  "DoluKoltukAdet": 50 },
      { "Ad": "Vagon 3", "Kapasite": 80,  "DoluKoltukAdet": 80 }
    ]
  },
  "RezervasyonYapilacakKisiSayisi": 3,
  "KisilerFarkliVagonlaraYerlestirilebilir": true
}
```

## Baþarýlý Yanýt
```json
{
  "RezervasyonYapilabilir": true,
  "YerlesimAyrinti": [
    { "VagonAdi": "Vagon 1", "KisiSayisi": 2 },
    { "VagonAdi": "Vagon 2", "KisiSayisi": 1 }
  ]
}
```

## Yapýlamaz Yanýt
```json
{
  "RezervasyonYapilabilir": false,
  "YerlesimAyrinti": []
}
```

## Test Ýçin Ek Örnek
```json
{
  "Tren": {
    "Ad": "Akdeniz Ekspresi",
    "Vagonlar": [
      { "Ad": "A", "Kapasite": 100, "DoluKoltukAdet": 69 },
      { "Ad": "B", "Kapasite": 90,  "DoluKoltukAdet": 53 }
    ]
  },
  "RezervasyonYapilacakKisiSayisi": 11,
  "KisilerFarkliVagonlaraYerlestirilebilir": true
}
```
Beklenen: `RezervasyonYapilabilir=true`, daðýlým: A:1, B:10

## Proje Yapýsý
- Domain: `Train`, `Wagon`
- Application: `ReservationPlanner`, `ReservationResult`, `Placement`
- API: DTO’lar, validator, mappers, endpoint
