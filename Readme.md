We have created four microservices

1. ProductMicroservice
2. UserMicroservice
3. CartMicroservice
4. OrderMicroservice
   All the services follow clean architecture meaning they contain Domain,Application and Infrasturcture layers with respective APIs
   I have also used Kafka Message System and i am using it between CartMicroservice and OrderMicroservice the message is produced by our producer which in our case is CartService and the message is consumed by our otherservice which is OrderService.
   We have used .NET 8 and as we are not using any database here so we have used In-built data structures to store the data such as lists.
