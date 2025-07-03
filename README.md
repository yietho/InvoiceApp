# InvoiceApp - .NET 8 & Angular 17 Fatura Yönetim Sistemi

InvoiceApp, fatura ve fatura satırlarını yönetmek için hazırlanmış full-stack bir örnek uygulamadır.  
Backend tarafı Clean Architecture prensiplerine uygun olarak .NET 8 ile, frontend tarafı ise Angular 17 ile geliştirilmiştir.

---

## Teknolojiler

### Backend (.NET 8)

- ASP.NET Core Web API (.NET 8)  
- Entity Framework Core  
- MediatR & CQRS  
- FluentValidation  
- SQL Server (MSSQL)  



## Proje Yapısı

```
InvoiceApp/
│
├── backend/                # .NET Core 8 (Clean Architecture)
│   ├── InvoiceApp.API/
│   ├── InvoiceApp.Application/
│   ├── InvoiceApp.Domain/
│   ├── InvoiceApp.Infrastructure/
│   ├── InvoiceApp.Persistence/
│   └── InvoiceApp.sln
│
├── frontend/               # Angular 17+
│   ├── src/
│   ├── angular.json
│   └── ...
│
├── .gitignore
└── README.md
```

---

## Seed Kullanıcı Bilgileri

| Kullanıcı Adı | Şifre     | CustomerId |
| ------------- | --------- | ---------- |
| yildiz        | parola123 | 1          |
| cinar         | parola123 | 2          |

---

## Kurulum Adımları

### Backend

#### MSSQL Veritabanı Oluştur

CREATE DATABASE InvoiceAppDb;
- `appsettings.json` dosyasındaki connection string’i kendinize göre düzenleyiniz.
- Migration işlemlerini uygulayınız:

---

### API Endpointleri

| Endpoint                                | Açıklama          |
| -------------------------------------- | ----------------- |
| POST /api/auth/login                   | Giriş             |
| GET /api/invoice/InvoiceList           | Fatura Listeleme  |
| POST /api/invoice/InvoiceSave          | Fatura Oluşturma  |
| PUT /api/invoice/InvoiceUpdate         | Fatura Güncelleme |
| DELETE /api/invoice/InvoiceDelete/{id} | Fatura Silme      |

---

### Frontend

#### Gereksinimler

- Node.js 18+  
- Angular CLI 17+  

#### Kurulum ve Başlatma


cd frontend/
npm install
ng serve


## Login Ekranı

Giriş yaptıktan sonra faturalar listelenir.


##  Geliştirici Notları

- Faturalar yalnızca kullanıcıya aitse düzenlenebilir.  
- Seed kullanıcılar için `IsPlainPassword = true` olduğunda parolalar hashlenmeden kontrol edilir. Test ve gösterim amaçlı eklenmiştir prod için uygun değildir.
---

## Teşekkürler

Projeyi incelediğiniz için teşekkür ederim.
