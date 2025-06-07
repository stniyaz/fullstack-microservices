![microservices_remastered](https://user-images.githubusercontent.com/1147445/110304529-c5b70180-800c-11eb-832b-a2751b5bda76.png)

There are several microservices implementing e-commerce modules such as **Catalog**, **Basket**, **Discount**, **Ordering**, **Comment**, **Cargo**, and **Message**. These microservices use a combination of NoSQL databases (**MongoDB**, **Redis**) and relational databases (**MS SQL Server**, **PostgreSQL**). They communicate synchronously via **RESTful APIs**, and the APIs are managed and exposed through **RapidAPI** alongside an **Ocelot API Gateway** for seamless client integration.

#### Catalog microservice which includes; 
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **MongoDB database** connection and containerization
* Repository Pattern Implementation
* Swagger Open API implementation	

#### Basket microservice which includes;
* ASP.NET Web API application
* REST API principles, CRUD operations
* **Redis database** connection and containerization
* Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**
  
#### Discount Microservice;
* ASP.NET Core Web API application
* High-performance data access using Dapper with MS SQL Server
* Containerized MS SQL Server database integration
* RESTful synchronous communication with other microservices

#### Ordering Microservice
* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, FluentValidation and AutoMapper packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup

#### Comment Microservice
* ASP.NET Core Web API with layered architecture and clean code practices
* CRUD operations using SQL Server and Entity Framework Core
* Dockerized SQL Server database integration and auto-migration
* OpenAPI documentation and centralized validation mechanism

#### Cargo Microservice
* ASP.NET Core Web API with strict layered (Service, Repository) architecture
* CRUD operations with SQL Server and EF Core support
* Containerized microservice and database with environment configuration
* Integrated validation, logging, and Swagger documentation

#### Message Microservice
* ASP.NET Core Web API for internal/external message handling
* PostgreSQL integration using Entity Framework Core for high performance
* Docker containerization and pgAdmin management support
* Event-driven capabilities with RabbitMQ and MassTransit for messaging

#### Payment Microservice
* Using Stripe.Net 
* Consuming **RabbitMQ** PaymentCheckout event queue with using **MassTransit-RabbitMQ** Configuration

#### PhotoStock Microservice
* Developing PhotoSave and PhotoDelete methods 
	
#### API Gateway Ocelot Microservice
* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways
* Run multiple different **API Gateway/BFF** container types	
* The Gateway aggregation pattern in Shopping.Aggregator

#### Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables

**Conclusion**
**This microservices-based e-commerce system demonstrates a modern, scalable architecture leveraging diverse technologies including RESTful APIs, SQL and NoSQL databases, containerization with Docker, and centralized API management through Ocelot and RapidAPI. The design emphasizes clean separation of concerns, scalability, and maintainability — making it a strong foundation for real-world cloud-native applications.**