# ExpressEaglesCourier

## :speech_balloon: Short Description

The app is a site of a courier company where staff can perform part of their duties, customers can get in contact with the courier and / or provide their feedback regarding received services and also can track status of their shipment processing.

## :package: **Home And Contact Us Pages**

![HomePage](https://user-images.githubusercontent.com/96121572/221383436-84e48c8a-787a-4bd2-959b-9d585a121110.png)

![ContactUsPage](https://user-images.githubusercontent.com/96121572/221383461-9ca1babf-0dea-469f-b415-887123e2913c.png)


## :floppy_disk: **Database Diagram**

![Diagram](Database-Diagram.png)

## :performing_arts: **Roles**

**Administrator and Manager**

- Both have full access to all areas starting from Administration Dashboard including overview and CRUD operations in Feedback area, can create / update / delete employee record, deletions in all areas are only their privilege. 

- The manager can assign employees responsible for handling a shipment. 

- They can also search for an employee details by phone number in search section.

**Employee**

- Staff have their own board with information regarding courier company activities.

- The employee can create / edit customers', shipments' (including shipment photos), shipment tracking paths' details. 

- Before creating a new shipment record the employee must have registered as clients the sender and the receiver of the goods. After creating new shipment the employee can edit it, create / update tracking path for the shipment. The manager can assign employees for handling the shipment or delete details related to shipment.

- Searches can be done for customers (by phone number), shipment (by tracking number and separately by 3 different criteria), shipment tracking path (by tracking number).

**Customer**

- After providing phone number on register one can be identified as customer and granted relevant customer role. Thereafter can search by tracking number the status of his / her shipment processing - by accessing shipment tracking path details.

- Can use app as any user can.

**Any User**

- Can order a courier after registering.

- Can provide feedback be it positive or negative or neutral after registering.

## :camera: Screenshots

![AdminDashboard](https://user-images.githubusercontent.com/96121572/221406149-b7bdd044-bb5a-4a9b-a259-3be6c70e26a1.png)

![AllFeedbacksPage01](https://user-images.githubusercontent.com/96121572/221407742-f8aec9ab-1c5e-4a52-b24a-0a8065c33c3a.png)

![AssignEmployeeToShipment](https://user-images.githubusercontent.com/96121572/221406963-d2333e52-43bf-471e-94b5-a7f56a282b17.png)

![StaffBoard](https://user-images.githubusercontent.com/96121572/221406154-8872b980-6091-4af9-a765-25a13ac79404.png)

![SearchCustomerByPhonenumber](https://user-images.githubusercontent.com/96121572/221406165-a5038472-f3d6-4694-b256-3a0b372999a9.png)

![SearchShipmentBy3Criteria](https://user-images.githubusercontent.com/96121572/221406158-0b4977db-0d3c-4e6d-b5a7-fc536cf319da.png)

![ShipmentImages](https://user-images.githubusercontent.com/96121572/221406182-c8406302-a0ed-49d0-b810-bd6e11529547.png)

![ShipmentDetailsPage](https://user-images.githubusercontent.com/96121572/221406184-8a8798b8-7467-413d-be69-57ee1b2edddd.png)

![ShipmentTrackingPathPage](https://user-images.githubusercontent.com/96121572/221406908-0c9ed203-6c0e-4e34-991c-c4e6bf4b19fc.png)

![RequestCourierPage](https://user-images.githubusercontent.com/96121572/221406172-7a18b7a7-6627-4e07-9161-0e5753edcf66.png)

![SendFeedbackPage](https://user-images.githubusercontent.com/96121572/221406194-6f45b0b3-4b7a-4186-809d-ee16a7a94b2b.png)

## :notebook_with_decorative_cover: Built With

- ASP.NET Core Template prepared by: Nikolay Kostov, Vladislav Kramfilov, Stoyan Shopov
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- AutoMapper
- StyleCop
- HTML Sanitizer
- xUnit
- SendGrid
- Bootstrap 5, HTML, CSS and Font Awesome
- JavaScript

## :open_file_folder: Usage: 

1. Download the project
2. Write your own connection string in appsettings.json in both Web and Data layers
3. Open or download and open MSSQLServer instance
4. On request I will provide SendGrid ApiKey to enable you start the app
5. Start the app and database will be seeded with few data
6. You can use the app by logging in as preliminarily seeded administrator, employee, customer or you can register as new user.

 
| Role  | Username |Password  | 
| ------------- | ------------- | ------------- | 
| Admin   | Admin  |admin200115 | 
| Employee  | IvaStoyanova  |IS123456## | 
| Customer  | Denislav2001  |DK123456## | 


















[def]: HomePage.png